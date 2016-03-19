var app = app || {};

app.booksController = (function () {
    function BooksController(booksModel, booksViewBag) {
        this._booksModel = booksModel;
        this._booksViewBag = booksViewBag;
    }

    BooksController.prototype.showAllBooks = function (container, path) {
        var _this = this;

        return this._booksModel.getAllBooks()
            .then(function (data) {

                var result = {
                    books: []
                };

                data.forEach(function (book) {
                    result.books.push(new BookOutputModel(book._id, book.title, book.author, book.isbn))
                });

                _this._booksViewBag.showAllBooks(container, path, result)
            }, function (error) {
                console.log(error)
            });
    };

    BooksController.prototype.showAddNewBookPage = function (container, path) {
        return this._booksViewBag.showAddNewBookPage(container, path)
    };

    BooksController.prototype.showUserBooks = function (container, path) {
        var _this = this;
        return this._booksModel.getUserBooks()
            .then(function (data) {
                var result = {
                    books: []
                };
                data.forEach(function (book) {
                    result.books.push(new BookOutputModel(book._id, book.title, book.author, book.isbn))
                });

                _this._booksViewBag.showUserBooks(container, path, result);
            }, function (error) {
                console.log(error)
            });
    };

    BooksController.prototype.addNewBook = function (data) {
        return this._booksModel.addNewBook(data);
    };

    BooksController.prototype.editBook = function (book) {
        return this._booksModel.editBook(book);
    };

    BooksController.prototype.deleteBook = function (bookId) {
        return this._booksModel.deleteBook(bookId);
    };

    return {
        load: function (booksModel, booksViewBag) {
            return new BooksController(booksModel, booksViewBag);
        }
    }
})();