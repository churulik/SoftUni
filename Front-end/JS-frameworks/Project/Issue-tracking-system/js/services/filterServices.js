'use strict';

angular.module('issueTracker.services.filter', [])
    .factory('filterServices', function () {
        function filterByDueDate($scope, day) {
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
            } else if (day === 'ThisWeek') {
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

        function filterByStatus($scope, status) {
            $scope.statusFilter = function (issue) {
                if ($scope.statusOpen && $scope.statusInProgress && $scope.statusStoppedProgress && $scope.statusClosed) {
                    return issue.Status.Name;
                }

                if ($scope.statusOpen && $scope.statusInProgress && $scope.statusStoppedProgress && $scope.statusClosed) {
                    return issue.Status.Name;
                }

                if ($scope.statusOpen && $scope.statusInProgress) {
                    return issue.Status.Name === 'Open' || issue.Status.Name === 'InProgress';
                }

                if ($scope.statusOpen) {
                    return issue.Status.Name === 'Open';
                }

                if ($scope.statusInProgress) {
                    return issue.Status.Name === 'InProgress';
                }

                if ($scope.statusStoppedProgress) {
                    return issue.Status.Name === 'StoppedProgress';
                }

                if ($scope.statusClosed) {
                    return issue.Status.Name === 'Closed';
                }

                return issue.Status.Name;
            };
        }

        return {
            filterByDueDate: filterByDueDate,
            filterByStatus: filterByStatus
        }
    });

