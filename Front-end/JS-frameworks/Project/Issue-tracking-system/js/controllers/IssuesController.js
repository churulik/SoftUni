'use strict';

angular.module('issueTracker.controllers.issues', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/issues/:id', {
                templateUrl: 'views/templates/issues/issue-by-id.html',
                controller: 'IssuesController'
            })
            .when('/issues/:id/edit', {
                templateUrl: 'views/templates/issues/edit.html',
                controller: 'IssuesController'
            })
    }])
    .controller('IssuesController', ['$scope', '$routeParams', '$location', 'issuesServices', 'authServices',
        function ($scope, $routeParams, $location, issuesServices, authServices) {
            var issueId = $routeParams.id;
            $scope.isAdmin = authServices.isAdministrator();
            $scope.issueId = issueId;
            issuesServices.getIssueById(issueId).then(function (issueData) {
                $scope.issuesServices = issuesServices;
                $scope.issue = issueData;
                $scope.isAssignee = authServices.getCurrentUser() === issueData.Assignee.Username;
                $scope.isProjectLeader = authServices.getCurrentUser() === issueData.Author.Username;
                var labels = [];
                for (var i = 0; i < issueData.Labels.length; i++) {
                    labels.push(issueData.Labels[i].Name);

                }
                $scope.issueLabels = labels.join(', ');

            });

            $scope.changeStatus = function (statusId) {
                issuesServices.changeStatus(issueId, statusId);
            };

            $scope.editIssue = function (issueDate, labels) {
                var editIssueDate = {
                    Title: issueDate.Title,
                    Description: issueDate.Description,
                    DueDate: issueDate.DueDate,
                    AssigneeId: issueDate.Assignee.Id,
                    PriorityId: issueDate.Priority.Id,
                    Labels: []
                },
                splitLabels = labels.split(', ');

                for (var i = 0; i < splitLabels.length; i++) {
                    editIssueDate.Labels.push({Name: splitLabels[i]})
                }

                issuesServices.editIssue(editIssueDate, issueId);
            }
        }]);