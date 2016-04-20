'use strict';

angular
    .module('issueTracker.account')
    .directive('confirmPasswordValidation', function () {
            return {
                restrict: 'A',
                require: 'ngModel',
                link: function (scope, element, attrs, controller) {
                    var password = attrs.confirmPasswordValidation;
                    var confirmPassword = attrs.ngModel;
                    scope.$watchGroup([password, confirmPassword], function (value) {
                        var confirmPasswordMatch = value[0] === value[1];
                        controller.$setValidity('confirmPasswordMatch', confirmPasswordMatch)
                    });
                }
            };
        }
    );

