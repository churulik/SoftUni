'use strict';

angular.module('issueTracker', ['ngRoute', 'ngAnimate', 'chieffancypants.loadingBar',
        'issueTracker.controllers.admin',
        'issueTracker.controllers.navbar',
        'issueTracker.controllers.home',
        'issueTracker.controllers.account',
        'issueTracker.controllers.dashboard',
        'issueTracker.controllers.issues',
        'issueTracker.controllers.projects',
        'issueTracker.repository.accordion',
        'issueTracker.filters.common',
        'issueTracker.services.notifyService',
        'issueTracker.services.projects',
        'issueTracker.services.issues',
        'issueTracker.services.authServices',
        'issueTracker.services.filter',
        'issueTracker.services.datePicker',
        'issueTracker.directives.common', 'ngTagsInput'])
    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .config(['$routeProvider', 'cfpLoadingBarProvider', function ($routeProvider, cfpLoadingBarProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
        cfpLoadingBarProvider.includeSpinner = false;
    }])
    .run(function ($rootScope, $location, notifyService) {

        // redirect to home page if not logged in
        $rootScope.$on("$routeChangeStart", function (event, next) {
            if (next.originalPath !== '/' && !sessionStorage['access_token']) {
                notifyService.showInfo('Login first');
                $location.path('/');
            }
        });
    });