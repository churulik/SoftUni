'use strict';

angular.module('accordion', ['ngAnimate', 'ui.bootstrap'])
    .controller('AccordionController', function ($scope) {       
        $scope.status = {
            isFirstOpen: true
        };
    });