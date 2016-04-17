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
    .controller('IssuesController', ['$scope', '$routeParams', '$location', 'issuesServices', 'authServices', 'datePickerService','notifyServices',
        function ($scope, $routeParams, $location, issuesServices, authServices, datePickerService, notifyServices) {
            var issueId = $routeParams.id;
            $scope.isAdmin = authServices.isAdministrator();
            $scope.issueId = issueId;
            issuesServices.getIssueById(issueId).then(function (issueData) {
                $scope.issuesServices = issuesServices;
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
            }, function () {
                $location.path('/');
                notifyServices.showError('An issue with this id does not exist');
            });
        
            $scope.changeStatus = function (statusId) {
                issuesServices.changeStatus(issueId, statusId);
            };
            
            issuesServices.getLabels().then(function (response) {
                $scope.loadLabels = function ($query) {
                    return response.filter(function (label) {
                        return label.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
                    })
                };
            });
            
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