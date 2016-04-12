'use strict';

angular.module('issueTracker.services.issues', [])
    .factory('issuesServices', ['$http', '$q', 'BASE_URL', function ($http, $q, BASE_URL) {
        function authHeader() {
            return {Authorization: sessionStorage['access_token']};
        }
        
        function getMyIssues(pageSize) {
            pageSize = pageSize || 10;
            var deferred = $q.defer();

            $http.get(BASE_URL + 'Issues/me?pageSize=' + pageSize + '&pageNumber=1&orderBy=DueDate desc', {
                headers: authHeader()
            }).then(function (myIssues) {
                deferred.resolve(myIssues.data.Issues);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }
        
        return {
            getMyIssues: getMyIssues
        }
    }]);