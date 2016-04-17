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
    .run(['$rootScope', '$location', 'notifyService', 'authServices', function ($rootScope, $location, notifyService, authServices) {
        $rootScope.$on("$routeChangeStart", function (event, next) {

            // Redirect to Home page if not logged in
            if (next.originalPath !== '/' && !sessionStorage['access_token']) {
                notifyService.showInfo('Login first');
                return $location.path('/');
            }

            // Redirect to Home page if not admin
            var admin = authServices.isAdministrator();
            if ((next.originalPath === '/projects' || next.originalPath === '/projects/add'
                || next.originalPath === '/projects/:id/edit') && !admin) {
                return $location.path('/');
            }
        });
    }]);