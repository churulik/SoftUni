'use strict';

angular.module('issueTracker.notifyService', [])
    .factory('notifyService', function () {
            function showInfo(message) {
                noty({
                    text: message,
                    type: 'alert',
                    layout: 'bottomRight',
                    timeout: 3000,
                    animation: {
                        open: 'animated fadeInRight',
                        close: 'animated fadeOutRight'
                    }
                });
            }

            function showError(message, serverError) {
                var errors = [];
                if (serverError && serverError.error_description) {
                    errors.push(serverError.error_description);
                }
                if (serverError && serverError.modelState) {
                    var modelStateErrors = serverError.modelState;
                    for (var propertyName in modelStateErrors) {
                        var errorMessages = modelStateErrors[propertyName];
                        var trimmedName = propertyName.substr(propertyName.indexOf('.') + 1);
                        for (var i = 0; i < errorMessages.length; i++) {
                            var currentError = errorMessages[i];
                            errors.push(trimmedName + ' - ' + currentError)
                        }
                    }
                }
                if (errors.length > 0) {
                    message = message + ':<br>' + errors.join('<br>');
                }

                noty({
                    text: message,
                    type: 'error',
                    layout: 'bottomRight',
                    timeout: 5000,
                    animation: {
                        open: 'animated fadeInRight',
                        close: 'animated fadeOutRight'
                    }
                });
            }

            return {
                showInfo: showInfo,
                showError: showError
            }
        }
    );