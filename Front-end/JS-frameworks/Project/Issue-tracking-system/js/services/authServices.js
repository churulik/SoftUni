'use strict';

angular.module('issueTracker.authServices', [])
    .factory('authServices', ['$http', 'BASE_URL', 'notifyService', function ($http, BASE_URL, notifyService) {
        function register(registerData) {
            $http({
                method: 'POST',
                url: BASE_URL + 'users/register',
                data: JSON.stringify(registerData)
            }).then(function (response) {
                notifyService.showInfo('Successful registration');
                console.log(response.data)
            }, function (error) {
                notifyService.showError('Unsuccessful registration', error);
                console.log(error)
            });
        }
        
        return {
            register: register
        }
    }]);
