var app = app || {};

app.booksViewBag = (function () {
    function showAllBooks(container, path, books) {
        $.get(path, function (templ) {
            var render = Mustache.render(templ, books);
            fadeInText(container, render);
        })
    }

    function showAddNewBookPage(container, path) {
        $.get(path, function (templ) {
            fadeInText(container, templ);
            app.submitForm.addNewBook();
        });
    }

    function showUserBooks(container, path, userBooks) {
        $.get(path, function (templ) {
            var render = Mustache.render(templ, userBooks);
            fadeInText(container, render);

            //Edit book
            $('.edit-book-btn').click(function (data) {

                //Display book
                var bookId, title, author, isbn, book;

                bookId = this.value;
                title = data.currentTarget.parentNode.parentNode.children[0].innerHTML;
                author = data.currentTarget.parentNode.parentNode.children[1].innerHTML;
                isbn = data.currentTarget.parentNode.parentNode.children[2].innerHTML;

                $('#edit-title').attr('value', title).text(title);
                $('#edit-author').attr('value', author).text(author);
                $('#edit-isbn').attr('value', isbn).text(isbn);

                $('#container-edit-book').fadeIn('slow', function () {
                    $('#container-edit-book').show();
                });

                //Edit book
                app.submitForm.editBook(bookId, data);
            });


            //Delete book
            $('.delete-book-btn').click(function (data) {
                var confirmation, bookId, currentBook, $containerEditBook;

                //Confirm deletion of book
                confirmation = confirm('Would you like to delete the book?');
                if (confirmation) {
                    bookId = this.value;
                    Sammy(function () {
                        this.trigger('deleteBook', bookId)
                    });

                    //Remove current book node from the page
                    currentBook = data.currentTarget.parentNode.parentNode;
                    $(currentBook).fadeOut('slow', function () {
                        currentBook.remove();
                    });

                    //Check if edit box is displayed
                    $containerEditBook = $('#container-edit-book');
                    if ($containerEditBook.css('display') == 'block') {
                        $containerEditBook.fadeOut('slow', function () {
                            $containerEditBook.hide();
                        });
                    }

                    //Display message
                    app.message.errorMessage('Book deleted.');
                }
            });
        })
    }

    return {
        load: function () {
            return {
                showAllBooks: showAllBooks,
                showAddNewBookPage: showAddNewBookPage,
                showUserBooks: showUserBooks
            }
        }
    }
})();
