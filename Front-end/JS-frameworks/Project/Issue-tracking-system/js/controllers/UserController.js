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
            $scope.login = function (loginData) {
                console.log(loginData);
            };

            $scope.register = function (registerData) {
                console.log(registerData)
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
