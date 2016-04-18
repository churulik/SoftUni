'use strict';

angular.module('issueTracker.navbar', [])
    .controller('NavbarController', ['$scope', '$location', '$route', 'accountServices',
        function ($scope, $location, $route, accountServices) {
            $scope.accountServices = accountServices;        
            
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            };                        
        }]);
