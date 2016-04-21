'use strict';

angular
    .module('issueTracker.delay', ['angular-loading-bar'])
    .controller('DelayController', ['$scope', '$timeout', function ($scope, $timeout) {
        $scope.delay = true;
        $timeout(function() {
            $scope.delay = false;
        },550);
    }]);
