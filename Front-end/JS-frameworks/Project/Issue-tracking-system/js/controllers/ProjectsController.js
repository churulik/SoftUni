'use strict';

angular.module('issueTracker.projects', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
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
    .controller('ProjectsController', ['$scope', '$routeParams', 'authServices',
        function ($scope, $routeParams, authServices) {
            $scope.issueData = {};
            
            authServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            authServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });

            authServices.getProjectById($routeParams.id).then(function (project) {
                $scope.projectById = project;
            });
            
            $scope.addIssue = function (issueData) {

            };
        }]);