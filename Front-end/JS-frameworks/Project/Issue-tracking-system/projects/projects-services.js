'use strict';

angular
    .module('issueTracker.projectsServices', [])
    .factory('projectsServices', ['$http', '$q', '$location', 'BASE_URL', 'notifyServices',
        function ($http, $q, $location, BASE_URL, notifyServices) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function getAllProjects() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'projects', {headers: authHeader()})
                    .then(function (projects) {
                        deferred.resolve(projects.data);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function getProjectById(id) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'projects/' + id, {headers: authHeader()})
                    .then(function (project) {
                        deferred.resolve(project.data);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function getProjectIssues(id) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'projects/' + id + '/issues', {headers: authHeader()})
                    .then(function (issuses) {
                        deferred.resolve(issuses.data);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function addProject(projectData) {
                $http.post(BASE_URL + 'projects', projectData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Project add successfully');
                        $location.path('/projects');
                    }, function (error) {
                        notifyServices.showError('Fail to add the project', error);
                    });
            }

            function editProject(projectData, id) {
                $http.put(BASE_URL + 'projects/' + id, projectData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Project edit successfully');
                        $location.path('/projects/' + id);
                    }, function (error) {
                        notifyServices.showError('Fail to edit the project', error);
                    });
            }

            function addIssue(issueData) {
                $http.post(BASE_URL + 'issues', issueData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Issue add successfully');
                        $location.path('/');
                    }, function (error) {
                        notifyServices.showError('Fail to add the issue', error);
                    });
            }

            return {
                getAllProjects: getAllProjects,
                getProjectById: getProjectById,
                getProjectIssues: getProjectIssues,
                addProject: addProject,
                editProject: editProject,
                addIssue: addIssue
            }
        }]);
