'use strict';

angular.module('issueTracker.controllers.issues', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/issues/:id', {
                templateUrl: 'views/templates/issues/issue-by-id.html',
                controller: 'IssuesController'
            })
            .when('/issues/:id/edit', {
                templateUrl: 'views/templates/issues/edit.html',
                controller: 'IssuesController'
            })
    }])
    .controller('IssuesController', ['$scope', '$routeParams', 'issuesServices', 'authServices',
        function ($scope, $routeParams, issuesServices, authServices) {
            var issueId = $routeParams.id;
            $scope.isAdmin = authServices.isAdministrator();
            $scope.issueId = issueId;
            issuesServices.getIssueById(issueId).then(function (issueData) {
                $scope.issue = issueData;

            });

            $scope.changeStatus = function (statusId) {
                issuesServices.changeStatus(issueId, statusId);
            }
        }]);