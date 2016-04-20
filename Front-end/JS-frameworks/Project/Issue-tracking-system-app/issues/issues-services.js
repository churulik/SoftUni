'use strict';

angular
    .module('issueTracker.issuesServices', [])
    .factory('issuesServices', ['$http', '$q', '$location', '$route', 'BASE_URL', 'notifyServices',
        function ($http, $q, $location, $route, BASE_URL, notifyServices) {
            function authHeader() {
                return {Authorization: sessionStorage['access_token']};
            }

            function addComment(comment, id) {
                $http.post(BASE_URL + 'issues/' + id + '/comments', comment, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Your comment is add');
                        $route.reload();
                    }, function (error) {
                        notifyServices.showError('Fail to add your comment', error);
                    });
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

            function editIssue(issueDate, id) {
                $http.put(BASE_URL + 'issues/' + id, issueDate, {headers: authHeader()})
                    .then(function () {
                        notifyServices.showInfo('Issue edit successfully');
                        $location.path('/issues/' + id);

                    }, function (error) {
                        notifyServices.showError('Fail to edit the issue', error);
                    });
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

            function getMyIssues(params) {
                var deferred = $q.defer();

                $http.get(
                    BASE_URL + 'issues/me?pageSize=' + params.itemsPerPage + '&pageNumber=' + params.pageNumber + '&orderBy=DueDate desc',
                    {headers: authHeader()}
                ).then(function (myIssues) {
                    deferred.resolve(myIssues.data);
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

            return {
                addComment: addComment,
                editIssue: editIssue,
                changeStatus: changeStatus,
                getIssueById: getIssueById,
                getMyIssues: getMyIssues,
                viewComments: viewComments
            }
        }]);