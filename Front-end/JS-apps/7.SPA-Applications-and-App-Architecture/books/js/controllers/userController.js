var app = app || {};

app.userController = (function () {
    function UserController(userModel, userViewBag) {
        this._userModel = userModel;
        this._userViewBag = userViewBag;
    }

    UserController.prototype.showRegistrationPage = function (container, path) {
        return this._userViewBag.showRegistrationPage(container, path)
    };

    UserController.prototype.showLoginPage = function (container, path) {
        return this._userViewBag.showLoginPage(container, path)
    };

    UserController.prototype.showLogoutPage = function (container, path) {
        return this._userViewBag.showLogoutPage(container, path)
    };

    UserController.prototype.register = function (data) {
        return this._userModel.register(data)
            .then(function (data) {
                sessionStorage['token'] = data._kmd.authtoken;
                sessionStorage['userId'] = data._id;
                Sammy(function () {
                    this.trigger('redirectUrl')
                });
            }, function (error) {
                console.log(error)
            });
    };

    UserController.prototype.login = function (data) {
        return this._userModel.login(data)
            .then(function (data) {
                sessionStorage['token'] = data._kmd.authtoken;
                sessionStorage['userId'] = data._id;
                Sammy(function () {
                    this.trigger('redirectUrl')
                });
            }, function (error) {
                app.message.errorMessage('Enter valid credentials.');
                console.log(error.responseText);
            });
    };

    UserController.prototype.logout = function () {
        return this._userModel.logout()
            .then(function () {
                sessionStorage.clear();
                Sammy(function () {
                    this.trigger('redirectUrl');
                });
            }, function (error) {
                console.log(error)
            });
    };

    return {
        load: function (userModel, userViewBag) {
            return new UserController(userModel, userViewBag)
        }
    }
})();