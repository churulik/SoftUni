'use strict';

angular.module('issueTracker.controllers.dashboard', [])
    .controller('DashboardController', ['$scope', 'authServices', 'issuesServices', 'projectsServices',
        function ($scope, authServices, issuesServices, projectsServices) {
            $scope.authServices = authServices;

            //Paging
            const pageSize = 5;
            
            $scope.issuesParams = {
                pageNumber: 1,
                pageSize: pageSize
            };

            $scope.reloadIssues = function () {
                issuesServices.getMyIssues($scope.issuesParams).then(function (myIssues) {
                        $scope.totalItems = myIssues.TotalPages * pageSize;
                        $scope.myIssues = myIssues;
                    });
            };

            projectsServices.getAllProjects().then(function (projects) {
                var currentUser = authServices.getCurrentUser();
                $scope.projects = projects.filter(function (project) {
                    return project.Lead.Username === currentUser;
                });
            });

            $scope.reloadIssues();
        }]);