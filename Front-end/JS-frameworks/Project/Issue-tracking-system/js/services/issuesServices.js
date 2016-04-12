'use strict';

angular.module('issueTracker.services.issues', [])
    .factory('issuesServices', ['$http', '$q', 'BASE_URL', function ($http, $q, BASE_URL) {
        function authHeader() {
            return {Authorization: sessionStorage['access_token']};
        }
        
        function getMyIssues(params) {

            var deferred = $q.defer();

            $http.get(BASE_URL + 'Issues/me?pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber + '&orderBy=DueDate desc', {
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