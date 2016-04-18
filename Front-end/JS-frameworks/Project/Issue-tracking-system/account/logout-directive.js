'use strict';

angular
    .module('issueTracker.account')
    .directive('logout', logout);

logout.$inject = ['$location', 'notifyServices'];

function logout($location, notifyServices) {
    return {
        restrict: 'A',
        link: function () {
            sessionStorage.clear();
            notifyServices.showInfo('Successful log out');
            $location.path('/');
        }
    };
}
