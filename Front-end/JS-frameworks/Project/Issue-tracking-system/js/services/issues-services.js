'use strict';

angular.module('issueTracker.services.issues', [])
    .factory('issuesServices', ['$http', '$q', '$location', '$route', 'BASE_URL', 'notifyServices',
        function ($http, $q, $location, $route, BASE_URL, notifyServices) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function getMyIssues(params) {
                var deferred = $q.defer();

                $http.get(
                    BASE_URL + 'issues/me?pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber + '&orderBy=DueDate desc',
                    {headers: authHeader()}
                ).then(function (myIssues) {
                    deferred.resolve(myIssues.data);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }

            function getIssueById(id) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'issues/' + id, {headers: authHeader()}
                ).then(function (issue) {
                    deferred.resolve(issue.data);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            }

            function changeStatus(issueId, statusId) {
                $http.put(BASE_URL + 'issues/' + issueId + '/changestatus?statusid=' + statusId,
                    null, {headers: authHeader()}
                ).then(function () {
                    notifyServices.showInfo('Status changed');
                    $route.reload();
                }, function (error) {
                    notifyServices.showError('Fail to change the status', error);
                });
            }

            function redirect() {                
                return $location.path('/');
            }

            function editIssue(issueDate, id) {
                $http.put(BASE_URL + 'issues/' + id, issueDate, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Issue edit successfully');
                        $location.path('/issues/' + id);

                    }, function (error) {
                        notifyServices.showError('Fail to edit the issue', error);
                    });
            }

            function getLabels() {
                var deferred = $q.defer();
                $http.get(BASE_URL + 'labels/?filter=', {headers: authHeader()})
                    .then(function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }
            
            function viewComments(id) {
                var deferred = $q.defer();
                
                $http.get(BASE_URL + 'issues/' + id + '/comments', {headers: authHeader()})
                    .then(function (comments) {
                        deferred.resolve(comments.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                
                return deferred.promise;
            }

            function addComment(comment, id) {
                $http.post(BASE_URL + 'issues/' + id + '/comments', comment, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Your comment is add successfully');
                        $route.reload();
                    }, function (error) {
                        notifyServices.showError('Fail to add your comment', error);
                    });
            }

            return {
                getMyIssues: getMyIssues,
                getIssueById: getIssueById,
                changeStatus: changeStatus,
                editIssue: editIssue,
                viewComments: viewComments,
                addComment: addComment,
                getLabels: getLabels,
                redirect: redirect
            }
        }]);