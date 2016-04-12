'use strict';

angular.module('issueTracker.controllers.dashboard', [])
    .controller('DashboardController', ['$scope', 'authServices', function ($scope, authServices) {
        var isAuthenticated = authServices.isAuthenticated();
        if (isAuthenticated) {
            authServices.isAdministrator().then(function (data) {
                $scope.isAdmin = data;
            });            
        }
        authServices.getMyIssues(10).then(function (myIssues) {
            $scope.myIssues = myIssues;
        });        
    }]);