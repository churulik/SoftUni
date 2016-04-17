'use strict';

angular.module('issueTracker.controllers.navbar', [])
    .controller('NavbarController', ['$scope', '$location', '$route', 'authServices',
        function ($scope, $location, $route, authServices) {
            $scope.authServices = authServices;        
            
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            };                        
        }]);
