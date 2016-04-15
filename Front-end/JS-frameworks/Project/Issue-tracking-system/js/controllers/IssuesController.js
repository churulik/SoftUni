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
                
                // Scope issuesServices
                $scope.issuesServices = issuesServices;
                
                // Scope issue data
                $scope.issue = issueData;
                
                // Set date
                datePickerService.datePicker($scope, issueData.DueDate);
                
                // Get auth roles
                $scope.isAssignee = authServices.getCurrentUser() === issueData.Assignee.Username;
                $scope.isProjectLeader = authServices.getCurrentUser() === issueData.Author.Username;
                
                // Get issue comments
                issuesServices.viewComments(issueId).then(function (comments) {
                    $scope.comments = comments;
                })
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
            };

            $scope.addIssueComment = function (comment) {
                issuesServices.addComment(comment, issueId);
            };
        }]);