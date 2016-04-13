'use strict';

angular.module('issueTracker.services.authServices', [])
    .factory('authServices', ['$http', '$q', '$location', 'BASE_URL', 'notifyService',
        function ($http, $q, $location, BASE_URL, notifyService) {
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

            function changePassword(changePasswordData) {
                $http.post(BASE_URL + 'api/account/changePassword', changePasswordData, {headers: authHeader()})
                    .then(function (response) {
                        notifyService.showInfo('Successfully password change');
                        $location.path('/');
                    }, function (error) {
                        notifyService.showError('Unsuccessful password change', error);
                    })
            }

            function isAuthenticated() {
                return sessionStorage[accessToken];
            }

            function getUserInfo() {
                $http.get(BASE_URL + 'users/me', {
                    headers: authHeader()
                }).then(function (response) {
                    sessionStorage['userInfo'] = JSON.stringify(response.data);
                }, function (error) {
                    console.log(error);
                });
            }

            function isAdministrator() {
                var userInfo = sessionStorage['userInfo'];
                if (userInfo) {
                    var parseUserInfo = JSON.parse(userInfo);
                    return parseUserInfo.isAdmin;
                }
            }

            function getAllUsers() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'users', {
                    headers: authHeader()
                }).then(function (users) {
                    deferred.resolve(users.data);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }

            function getCurrentUser() {
                var userInfo = sessionStorage['userInfo'];
                if (userInfo) {
                    var parseUserInfo = JSON.parse(userInfo);
                    return parseUserInfo.Username;
                }
            }

            return {
                login: login,
                register: register,
                changePassword: changePassword,
                getUserInfo: getUserInfo,
                isAuthenticated: isAuthenticated,
                isAdministrator: isAdministrator,
                getAllUsers: getAllUsers,
                getCurrentUser: getCurrentUser
            }
        }]);
