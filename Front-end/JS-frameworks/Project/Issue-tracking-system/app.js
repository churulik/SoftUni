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
        'issueTracker.labels',
        'issueTracker.navbar',
        'issueTracker.notifyServices',
        'issueTracker.projects'
    ])
    
    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    
    .config(['$routeProvider', 'cfpLoadingBarProvider', function ($routeProvider, cfpLoadingBarProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
        cfpLoadingBarProvider.includeSpinner = false;
    }])
    
    .run(['$rootScope', '$location', 'accountServices', 'notifyServices',
        function ($rootScope, $location, accountServices, notifyServices) {
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
        }]);

