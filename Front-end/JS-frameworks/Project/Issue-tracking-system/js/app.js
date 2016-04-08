'use strict';

angular.module('issueTracker', ['ngRoute',
        'chieffancypants.loadingBar',
        'ngAnimate',
        'issueTracker.accordion',
        'issueTracker.home',
        'issueTracker.user',
        'issueTracker.dashboard',
        'issueTracker.notifyService'])
    .config(['$routeProvider', 'cfpLoadingBarProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }]);
   
