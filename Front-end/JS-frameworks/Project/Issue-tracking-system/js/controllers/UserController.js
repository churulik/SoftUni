'use strict';

angular.module('issueTracker.user', [])
    .controller('UserController', ['$scope', 'notifyService',
        function ($scope, notifyService) {            
            $scope.login = function (loginData) {
                console.log(loginData)
            };
            
            $scope.register = function (registerData) {
                console.log(registerData)
            };

        }]);
