'use strict';

angular.module('issueTracker.issues', ['issueTracker.issuesServices',
        'issueTracker.datePickerService',
        'issueTracker.commonDirective'
    ])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/issues/:id', {
                templateUrl: 'issues/issue-by-id.html',
                controller: 'IssuesController'
            })
            .when('/issues/:id/edit', {
                templateUrl: 'issues/edit-issue.html',
                controller: 'IssuesController'
            })
    }])
    .controller('IssuesController', ['$scope', '$routeParams', '$location', 'issuesServices', 'accountServices', 'datePickerService', 'notifyServices', 'projectsServices',
        function ($scope, $routeParams, $location, issuesServices, accountServices, datePickerService, notifyServices, projectsServices) {
            var issueId = $routeParams.id;
            $scope.isAdmin = accountServices.isAdministrator();
            $scope.issueId = issueId;
            issuesServices.getIssueById(issueId).then(function (issueData) {
                projectsServices.getProjectById(issueData.Project.Id).then(function (project) {
                    $scope.issuesServices = issuesServices;
                    $scope.issue = issueData;

                    // Set date
                    datePickerService.datePicker($scope, issueData.DueDate);
                    // Get auth roles
                    $scope.isAssignee = accountServices.getCurrentUser() === issueData.Assignee.Username;
                    $scope.isProjectLeader = accountServices.getCurrentUser() === project.Lead.Username;

                    if(!$scope.isProjectLeader && !$scope.isAdmin && $location.url().split('/')[3] === 'edit') {
                        $location.path('/');
                    }
                });

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