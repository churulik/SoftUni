'use strict';

angular
    .module('issueTracker.labelsService', [])
    .factory('labelsService', ['$http', '$q', 'BASE_URL', function ($http, $q, BASE_URL) {
            function getLabels() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'labels/?filter=', {headers: {Authorization: sessionStorage['access_token']}})
                    .then(function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            return {
                getLabels: getLabels
            }
        }]
    );
