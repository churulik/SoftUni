'use strict';

angular.module('issueTracker.services.projects', [])
    .factory('projectsServices', ['$http', '$q', '$location', 'BASE_URL', 'notifyService',
        function ($http, $q, $location, BASE_URL, notifyService) {
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

            function editProject(projectData, id) {
                $http.put(BASE_URL + 'projects/' + id, projectData, {headers: authHeader()})
                    .then(function (response) {
                        console.log(response);
                        notifyService.showInfo('Project edit successfully');
                        $location.path('/projects/' + id)

                    }, function (error) {
                        notifyService.showError('Fail to edit the project', error);
                    })
            }

            return {
                getAllProjects: getAllProjects,
                getProjectById: getProjectById,
                getProjectIssues: getProjectIssues,
                editProject: editProject
            }
        }]);
