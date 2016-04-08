'use strict';

angular.module('issueTracker.accordion', ['ngAnimate', 'ui.bootstrap'])
    .controller('AccordionController', ['$scope', function ($scope) {
        $scope.status = {
            isFirstOpen: true
        };
    }]);