'use strict';

angular.module('issueTracker.controllers.admin', [])
    .controller('AdminController', ['$scope', 'authServices',
        function ($scope, authServices) {
            $scope.isAdmin = false;
            var isAuthenticated = authServices.isAuthenticated();
            if (isAuthenticated) {
                authServices.isAdministrator().then(function (dataIsAdmin) {
                    if (dataIsAdmin) {
                        $scope.isAdmin = true;
                    }                    
                });
            }
        }]);