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
    .controller('ProjectsController', ['$q', '$scope', '$routeParams', 'authServices', 'projectsServices',
        function ($q, $scope, $routeParams, authServices, projectsServices) {
            $scope.issueData = {};
            var projectId = $routeParams.id;
            $scope.projectId = projectId;
            authServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            projectsServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });
            $q.all([
                authServices.isAdministrator().then(function (data) {
                    $scope.isAdmin = data;
                }),
                projectsServices.getProjectById(projectId).then(function (project) {
                    $scope.project = project;
                }),
                projectsServices.getProjectIssues(projectId).then(function (issues) {
                    $scope.issues = issues;
                })
            ]);

            

            
            $scope.addIssue = function (issueData) {

            };
        }]);