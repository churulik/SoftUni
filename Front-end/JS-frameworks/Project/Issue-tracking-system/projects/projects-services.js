'use strict';

angular
    .module('issueTracker.projectsServices', [])
    .factory('projectsServices', ['$http', '$q', '$location', '$route', 'BASE_URL', 'notifyServices',
        function ($http, $q, $location, $route, BASE_URL, notifyServices) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function addIssue(issueData, projectId) {
                $http.post(BASE_URL + 'issues', issueData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Issue add successfully');
                        if ($location.url().split('/')[3] === 'add-issue') {
                            $location.path('/projects/' + projectId);
                        } else {
                            $route.reload();
                        }
                    }, function (error) {
                        notifyServices.showError('Fail to add the issue', error);
                    });
            }

            function addProject(projectData) {
                $http.post(BASE_URL + 'projects', projectData, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Project add successfully');
                        if ($location.url().split('/')[2] === 'add') {
                            $location.path('/');
                        } else {
                            $route.reload();
                        }
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

            return {
                addIssue: addIssue,
                addProject: addProject,
                editProject: editProject,
                getAllProjects: getAllProjects,
                getProjectById: getProjectById,
                getProjectIssues: getProjectIssues
            }
        }]);
