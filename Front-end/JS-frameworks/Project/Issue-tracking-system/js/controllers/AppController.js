'use strict';

angular.module('issueTracker.controller.app', [])
    .controller('AppController', ['$scope', '$location', 'authServices',
        function ($scope, $location, authServices) {
            $scope.authServices = authServices;
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            };
        }]);
