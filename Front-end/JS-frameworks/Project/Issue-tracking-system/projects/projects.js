'use strict';

angular
    .module('issueTracker.projects', [
        'issueTracker.datePickerServices',
        'issueTracker.filterByDateService',
        'issueTracker.formatterDirective',
        'issueTracker.labels',
        'issueTracker.parserDirective',
        'issueTracker.projectsServices'
    ])

    .config(['$routeProvider', function ($routeProvider) {

        $routeProvider
            .when('/projects', {
                templateUrl: 'projects/list-all-projects.html',
                controller: 'ProjectsController'
            })
            .when('/projects/add', {
                templateUrl: 'projects/add-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id', {
                templateUrl: 'projects/project-by-id.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/edit', {
                templateUrl: 'projects/edit-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/add-issue', {
                templateUrl: 'projects/add-issue.html',
                controller: 'ProjectsController'
            })
    }])

    .controller('ProjectsController', ['$scope', '$routeParams', '$location', 'accountServices', 'datePickerServices',
        'filterByDateService', 'notifyServices', 'projectsServices',
        function ($scope, $routeParams, $location, accountServices, datePickerServices, filterByDateService, notifyServices, projectsServices) {

            var currentUser = accountServices.getCurrentUser(),
                projectId = $routeParams.id,
                assignee = {Assignee: {Username: currentUser}};

            $scope.filterByPriority = {};
            $scope.filterMyIssues = assignee;
            $scope.isAdmin = accountServices.isAdministrator();
            $scope.issueData = {};
            $scope.issueStatus = {};
            $scope.labels = [];
            $scope.projectData = {};
            $scope.projectId = projectId;
            $scope.projectsServices = projectsServices;
            $scope.selectedProject = {};
            $scope.show = {all: false};
            $scope.statusClosed = false;
            $scope.statusInProgress = false;
            $scope.statusOpen = false;
            $scope.statusStoppedProgress = false;

            $scope.initGetAllUsers = function () {
                accountServices.getAllUsers().then(function (users) {
                    $scope.users = users;
                });
            };

            $scope.intiGetAllProjects = function () {
                projectsServices.getAllProjects().then(function (projects) {
                    $scope.projects = projects;
                });
            };

            $scope.initAvailableProjects = function () {
                projectsServices.getAllProjects().then(function (projects) {
                    datePickerServices.datePicker($scope);
                    $scope.availableProjects = projects.filter(function (project) {
                        if(!$scope.isAdmin) {
                            return project.Lead.Username === currentUser;
                        } else {
                            return project;
                        }
                    });
                });
            };

            $scope.initGetProjectById = function () {
                projectsServices.getProjectById(projectId).then(function (project) {

                    $scope.isProjectLeader = currentUser === project.Lead.Username;
                    $scope.project = project
                    
                }, function () {
                    $location.path('/');
                    notifyServices.showError('A project with this id does not exist');
                });
            };

            $scope.initGetProjectIssues = function () {
                projectsServices.getProjectIssues(projectId).then(function (issues) {
                    $scope.issues = issues;
                    // datePickerServices.datePicker($scope);
                });
            };

            $scope.addIssue = function (issueData, project, date) {
                issueData['ProjectId'] = project.Id;
                issueData['DueDate'] = date;
                projectsServices.addIssue(issueData);
            };

            $scope.addProject = function (projectData) {
                projectsServices.addProject(projectData);
            };

            $scope.editProject = function (project) {
                var projectData = {
                    Name: project.Name,
                    Description: project.Description,
                    LeadId: project.Lead.Id,
                    Labels: project.Labels,
                    Priorities: project.Priorities
                };

                projectsServices.editProject(projectData, projectId);
            };

            $scope.filterIssuesByAssignee = function () {
                if (!$scope.show.all) {
                    $scope.filterMyIssues = assignee;

                } else {
                    $scope.filterMyIssues = '';

                }
            };

            $scope.filterIssuesByDueDate = function (day) {
                filterByDateService.filter($scope, day);
            };

            $scope.filterIssuesByStatus = function (status) {
                function noFilter(filterObj) {
                    for (var status in filterObj) {
                        if (filterObj[status]) {
                            return false;
                        }
                    }
                    return true;
                }

                return $scope.issueStatus[status.Status.Name] || noFilter($scope.issueStatus);
            };
        }]);