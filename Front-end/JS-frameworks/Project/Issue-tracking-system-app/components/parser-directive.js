'use strict';

angular.module('issueTracker.parserDirective', [])
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
    
