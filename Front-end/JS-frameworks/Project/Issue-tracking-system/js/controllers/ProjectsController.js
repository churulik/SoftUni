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
    .controller('ProjectsController', ['$scope', '$routeParams', 'authServices',
        function ($scope, $routeParams, authServices) {
            $scope.issueData = {};
            // $scope.users = [{Id: 1, Username: 'Ivan'}, {Id: 2, Username: 'todor'}];
            // $scope.projects = [
            //     {
            //         "Id": 1,
            //         "Name": "entirely new project",
            //         "ProjectKey": "123adfj",
            //         "Description": "random desc",
            //         "Lead": {
            //             "Id": "e0e672ee-9382-4860-98be-cfa68743a20a",
            //             "Username": "admin@softuni.bg",
            //             "isAdmin": true
            //         },
            //         "TransitionSchemeId": 1,
            //         "Labels": [
            //             {
            //                 "Id": 1,
            //                 "Name": "Label1"
            //             },
            //             {
            //                 "Id": 2,
            //                 "Name": "Label2"
            //             }
            //         ],
            //         "Priorities": [
            //             {
            //                 "Id": 1,
            //                 "Name": "Low"
            //             },
            //             {
            //                 "Id": 2,
            //                 "Name": "Urgent"
            //             }
            //         ]
            //     },
            //     {
            //         "Id": 2,
            //         "Name": "Golqm Problem S API-to",
            //         "ProjectKey": "1",
            //         "Description": "js is the best",
            //         "Lead": {
            //             "Id": "e0e672ee-9382-4860-98be-cfa68743a20a",
            //             "Username": "admin@softuni.bg",
            //             "isAdmin": true
            //         },
            //         "TransitionSchemeId": 1,
            //         "Labels": [],
            //         "Priorities": [
            //             {
            //                 "Id": 3,
            //                 "Name": "Danger"
            //             }
            //         ]
            //     },
            //     {
            //         "Id": 3,
            //         "Name": "Golqm Problem S API-to",
            //         "ProjectKey": "1",
            //         "Description": "js is the best",
            //         "Lead": {
            //             "Id": "e0e672ee-9382-4860-98be-cfa68743a20a",
            //             "Username": "admin@softuni.bg",
            //             "isAdmin": true
            //         },
            //         "TransitionSchemeId": 1,
            //         "Labels": [],
            //         "Priorities": [
            //             {
            //                 "Id": 3,
            //                 "Name": "Danger"
            //             }
            //         ]
            //     },
            //     {
            //         "Id": 4,
            //         "Name": "Rent a car",
            //         "ProjectKey": "RC",
            //         "Description": "MS for rent a cars",
            //         "Lead": {
            //             "Id": "aa5a7e16-b966-4378-8733-70bdf2139c91",
            //             "Username": "ala@abv.bg",
            //             "isAdmin": true
            //         },
            //         "TransitionSchemeId": 1,
            //         "Labels": [
            //             {
            //                 "Id": 1,
            //                 "Name": "Label1"
            //             },
            //             {
            //                 "Id": 2,
            //                 "Name": "Label2"
            //             }
            //         ],
            //         "Priorities": [
            //             {
            //                 "Id": 1,
            //                 "Name": "Low"
            //             }
            //         ]
            //     }
            // ];
            
            authServices.getAllUsers().then(function (users) {
                $scope.users = users;
            });

            authServices.getAllProjects().then(function (projects) {
                $scope.projects = projects;
            });
            
            $scope.addIssue = function (issueData) {

            };
        }]);