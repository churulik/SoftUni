'use strict';

angular.module('issueTracker.controllers.dashboard', [])
    .controller('DashboardController', ['$scope', 'authServices', 'issuesServices',
        function ($scope, authServices, issuesServices) {
            var isAuthenticated = authServices.isAuthenticated();
            if (isAuthenticated) {
                authServices.isAdministrator().then(function (data) {
                    console.log(data)
                    $scope.isAdmin = data;
                });
            }
            issuesServices.getMyIssues(5).then(function (myIssues) {
                $scope.myIssues = myIssues;
            });
        }]);