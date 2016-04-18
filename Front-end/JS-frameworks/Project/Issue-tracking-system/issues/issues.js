'use strict';

angular
    .module('issueTracker.issues', [
        'issueTracker.datePickerServices',
        'issueTracker.formatterDirective',
        'issueTracker.issuesServices',
        'issueTracker.labels',
        'issueTracker.parserDirective'
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
    .controller('IssuesController', ['$scope', '$routeParams', '$location', 'accountServices', 'datePickerServices',
        'issuesServices', 'notifyServices', 'projectsServices',
        function ($scope, $routeParams, $location, accountServices, datePickerServices, issuesServices, notifyServices, projectsServices) {

            var issueId = $routeParams.id;
            $scope.isAdmin = accountServices.isAdministrator();
            $scope.issueId = issueId;

            $scope.addIssueComment = function (comment) {
                issuesServices.addComment(comment, issueId);
            };

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

            issuesServices.getIssueById(issueId).then(function (issueData) {
                projectsServices.getProjectById(issueData.Project.Id).then(function (project) {
                    $scope.issue = issueData;
                    $scope.isAssignee = accountServices.getCurrentUser() === issueData.Assignee.Username;
                    $scope.isProjectLeader = accountServices.getCurrentUser() === project.Lead.Username;

                    //Redirect if user tries to reach issues/:id/edit page and is not admin or project lead
                    if (!$scope.isProjectLeader && !$scope.isAdmin && $location.url().split('/')[3] === 'edit') {
                        $location.path('/');
                    }
                    //Get all comments if is assignee or project lead or admin
                    if ($scope.isAssignee || $scope.isProjectLeader || $scope.isAdmin) {
                        issuesServices.viewComments(issueId).then(function viewCommentsSuccess(comments) {
                            $scope.comments = comments;
                        });
                    }
                    // If on the edit page - load all users
                    if ($location.url().split('/')[3] === 'edit') {
                        accountServices.getAllUsers().then(function (users) {
                            $scope.project = project;
                            $scope.users = users;

                            datePickerServices.datePicker($scope, issueData.DueDate);
                        });
                    }
                });
            }, function () {
                $location.path('/');
                notifyServices.showError('An issue with this id does not exist');
            });
        }]);