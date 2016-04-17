'use strict';

angular.module('issueTracker.controllers.base', [])
    .controller('BaseController', ['$scope', 'authServices', function ($scope, authServices) {
                $scope.isAuthenticated = authServices.isAuthenticated();
        }]);