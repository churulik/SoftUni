'use strict';

angular.module('issueTracker.controllers.account', [])
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
    .controller('AccountController', ['$scope', '$location', '$route', 'notifyServices', 'authServices',
        function ($scope, $location, $route, notifyServices, authServices) {
            $scope.loginData = {grant_type: 'password'};
            $scope.registerData = {};
            $scope.changePasswordData = {};
            $scope.emailValidationRegex =
                /^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            $scope.login = function (loginData) {
                authServices.login(loginData).then(function () {
                    //Get user Info
                    authServices.getUserInfo();
                    notifyServices.showInfo('Successful login');
                    $route.reload();
                }, function (error) {
                    notifyServices.showError('Unsuccessful login', error);                    
                });
            };

            $scope.register = function (registerData) {
                authServices.register(registerData).then(function (responce) {
                    notifyServices.showInfo('Successful registration');

                    //Automatically login the registered user
                    var loginData = {
                        Username: responce.config.data.Email,
                        Password: responce.config.data.Password,
                        grant_type: 'password'
                    };

                    authServices.login(loginData).then(function () {
                            $route.reload();
                        }, function (error) {
                            console.log(error)
                        });
                }, function (error) {
                    notifyServices.showError('Unsuccessful registration', error);
                    console.log(error)
                });
            };

            $scope.changePassword = function (changePasswordData) {
                authServices.changePassword(changePasswordData);
            }
        }])
    .directive('confirmPasswordValidation', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, controller) {
                var password = attrs.confirmPasswordValidation;
                var confirmPassword = attrs.ngModel;
                scope.$watchGroup([password, confirmPassword], function (value) {
                    var confirmPasswordMatch = value[0] === value[1];
                    controller.$setValidity('confirmPasswordMatch', confirmPasswordMatch)
                });
            }
        };
    }])
    .directive('logout', ['$location', 'notifyServices', function ($location, notifyServices) {
        return {
            restrict: 'A',
            link: function () {
                sessionStorage.clear();
                notifyServices.showInfo('Successful log out');
                $location.path('/');
            }
        };
    }]);
