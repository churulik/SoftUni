'use strict';

angular.module('issueTracker.services.notifyService', [])
    .factory('notifyService', function () {
            function showInfo(message) {
                noty({
                    text: message,
                    type: 'success',
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
                if (serverError ) {
                    if (serverError.data.ModelState) {
                        var modelStateErrors = serverError.data.ModelState;
                        for (var propertyName in modelStateErrors) {
                            var errorMessages = modelStateErrors[propertyName];
                            for (var i = 0; i < errorMessages.length; i++) {
                                var currentError = errorMessages[i];
                                errors.push(currentError)
                            }
                        }
                    }

                    if (serverError.data.error_description) {
                        errors.push(serverError.data.error_description)
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
