'use strict';

angular.module('issueTracker.projects', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/projects/:id', {
                templateUrl: 'views/templates/projects/home.html',
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
    }])
    .controller('ProjectsController', ['$scope', '$routeParams', function ($scope, $routeParams) {

    }]);