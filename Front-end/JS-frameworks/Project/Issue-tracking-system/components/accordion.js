'use strict';

angular.module('issueTracker.repository.accordion', ['ui.bootstrap'])
    .controller('AccordionController', ['$scope', function ($scope) {
        $scope.status = {
            isFirstOpen: true
        };
    }]);