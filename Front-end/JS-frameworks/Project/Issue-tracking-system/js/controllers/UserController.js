'use strict';

angular.module('issueTracker.user', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/profile', {
                templateUrl: 'views/templates/user/profile.html',
                controller: 'UserController'
            })
            .when('/profile/password', {
                templateUrl: 'views/templates/user/change-password.html',
                controller: 'UserController'
            })
            .when('/logout', {
                templateUrl: 'views/templates/user/logout.html',
                controller: 'UserController'
            });
    }])
    .controller('UserController', ['$scope', '$location', 'notifyService',
        function ($scope, $location, notifyService) {
            $scope.loginData = {};
            $scope.registerData = {};
            $scope.regex = /^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            $scope.login = function (loginData) {
                console.log(loginData);
            };

            $scope.register = function (registerData) {
                console.log(registerData)
            };
        }])
    .directive('confirmPasswordValidation', [function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, controller) {
                var password = attrs.confirmPasswordValidation;
                var confirmPassword = attrs.ngModel;

                console.log(password);
                // console.log(confirmPassword);

                scope.$watchGroup([password, confirmPassword], function (value) {
                    controller.$setValidity('confirmPassword', value[0] === value[1])
                });
            }
        };
    }])
    .directive('logout', ['$location', 'notifyService', function ($location, notifyService) {
        return {
            link: function () {
                notifyService.showInfo('Successful log out');
                $location.path('/');
            }
        };
    }]);
