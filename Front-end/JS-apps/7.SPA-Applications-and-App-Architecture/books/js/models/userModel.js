var app = app || {};

app.userModel = (function () {
    function UserModel(requester) {
        this._requester = requester;
        this._url = this._requester._baseUrl + 'user/' + this._requester._appKey;
    }

    UserModel.prototype.register = function (data) {
        return this._requester.postMethod(this._url, data);
    };

    UserModel.prototype.login = function (data) {
        return this._requester.postMethod(this._url + '/login',data)
    };

    UserModel.prototype.logout = function () {
        return this._requester.postMethod(this._url + '/_logout', null, true)
    };
    return {
        load: function (requester) {
            return new UserModel(requester);
        }
    }
})();
