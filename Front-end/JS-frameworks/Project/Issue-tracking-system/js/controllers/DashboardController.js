'use strict';

angular.module('issueTracker.controllers.dashboard', [])
    .controller('DashboardController', ['$scope', 'authServices', 'issuesServices',
        function ($scope, authServices, issuesServices) {
            var isAuthenticated = authServices.isAuthenticated();
            if (isAuthenticated) {
                authServices.isAdministrator().then(function (data) {
                    $scope.isAdmin = data;
                });
            }
            //Paging
            const pageSize = 5;
            
            $scope.issuesParams = {
                pageNumber: 1,
                pageSize: pageSize
            };

            $scope.reloadIssues = function () {
                issuesServices.getMyIssues($scope.issuesParams)
                    .then(function (myIssues) {
                        $scope.totalItems = myIssues.TotalPages * pageSize;
                        $scope.myIssues = myIssues;
                    }, function (error) {
                        console.log(error)
                    });
            };

            $scope.reloadIssues();
        }]);