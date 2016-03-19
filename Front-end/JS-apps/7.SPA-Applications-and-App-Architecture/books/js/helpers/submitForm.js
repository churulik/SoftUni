var app = app || {};

app.submitForm = (function () {
    function register() {
        $('form').submit(function () {
            var username, password, data;

            username = $('#username').val();
            password = $('#password').val();
            data = {
                username: username,
                password: password
            };

            Sammy(function () {
                this.trigger('register', data)
            });

            return false;
        });
    }

    function login() {
        $('form').submit(function () {
            var username, password, data;

            username = $('#username').val();
            password = $('#password').val();
            data = {
                username: username,
                password: password
            };

            Sammy(function () {
                this.trigger('login', data)
            });

            return false;
        });
    }

    function addNewBook() {
        $('form').submit(function () {
            var title, author, isbn, data;

            //Get book credentials
            title = $('#title').val();
            author = $('#author').val();
            isbn = $('#isbn').val();
            data = {
                title: title,
                author: author,
                isbn: isbn
            };

            //Send book credentials
            Sammy(function () {
                this.trigger('addNewBook', data);
            });

            //Display message
            app.message.successMessage('The book was added to your collection.')
        })
    }

    function editBook(bookId, data) {
        $('form').submit(function () {
            var newTitle, newAuthor, newIsbn, book;

            //Get new credentials
            newTitle = $('#edit-title').val();
            newAuthor = $('#edit-author').val();
            newIsbn = $('#edit-isbn').val();
            book = {
                _id: bookId,
                title: newTitle,
                author: newAuthor,
                isbn: newIsbn
            };

            //Send new credentials
            Sammy(function () {
                this.trigger('editBook', book)
            });

            //Change the credentials on the page with the new one without refreshing the page
            data.currentTarget.parentNode.parentNode.children[0].innerHTML = newTitle;
            data.currentTarget.parentNode.parentNode.children[1].innerHTML = newAuthor;
            data.currentTarget.parentNode.parentNode.children[2].innerHTML = newIsbn;

            $('#container-edit-book').fadeOut('slow', function () {
                $('#container-edit-book').hide();
            });

            //Display message
            app.message.successMessage('Book edited.');
        })
    }

    return {
        register: register,
        login: login,
        addNewBook: addNewBook,
        editBook: editBook
    }
})();

