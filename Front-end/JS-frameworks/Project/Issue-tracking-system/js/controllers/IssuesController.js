'use strict';

angular.module('issueTracker.controllers.issues', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/issues/:id', {
                templateUrl: 'views/templates/issues/issue-by-id.html',
                controller: 'IssuesController'
            })
            .when('/issues/:id/edit', {
                templateUrl: 'views/templates/issues/edit-issue.html',
                controller: 'IssuesController'
            })
    }])
    .controller('IssuesController', ['$scope', '$routeParams', '$location', 'issuesServices', 'authServices', 'datePickerService',
        function ($scope, $routeParams, $location, issuesServices, authServices, datePickerService) {
            var issueId = $routeParams.id;
            $scope.isAdmin = authServices.isAdministrator();
            $scope.issueId = issueId;
            issuesServices.getIssueById(issueId).then(function (issueData) {
                $scope.issuesServices = issuesServices;
                $scope.issue = issueData;
                datePickerService.datePicker($scope, issueData.DueDate);
                $scope.isAssignee = authServices.getCurrentUser() === issueData.Assignee.Username;
                $scope.isProjectLeader = authServices.getCurrentUser() === issueData.Author.Username;
            });

            $scope.changeStatus = function (statusId) {
                issuesServices.changeStatus(issueId, statusId);
            };

            $scope.editIssue = function (issueDate, date) {
                var editIssueDate = {
                    Title: issueDate.Title,
                    Description: issueDate.Description,
                    DueDate: date,
                    AssigneeId: issueDate.Assignee.Id,
                    PriorityId: issueDate.Priority.Id,
                    Labels: issueDate.Labels
                };
                
                issuesServices.editIssue(editIssueDate, issueId);
            }
        }]);