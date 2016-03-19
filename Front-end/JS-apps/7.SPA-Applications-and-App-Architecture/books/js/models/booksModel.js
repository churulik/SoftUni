var app = app || {};

app.booksModel = (function () {
    function BooksModel(requester) {
        this._requester = requester;
        this._url = this._requester._baseUrl + 'appdata/' + this._requester._appKey + '/book';
    }

    BooksModel.prototype.getAllBooks = function () {
        return this._requester.defaultHomeRequest(this._url);
    };

    BooksModel.prototype.addNewBook = function (data) {
        return this._requester.postMethod(this._url, data, true);
    };

    BooksModel.prototype.getUserBooks = function () {
        return this._requester.getMethod(this._url + '?query={"_acl":{"creator":"' + sessionStorage['userId'] + '"}}');
    };

    BooksModel.prototype.editBook = function (book) {
        return this._requester.putMethod(this._url + '/' + book._id, book);
    };

    BooksModel.prototype.deleteBook = function (bookId) {
        return this._requester.deleteMethod(this._url + '/' + bookId);
    };

    return {
        load: function (requester) {
            return new BooksModel(requester);
        }
    }
})();