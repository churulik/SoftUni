'use strict';

angular.module('issueTracker.filterByDateService', [])
    .factory('filterByDateService', function () {
        function filter($scope, day) {
            var dateNow = new Date(),
                issueDate;

            function returnFilteredDate($scope) {
                $scope.dateFilter = function (issue) {
                    issueDate = new Date(issue.DueDate);
                    return issueDate.getTime() <= dateNow.getTime();
                };
            }
            
            if (day === 'Today') {
                $scope.dateFilter = function (issue) {
                    issueDate = new Date(issue.DueDate);
                    return issueDate.toDateString() === dateNow.toDateString();
                };
            } else if (day === 'InThreeDays') {
                dateNow.setDate(dateNow.getDate() + 3);
                returnFilteredDate($scope);
            } else if (day === 'InFiveDays') {
                dateNow.setDate(dateNow.getDate() + 5);
                returnFilteredDate($scope);
            } else if (day === 'InOneWeek') {
                dateNow.setDate(dateNow.getDate() + 7);
                returnFilteredDate($scope);
            } else if (day === 'InTenDays') {
                dateNow.setDate(dateNow.getDate() + 10);
                returnFilteredDate($scope);
            } else if (day === 'InTwoWeeks') {
                dateNow.setDate(dateNow.getDate() + 14);
                returnFilteredDate($scope);
            } else if (day === 'All') {
                $scope.dateFilter = function (issue) {
                    return issue;
                };
            }
        }

        return {
            filter: filter
        }
    });

