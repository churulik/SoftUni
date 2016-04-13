'use strict';

angular.module('issueTracker.controllers.navbar', [])
    .controller('NavbarController', ['$scope', '$location', 'authServices',
        function ($scope, $location, authServices) {
            $scope.authServices = authServices;
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            };                        
        }]);
