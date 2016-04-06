'use strict';

angular.module('videoSystem.videoDetails', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/video-details/:title', {
            templateUrl: 'templates/video-details.html',
            controller: 'VideoDetailsController'
        });
    }])
    .controller('VideoDetailsController', ['$scope', '$routeParams', '$location', 'databaseServices',
        function ($scope, $routeParams, $location, databaseServices) {
            if (!sessionStorage['database']) {
                databaseServices.videoSeed();
            }
            
            var video = databaseServices.retrieveDataByTitle($routeParams.title);
            $scope.video = video;

            $scope.submitComment = function (comment) {
                comment['date'] = new Date();
                databaseServices.pushComment(video, comment);
                noty({
                    layout: 'topCenter',
                    type: 'alert',
                    text: 'The comment is add',
                    timeout: 4000,
                    close: ['click']
                });

                $location.path('/')
            };

        }]);