'use strict';

angular
    .module('issueTracker.formatterDirective', [])
    .directive('arrayObjectToStringFormatter', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$formatters.push(function (value) {
                    if (value) {
                        var result = [];
                        for (var i = 0; i < value.length; i++) {
                            result.push(value[i].Name);

                        }
                        return result.join(', ');
                    }
                });
            }
        }
    })
    .directive('intToStringFormatter', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, controller) {
                controller.$formatters.unshift(function (value) {
                    if (value) {
                        return value.toString();
                    }
                });
            }
        }
    });