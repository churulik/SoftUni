'use strict';

angular
    .module('issueTracker.account')
    .directive('logout', ['$location', 'notifyServices', function ($location, notifyServices) {
            return {
                restrict: 'A',
                link: function () {
                    notifyServices.showInfo('See you later ' + sessionStorage['username'].split('@')[0]);
                    sessionStorage.clear();
                    $location.path('/');
                }
            };
        }]
    );

