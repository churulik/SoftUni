'use strict';

angular.module('issueTracker', ['ngRoute',
        'ngAnimate',
        'chieffancypants.loadingBar',
        'issueTracker.accordion',
        'issueTracker.home',
        'issueTracker.user',
        'issueTracker.dashboard',
        'issueTracker.issues',
        'issueTracker.projects',
        'issueTracker.notifyService'])
    .constant('BASE_URL', 'http://softuni-social-network.azurewebsites.net/api/')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }]);
   
