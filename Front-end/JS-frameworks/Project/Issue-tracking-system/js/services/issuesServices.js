'use strict';

angular.module('issueTracker.services.issues', [])
    .factory('issuesServices', ['$http', '$q', '$location', 'BASE_URL', 'notifyService',
        function ($http, $q, $location, BASE_URL, notifyService) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function getMyIssues(params) {

                var deferred = $q.defer();

                $http.get(BASE_URL + 'issues/me?pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber + '&orderBy=DueDate desc', {
                    headers: authHeader()
                }).then(function (myIssues) {
                    deferred.resolve(myIssues.data);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }            

            return {
                getMyIssues: getMyIssues                
            }
        }]);