'use strict';

angular.module('issueTracker.controllers.navbar', [])
    .controller('NavbarController', ['$scope', '$location', 'authServices',
        function ($scope, $location, authServices) {
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            };

            var isAuthenticated = authServices.isAuthenticated();
            if (isAuthenticated) {
                authServices.isAdministrator().then(function (data) {
                    $scope.isAdmin = data;                   
                });
            }
        }]);
