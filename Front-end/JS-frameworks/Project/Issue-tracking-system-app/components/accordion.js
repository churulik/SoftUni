'use strict';

angular.module('issueTracker.accordion', ['ui.bootstrap'])
    .controller('AccordionController', ['$scope', function ($scope) {
        $scope.status = {
            isFirstOpen: true
        };
    }]);