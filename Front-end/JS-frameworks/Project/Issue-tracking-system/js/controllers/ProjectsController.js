'use strict';

angular.module('issueTracker.controllers.projects', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/projects', {
                templateUrl: 'views/templates/projects/list-all-projects.html',
                controller: 'ProjectsController'
            })
            .when('/projects/add', {
                templateUrl: 'views/templates/projects/add-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id', {
                templateUrl: 'views/templates/projects/project-by-id.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/edit', {
                templateUrl: 'views/templates/projects/edit-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/add-issue', {
                templateUrl: 'views/templates/projects/add-issue.html',
                controller: 'ProjectsController'
            })
    }])
    .controller('ProjectsController', ['$scope', '$routeParams', 'authServices', 'projectsServices',
        'datePickerService', 'filterServices',
        function ($scope, $routeParams, authServices, projectsServices, datePickerService, filterServices) {
            var projectId = $routeParams.id;
            var currentUser = authServices.getCurrentUser();
            $scope.projectsServices = projectsServices;
            $scope.isAdmin = authServices.isAdministrator();
            $scope.projectId = projectId;
            $scope.issueData = {};
            $scope.projectData = {};
            $scope.selectedProject = {};

            authServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            projectsServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });

            //TODO Lazy loading
            projectsServices.getProjectById(projectId).then(function (project) {
                $scope.isProjectLeader = currentUser === project.Lead.Username;
                $scope.project = project;
            });

            //TODO Lazy loading
            projectsServices.getProjectIssues(projectId).then(function (issues) {
                $scope.issues = issues;
                datePickerService.datePicker($scope);
            });

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

            $scope.addIssue = function (issueData, project, date) {
                issueData['ProjectId'] = project.Id;
                issueData['DueDate'] = date;
                projectsServices.addIssue(issueData);
            };

            $scope.addProject = function (projectData) {
                projectsServices.addProject(projectData);
            };

            //Filter issues
            $scope.checked = false;
            $scope.filterMyIssues = {Assignee: {Username: currentUser}};
            $scope.filterByPriority = {};
            $scope.statusOpen = false;
            $scope.statusInProgress = false;
            $scope.statusStoppedProgress = false;
            $scope.statusClosed = false;
            $scope.filterIssues = function () {
                if (!$scope.checked) {
                    $scope.filterMyIssues = {Assignee: {Username: currentUser}};
                } else {
                    $scope.filterMyIssues = '';
                }
            };
            $scope.filterIssuesByDueDate = function (day) {
                filterServices.filterByDueDate($scope, day);
            };
            
            $scope.issueStatus = {};
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