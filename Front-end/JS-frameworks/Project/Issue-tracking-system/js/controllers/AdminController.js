'use strict';

angular.module('issueTracker.controllers.admin', [])
    .controller('AdminController', ['$scope', 'authServices',
        function ($scope, authServices) {
            var isAuthenticated = authServices.isAuthenticated();
            if (isAuthenticated) {
                authServices.isAdministrator().then(function (data) {
                    $scope.isAdmin = data;
                });
            }
        }]);