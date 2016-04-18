'use strict';

angular
    .module('issueTracker.dashboard', [])
    .controller('DashboardController', ['$scope', 'accountServices', 'issuesServices', 'projectsServices',
        function ($scope, accountServices, issuesServices, projectsServices) {
            const itemsPerPage = 5;
            $scope.accountServices = accountServices;
            $scope.issuesParams = {
                pageNumber: 1,
                itemsPerPage: itemsPerPage
            };

            $scope.reloadIssues = function () {
                issuesServices.getMyIssues($scope.issuesParams).then(function (myIssues) {
                    $scope.totalIssuesItems = myIssues.TotalPages * itemsPerPage;
                    $scope.myIssues = myIssues;
                });
            };

            $scope.reloadIssues();

            projectsServices.getAllProjects().then(function (projects) {
                var currentUser = accountServices.getCurrentUser();
                $scope.projectId = '';
                $scope.projects = projects.filter(function (project) {
                    return project.Lead.Username === currentUser;
                });
            });
        }]
    );

