'use strict';

angular.module('videoSystem.video', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/add-video', {
            templateUrl: 'templates/add-video.html',
            controller: 'VideoController'
        })
    }])
    .controller('VideoController', ['$scope', '$location', 'databaseServices', 'VIDEO_CATEGORIES',
        function ($scope, $location, databaseServices, VIDEO_CATEGORIES) {
            $scope.categories = VIDEO_CATEGORIES;
            
            $scope.videoData = {
                
                haveSubtitles: 'true'
            };

            $scope.addVideo = function (videoData) {
                videoData['date'] = new Date();
                videoData['rating'] = 0;
                videoData['comments'] = [];
                databaseServices.pushData(videoData);
                noty({
                    layout: 'topCenter',
                    type: 'warning',
                    text: videoData.title + ' was add',
                    timeout: 4000,
                    close: ['click']
                });
                $location.path('/');
            };        
        }]
    );
    
