'use strict';

angular
    .module('issueTracker.delay', ['angular-loading-bar'])
    .controller('DelayController', ['$scope', '$timeout', 'cfpLoadingBar', function ($scope, $timeout, cfpLoadingBar) {
        $scope.start = function() {
            cfpLoadingBar.start();
        };

        $scope.complete = function () {
            cfpLoadingBar.complete();
        };

        $scope.start();
        $scope.delay = true;
        $timeout(function() {
            $scope.complete();
            $scope.delay = false;
        },550);
    }]);
