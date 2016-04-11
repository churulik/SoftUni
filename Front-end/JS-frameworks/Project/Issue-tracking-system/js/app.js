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
        'issueTracker.notifyService',
        'issueTracker.authServices'])
    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .config(['$routeProvider', 'cfpLoadingBarProvider', function ($routeProvider, cfpLoadingBarProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
        cfpLoadingBarProvider.includeSpinner = false;
    }]);