'use strict';

angular.module('issueTracker.controllers.navbar', [])
    .controller('NavbarController', ['$scope', '$location', function ($scope, $location) {
        $scope.isActive = function (viewLocation) {
            return viewLocation === $location.path();
        }
    }]);
