'use strict';

angular
    .module('issueTracker.labels', ['issueTracker.labelsService'])
    .controller('LabelsController', ['$scope', 'labelsService', function ($scope, labelsService) {
        $scope.initGetAllLabels = function () {
            labelsService.getLabels().then(function (response) {
                $scope.loadLabels = function ($query) {
                    return response.filter(function (label) {
                        return label.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
                    });
                };
            });
        };
    }]);