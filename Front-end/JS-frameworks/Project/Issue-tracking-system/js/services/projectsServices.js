'use strict';

angular.module('issueTracker.services.projects', [])
    .factory('projectsServices', ['$http', '$q', 'BASE_URL', function ($http, $q, BASE_URL) {
        function authHeader() {
            return {Authorization: sessionStorage['access_token']};
        }

        function getAllProjects() {
            var deferred = $q.defer();

            $http.get(BASE_URL + 'projects', {
                headers: authHeader()
            }).then(function (projects) {
                deferred.resolve(projects.data);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }

        function getProjectById(id) {
            var deferred = $q.defer();

            $http.get(BASE_URL + 'projects/' + id, {
                headers: authHeader()
            }).then(function (project) {
                deferred.resolve(project.data);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }

        function getProjectIssues(id) {
            var deferred = $q.defer();

            $http.get(BASE_URL + 'projects/' + id + '/issues', {
                headers: authHeader()
            }).then(function (issuses) {
                deferred.resolve(issuses.data);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }

        return {
            getAllProjects: getAllProjects,
            getProjectById: getProjectById,
            getProjectIssues: getProjectIssues
        }
    }]);
