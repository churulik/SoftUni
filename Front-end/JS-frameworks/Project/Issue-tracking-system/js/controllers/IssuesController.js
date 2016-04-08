'use strict';

angular.module('issueTracker.issues', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/issues/:id', {
                templateUrl: 'views/templates/issues/home.html',
                controller: 'IssuesController'
            })
            .when('/issues/:id/edit', {
                templateUrl: 'views/templates/issues/edit.html',
                controller: 'IssuesController'
            })
    }])
    .controller('IssuesController', ['$scope', '$routeParams', function ($scope, $routeParams) {

    }]);