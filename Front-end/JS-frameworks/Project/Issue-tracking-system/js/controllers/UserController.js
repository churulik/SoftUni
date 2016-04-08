'use strict';

angular.module('issueTracker.user', [])    
    .controller('UserController', ['$scope', function ($scope) {
        $scope.isAuthorized = false;
        $scope.login = function (loginData) {
            console.log(loginData)
        };
        $scope.register = function (registerData) {
            console.log(registerData)
        };
        
    }]);
