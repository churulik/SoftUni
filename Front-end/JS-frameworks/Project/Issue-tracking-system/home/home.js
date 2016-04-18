'use strict';

angular.module('issueTracker.home', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'home/home.html',
            controller: 'HomeController'
        })
    }])
    .controller('HomeController', ['$scope', 'accountServices', function ($scope, accountServices) {
        $scope.isAuthenticated = accountServices.isAuthenticated();
    }]);
