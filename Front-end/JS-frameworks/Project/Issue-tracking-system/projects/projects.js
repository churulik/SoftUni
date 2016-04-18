'use strict';

angular.module('issueTracker.projects', ['issueTracker.projectsServices',
        'issueTracker.filterServices',
        'issueTracker.datePickerService',
        'issueTracker.commonDirective'
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
    .controller('ProjectsController', ['$scope', '$routeParams', '$location', 'accountServices', 'projectsServices',
        'datePickerService', 'filterServices', 'notifyServices',
        function ($scope, $routeParams, $location, accountServices, projectsServices, datePickerService, filterServices, notifyServices) {
            var projectId = $routeParams.id;
            var currentUser = accountServices.getCurrentUser();
            $scope.projectsServices = projectsServices;
            $scope.isAdmin = accountServices.isAdministrator();
            $scope.projectId = projectId;
            $scope.issueData = {};
            $scope.projectData = {};
            $scope.selectedProject = {};
            $scope.labels = [];

            accountServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            projectsServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });

            if (projectId) {
                //TODO Lazy loading
                projectsServices.getProjectById(projectId).then(function (project) {
                    $scope.isProjectLeader = currentUser === project.Lead.Username;
                    $scope.project = project;
                }, function () {
                    $location.path('/');
                    notifyServices.showError('A project with this id does not exist');
                });

                //TODO Lazy loading
                projectsServices.getProjectIssues(projectId).then(function (issues) {
                    $scope.issues = issues;
                    datePickerService.datePicker($scope);
                });
            }

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

            projectsServices.getLabels().then(function (response) {
                $scope.loadLabels = function ($query) {
                    return response.filter(function (label) {
                        return label.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
                    })
                };
            });

            $scope.addIssue = function (issueData, project, date) {
                issueData['ProjectId'] = project.Id;
                issueData['DueDate'] = date;
                projectsServices.addIssue(issueData);
            };

            $scope.addProject = function (projectData) {
                projectsServices.addProject(projectData);
            };

            //Filter issues
            $scope.show = {all: false};
            $scope.filterMyIssues = {Assignee: {Username: currentUser}};
            $scope.filterByPriority = {};
            $scope.statusOpen = false;
            $scope.statusInProgress = false;
            $scope.statusStoppedProgress = false;
            $scope.statusClosed = false;
            $scope.filterIssues = function () {
                if (!$scope.show.all) {
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