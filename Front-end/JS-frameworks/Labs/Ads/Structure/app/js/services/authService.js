'use strict';

app.factory('authService',
    function ($http, baseServiceUrl) {
        var currentUserText = 'currentUser';
        return {
            login: function (userData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/user/login',
                    data: userData
                };
                $http(request).success(function (data) {
                    sessionStorage[currentUserText] = JSON.stringify(data);
                    success(data);
                }).error(error);
            },
            register: function (userData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/user/register',
                    data: userData
                };
                $http(request).success(function (data) {
                    sessionStorage[currentUserText] = JSON.stringify(data);
                    success(data);
                }).error(error);
            },
            logout: function () {
                delete sessionStorage[currentUserText];
            },
            getCurrentUser: function () {
                var userObject = sessionStorage[currentUserText];
                if (userObject) {
                    return JSON.parse(userObject)
                }
            },
            isAnonymous: function () {
                return sessionStorage[currentUserText] == undefined;
            },
            isLoggedIn: function () {
                return sessionStorage[currentUserText] != undefined;
            },
            isNormalUser: function () {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (!currentUser.isAdmin);
            },
            isAdmin: function () {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (currentUser.isAdmin);
            },
            getAuthHeaders: function () {
                var headers = {};
                var currentUser = this.getCurrentUser();
                if(currentUser) {
                    headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                }
                return headers;
            }
        }
    }
);
