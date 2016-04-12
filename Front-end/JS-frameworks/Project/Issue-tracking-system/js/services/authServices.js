'use strict';

angular.module('issueTracker.services.authServices', [])
    .factory('authServices', ['$http', '$q', 'BASE_URL',
        function ($http, $q, BASE_URL) {
            var accessToken = 'access_token';
            var username = 'username';

            function authHeader() {
                return {Authorization: sessionStorage[accessToken]};
            }

            function login(loginData) {
                var deferred = $q.defer();

                $http.post(BASE_URL + 'api/token', $.param(loginData), {
                    headers: {'Content-Type': 'application/x-www-form-urlencoded'}
                }).then(function (response) {
                    sessionStorage[username] = response.data.userName;
                    sessionStorage[accessToken] = 'Bearer ' + response.data.access_token;
                    deferred.resolve(response);
                }, function (error) {
                    deferred.reject(error)
                });

                return deferred.promise;
            }

            function register(registerData) {
                var deferred = $q.defer();

                $http.post(BASE_URL + 'api/account/register', registerData)
                    .then(function (response) {
                        deferred.resolve(response);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function isAuthenticated() {
                return sessionStorage[accessToken];
            }

            function isAdministrator() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'users/me', {
                    headers: authHeader()
                }).then(function (response) {
                    deferred.resolve(response.data.isAdmin);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }

            // function getAllUsers() {
            //     var deferred = $q.defer();
            //
            //     $http.get(BASE_URL + 'users', {
            //         headers: authHeader()
            //     }).then(function (users) {
            //         deferred.resolve(users.data);
            //     }, function (error) {
            //         deferred.reject(error);
            //     });
            //
            //     return deferred.promise;
            // }


            return {
                login: login,
                register: register,
                isAuthenticated: isAuthenticated,
                isAdministrator: isAdministrator,
                // getAllUsers: getAllUsers
            }
        }]);
