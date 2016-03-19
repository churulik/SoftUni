var app = app || {};

app.userModel = (function () {
    function UserModel(requester) {
        this._requester = requester;
        this._url = requester._baseUrl + 'user/' + requester._appKey + '/';
    }

    UserModel.prototype.register = function (data) {
        return this._requester.post(this._url, data);
    };

    UserModel.prototype.login = function (data) {
        var url = this._url + 'login';
        return this._requester.post(url, data);
    };

    UserModel.prototype.logout = function () {
        var url = this._url + '_logout';
        return this._requester.post(url, null, true);
    };

    return {
        load: function (requester) {
            return new UserModel(requester);
        }
    }
})();
