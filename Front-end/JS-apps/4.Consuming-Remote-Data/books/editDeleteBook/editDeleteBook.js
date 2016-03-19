$(function () {
    function displayBooks(data) {
        var booksTitle, booksId, length, i, bookTitle;

        booksTitle = data.map(function (book) {
            return book.title;
        });

        booksId = data.map(function (book) {
            return book._id;
        });

        //Display books title with edit and delete button
        length = data.length;
        for (i = 0; i < length; i++) {
            bookTitle = $('<div>').text(booksTitle[i] + ' ');
            $('<button value="' + booksId[i] + '" class="edit">Edit</button>').appendTo(bookTitle);
            $('<button value="' + booksId[i] + '" class="delete">Delete</button>').appendTo(bookTitle);
            $('#books').append(bookTitle);
        }

        //Add 'Go back' button
        $('<a href="../index/index.html">Go back</a>').appendTo($('#goBack'));
    }

    function editBook(data) {
        //Edit book
        $('.edit').click(function (book) {
            var bookId = book.target.value;
            data.map(function (book) {
                if (book._id == bookId) {
                    $('#bookId').attr('value', book._id);
                    $('#title').attr('value', book.title).text(book.title);
                    $('#author').attr('value', book.author).text(book.author);
                    $('#isbn').attr('value', book.isbn).text(book.isbn);
                    $('#tags').attr('value', book.tags).text(book.tags);
                }
            });
            $('#editDeleteForm').show();
        });

        //Submit form
        $('#submitBtn').click(function (event) {
            var bookId, title, author, isbn, tags, arrayOfTags, data;

            bookId = $('#bookId').val();
            title = $('#title').val();
            author = $('#author').val();
            isbn = $('#isbn').val();
            tags = $('#tags').val();
            arrayOfTags = tags.split(',');

            data = {
                title: title,
                author: author,
                isbn: isbn,
                tags: arrayOfTags
            };

            ajaxForm(event, 'PUT', 'book/' + bookId, data, 'The book is edit.');

            setTimeout(function () {
                window.location.reload();
                document.getElementById('editDeleteForm').reset();
            }, 2000);
        });

        //Reset form
        $('#resetBtn').click(function () {
            window.location.reload();
        });
    }

    function deleteBook() {
        $('.delete').click(function (book) {
            var confirmation = confirm('Would you like to delete this book?');
            if (confirmation) {
                var bookId = book.target.value;
                $.ajax({
                    method: 'DELETE',
                    headers: headers(),
                    url: 'https://baas.kinvey.com/appdata/kid_ZyrEdAKG1-/book/' + bookId,
                    data: JSON.stringify({})
                }).success(function () {
                    $('#message').css('color', 'red').text('The book is deleted.');
                    updateBookSessionStorage();
                    setTimeout(function () {
                        window.location.reload()
                    }, 2000);
                }).error(function (error) {
                    console.error(error.responseText);
                });
            }
        });
    }

    getBooks(function (data) {
        displayBooks(data);
        editBook(data);
        deleteBook();
    });
});
