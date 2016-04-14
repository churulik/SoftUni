'use strict';

angular.module('issueTracker.directives.common', [])
    .directive('toArrayObjectParser', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$parsers.push(function (value) {
                    if (value) {
                        var result = [],
                            valueSplit = value.split(', ');
                        for (var i = 0; i < valueSplit.length; i++) {
                            result.push({Name: valueSplit[i]})
                        }
                        return result;
                    }
                });
            }
        }
    })
    .directive('toStringFormatter', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$formatters.push(function (value) {
                    if(value){
                        var result = [];
                        for (var i = 0; i < value.length; i++) {
                            result.push(value[i].Name);

                        }
                        return result.join(', ');
                    }
                });
            }
        }
    });
