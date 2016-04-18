'use strict';

angular
    .module('issueTracker.account')
    .directive('logout', ['$location', 'notifyServices', function ($location, notifyServices) {
            return {
                restrict: 'A',
                link: function () {
                    sessionStorage.clear();
                    notifyServices.showInfo('Successful log out');
                    $location.path('/');
                }
            };
        }]
    );

