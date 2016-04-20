'use strict';

angular
    .module('issueTracker.accountServices', [])
    .factory('accountServices', ['$http', '$q', '$location', 'BASE_URL', 'notifyServices',
        function ($http, $q, $location, BASE_URL, notifyServices) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function changePassword(changePasswordData) {
                $http.post(BASE_URL + 'api/account/changePassword', changePasswordData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Password changed');
                        $location.path('/');
                    }, function (error) {
                        notifyServices.showError('Fail to change the password', error);
                    })
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

            function getUserInfo() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'users/me', {
                    headers: authHeader()
                }).then(function (response) {
                    sessionStorage['username'] = response.data.Username;
                    sessionStorage['userInfo'] = JSON.stringify(response.data);
                    deferred.resolve(response.data);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }

            function isAdministrator() {
                var userInfo = sessionStorage['userInfo'];
                if (userInfo) {
                    var parseUserInfo = JSON.parse(userInfo);
                    return parseUserInfo.isAdmin;
                }
            }

            function isAuthenticated() {
                return sessionStorage['access_token'];
            }

            function login(loginData) {
                var deferred = $q.defer();

                $http.post(BASE_URL + 'api/token', $.param(loginData), {
                    headers: {'Content-Type': 'application/x-www-form-urlencoded'}
                }).then(function (response) {
                    sessionStorage['access_token'] = 'Bearer ' + response.data.access_token;
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

            return {
                changePassword: changePassword,
                getAllUsers: getAllUsers,
                getCurrentUser: getCurrentUser,
                getUserInfo: getUserInfo,
                isAdministrator: isAdministrator,
                isAuthenticated: isAuthenticated,
                login: login,
                register: register
            }
        }]
    );

