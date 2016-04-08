'use strict';

angular.module('issueTracker', ['ngRoute',
        'ngAnimate',
        'chieffancypants.loadingBar',
        'issueTracker.accordion',
        'issueTracker.home',
        'issueTracker.user',
        'issueTracker.dashboard',
        'issueTracker.notifyService'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }]);
   
