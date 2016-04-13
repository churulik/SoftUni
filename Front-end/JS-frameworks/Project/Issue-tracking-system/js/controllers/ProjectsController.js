'use strict';

angular.module('issueTracker.controllers.projects', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/projects', {
                templateUrl: 'views/templates/projects/project-by-id.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id', {
                templateUrl: 'views/templates/projects/project-by-id.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/edit', {
                templateUrl: 'views/templates/projects/edit.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/add-issue', {
                templateUrl: 'views/templates/projects/add-issue.html',
                controller: 'ProjectsController'
            })
            .when('/projects/add', {
                templateUrl: 'views/templates/projects/add-project.html',
                controller: 'ProjectsController'
            })
    }])
    .controller('ProjectsController', ['$scope', '$routeParams', 'authServices', 'projectsServices',
        function ($scope, $routeParams, authServices, projectsServices) {
            var projectId = $routeParams.id;
            $scope.issueData = {};
            $scope.projectId = projectId;
            $scope.dateValidation = /^\d{4}\/\d{2}\/\d{2}$/;

            authServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            projectsServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });

            $scope.isAdmin = authServices.isAdministrator();

            projectsServices.getProjectById(projectId).then(function (project) {
                var labels = [],
                    priorities = [];

                angular.forEach(project.Labels, function (label) {
                    labels.push(label.Name);
                });

                angular.forEach(project.Priorities, function (priority) {
                    priorities.push(priority.Name);
                });

                $scope.project = project;
                $scope.labels = labels.join(', ');
                $scope.priorities = priorities.join(', ');
            });

            projectsServices.getProjectIssues(projectId).then(function (issues) {
                $scope.issues = issues;
            });

            $scope.editProject = function (project, labels, priorities) {
                var projectData = {
                        Name: project.Name,
                        Description: project.Description,
                        LeadId: project.Lead.Id,
                        Labels: [],
                        Priorities: []

                    },
                    splitLabels = labels.split(', '),
                    splitPriorities = priorities.split(', ');

                for (var i = 0; i < splitLabels.length; i++) {
                    projectData.Labels.push({Name: splitLabels[i]});

                }

                for (i = 0; i < splitPriorities.length; i++) {
                    projectData.Priorities.push({Name: splitPriorities[i]});

                }

                projectsServices.editProject(projectData, projectId);

            };

            $scope.addIssue = function (issueData) {
                console.log(issueData)
            };
        }]);