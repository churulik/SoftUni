'use strict';

angular.module('issueTracker', ['ngRoute', 'ngAnimate', 'chieffancypants.loadingBar',
        'issueTracker.controllers.navbar',
        'issueTracker.controllers.home',
        'issueTracker.controllers.user',
        'issueTracker.controllers.dashboard',
        'issueTracker.controllers.issues',
        'issueTracker.controllers.projects',
        'issueTracker.repository.accordion',
        'issueTracker.services.notifyService',
        'issueTracker.services.authServices'])
    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .config(['$routeProvider', 'cfpLoadingBarProvider', function ($routeProvider, cfpLoadingBarProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
        cfpLoadingBarProvider.includeSpinner = false;
    }]);