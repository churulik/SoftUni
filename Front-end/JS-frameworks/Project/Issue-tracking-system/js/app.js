'use strict';

angular.module('issueTracker',['ngRoute', 'issueTracker.home', 'accordion'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }]);
