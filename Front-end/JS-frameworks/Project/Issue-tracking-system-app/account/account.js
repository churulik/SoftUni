'use strict';

angular
    .module('issueTracker.account', [
        'issueTracker.accountServices',
        'issueTracker.accordion'
    ])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/profile/password', {
                templateUrl: 'account/change-password.html',
                controller: 'AccountController'
            })
            .when('/logout', {
                template: '<div logout></div>',
                controller: 'AccountController'
            });
    }])
    .controller('AccountController', ['$scope', '$route', 'accountServices', 'notifyServices',
        function ($scope, $route, accountServices, notifyServices) {

            $scope.changePasswordData = {};
            $scope.emailValidationRegex = /^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            $scope.loginData = {grant_type: 'password'};
            $scope.registerData = {};

            $scope.changePassword = function (changePasswordData) {
                accountServices.changePassword(changePasswordData);
            };

            $scope.login = function (loginData) {

                accountServices.login(loginData).then(function () {


                    accountServices.getUserInfo().then(function (data) {
                        notifyServices.showInfo('Welcome back ' + data.Username.split('@')[0]);
                        $route.reload();
                    });
                }, function (error) {
                    notifyServices.showError('Unsuccessful login', error);
                });
            };

            $scope.register = function (registerData) {
                accountServices.register(registerData).then(function (responce) {

                    notifyServices.showInfo('Successful registration. <br> Welcome to Issue Tracking System');

                    //Automatically login the user after registration
                    var loginData = {
                        Username: responce.config.data.Email,
                        Password: responce.config.data.Password,
                        grant_type: 'password'
                    };

                    accountServices.login(loginData).then(function () {
                        accountServices.getUserInfo().then(function () {
                            $route.reload();
                        });
                    });

                }, function (error) {
                    notifyServices.showError('Unsuccessful registration', error);
                });
            };
        }]
    );