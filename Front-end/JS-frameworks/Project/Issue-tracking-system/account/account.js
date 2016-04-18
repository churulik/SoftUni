'use strict';

angular.module('issueTracker.account', [
        'issueTracker.accountServices',
        'issueTracker.accordion'
    ])
    .config(accountRoute)
    .controller('AccountController', AccountController);

accountRoute.$inject = ['$routeProvider'];
AccountController.$inject = ['$scope', '$route', 'notifyServices', 'accountServices'];

function accountRoute($routeProvider) {
    $routeProvider
        .when('/profile/password', {
            templateUrl: 'account/change-password.html',
            controller: 'AccountController'
        })
        .when('/logout', {
            template: '<div logout></div>',
            controller: 'AccountController'
        });
}

function AccountController($scope, $route, notifyServices, accountServices) {
    $scope.changePasswordData = {};
    $scope.emailValidationRegex = /^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    $scope.loginData = {grant_type: 'password'};
    $scope.registerData = {};

    $scope.changePassword = function (changePasswordData) {
        accountServices.changePassword(changePasswordData);
    };

    $scope.login = function (loginData) {
        accountServices.login(loginData).then(loginSuccess, loginError);
    };

    $scope.register = function (registerData) {
        accountServices.register(registerData).then(registerSuccess, registerError);
    };

    function loginSuccess() {
        //Get user Info
        accountServices.getUserInfo();
        notifyServices.showInfo('Successful login');
        $route.reload();
    }

    function loginError(error) {
        notifyServices.showError('Unsuccessful login', error);
    }

    function registerSuccess(responce) {
        notifyServices.showInfo('Successful registration');

        //Automatically login the user after registration
        var loginData = {
            Username: responce.config.data.Email,
            Password: responce.config.data.Password,
            grant_type: 'password'
        };

        accountServices.login(loginData).then(autoLoginSuccess);

        function autoLoginSuccess() {
            $route.reload();
        }
    }

    function registerError(error) {
        notifyServices.showError('Unsuccessful registration', error);
    }
}
