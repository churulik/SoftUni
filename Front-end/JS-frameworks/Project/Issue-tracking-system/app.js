'use strict';

angular
    .module('issueTracker', [
        'ngAnimate',
        'ngRoute',
        'ngTagsInput',
        'angular-loading-bar',
        'issueTracker.accordion',
        'issueTracker.account',       
        'issueTracker.dashboard',
        'issueTracker.home',
        'issueTracker.issues',
        'issueTracker.navbar',
        'issueTracker.notifyServices',
        'issueTracker.projects'
    ])
    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .config(route)
    .run(redirect);

redirect.$inject = ['$rootScope', '$location', 'notifyServices', 'accountServices'];
route.$inject = ['$routeProvider', 'cfpLoadingBarProvider'];

function redirect($rootScope, $location, notifyServices, accountServices) {
    $rootScope.$on("$routeChangeStart", function (event, next) {

        // Redirect to Home page if not logged in
        if (next.originalPath !== '/' && !sessionStorage['access_token']) {
            notifyServices.showInfo('Login first');
            return $location.path('/');
        }

        // Redirect to Home page if not admin
        var admin = accountServices.isAdministrator();
        if ((next.originalPath === '/projects' || next.originalPath === '/projects/add') && !admin) {
            return $location.path('/');
        }
    });
}

function route($routeProvider, cfpLoadingBarProvider) {
    $routeProvider.otherwise({redirectTo: '/'});
    cfpLoadingBarProvider.includeSpinner = false;
}

