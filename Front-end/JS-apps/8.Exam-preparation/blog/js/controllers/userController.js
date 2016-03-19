var app = app || {};

app.userController = (function () {
    function UserController(userModel, userViewBag) {
        this._userModel = userModel;
        this._userViewBag = userViewBag;
    }

    function onSuccess(successData, text, type) {
        sessionStorage['token'] = successData._kmd.authtoken;
        sessionStorage['username'] = successData.username;
        noty({
            theme: 'relax',
            text: text,
            type: type,
            timeout: 2000,
            closeWith: ['click']
        });
        Sammy(function () {
            this.trigger('redirectUrl', {url: '#/home/'})
        });
    }

    UserController.prototype.showRegisterPage = function (selector) {
        this._userViewBag.loadRegisterTemplate(selector);
    };

    UserController.prototype.showLoginPage = function (selector) {
        this._userViewBag.loadLoginTemplate(selector);
    };

    UserController.prototype.register = function (data) {
        return this._userModel.register(data)
            .then(function (success) {
                onSuccess(success, 'Successful registration!', 'success');
            }).done();
    };

    UserController.prototype.login = function (data) {
        return this._userModel.login(data)
            .then(function (successData) {
                onSuccess(successData, 'Successful login', 'alert');
            }).done();
    };

    UserController.prototype.logout = function () {
        return this._userModel.logout()
            .then(function () {
                sessionStorage.clear();
                noty({
                    theme: 'relax',
                    text: 'Successful logout',
                    type: 'alert',
                    timeout: 2000,
                    closeWith: ['click']
                });
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'})
                });
            }).done();
    };

    return {
        load: function (userModel, userViewBag) {
            return new UserController(userModel, userViewBag);
        }
    }
})();
