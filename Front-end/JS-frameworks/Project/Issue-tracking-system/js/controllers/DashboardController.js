'use strict';

angular.module('issueTracker.dashboard', [])
    .controller('DashboardController', ['$scope', function ($scope) {
        $scope.isAuthorized = false;
    }]);
