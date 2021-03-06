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

            $scope.initIssueById = function () {
                issuesServices.getIssueById(issueId).then(function (issueData) {
                    $scope.issue = issueData;

                    //Get user roles
                    projectsServices.getProjectById(issueData.Project.Id).then(function (project) {
                        $scope.isAssignee = accountServices.getCurrentUser() === issueData.Assignee.Username;
                        $scope.isProjectLeader = accountServices.getCurrentUser() === project.Lead.Username;
                    });

                    issuesServices.viewComments(issueId).then(function viewCommentsSuccess(comments) {
                        $scope.comments = comments;
                    });
                }, redirectIfIssueDoesNotExist);

                $scope.addIssueComment = function (comment) {
                    issuesServices.addComment(comment, issueId);
                };

                $scope.changeStatus = function (statusId) {
                    issuesServices.changeStatus(issueId, statusId);
                };
            };

            $scope.initEditIssue = function () {
                issuesServices.getIssueById(issueId).then(function (issueData) {
                    $scope.issue = issueData;
                    datePickerServices.datePicker($scope, issueData.DueDate);

                    projectsServices.getProjectById(issueData.Project.Id).then(function (project) {
                        //Redirect if user tries to edit issue and is not project lead
                        if (accountServices.getCurrentUser() !== project.Lead.Username && !$scope.isAdmin) {
                            return $location.path('/issues/' + issueId);
                        }
                        $scope.isProjectLeader = accountServices.getCurrentUser() === project.Lead.Username;
                        $scope.project = project;

                        accountServices.getAllUsers().then(function (users) {
                            $scope.users = users;
                        });
                    });
                }, redirectIfIssueDoesNotExist);

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
            };

            function redirectIfIssueDoesNotExist() {
                $location.path('/');
                notifyServices.showError('An issue with this id does not exist');
            }
        }]);

    