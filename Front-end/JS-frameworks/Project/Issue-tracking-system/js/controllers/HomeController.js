'use strict';

angular.module('issueTracker.home', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'views/templates/home.html',
            controller: 'HomeController'
        })
    }])
    .controller('HomeController', ['$scope', function ($scope) {

    }]);
