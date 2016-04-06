'use strict';

angular.module('videoSystem.home', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'templates/home.html',
            controller: 'HomeController'
        });
    }])
    .controller('HomeController', ['$scope', 'VIDEO_CATEGORIES', 'databaseServices', 'filterServices',
        function ($scope, VIDEO_CATEGORIES, databaseServices, filterServices) {
            if (!sessionStorage['database']) {
                databaseServices.videoSeed();
            }
            $scope.categories = VIDEO_CATEGORIES;

            $scope.videoData = databaseServices.retrieveData();

            $scope.videoOrderBy = function (parametar) {
                $scope.parametar = parametar;
            };

            $scope.videoCategory = function (category) {
                filterServices.categoryFilter($scope, category)
            };

            $scope.videoDate = function (day) {
                filterServices.filterByDate($scope, day);
            };

            $scope.videoHaveSubtitles = function (haveSubtitles) {
                filterServices.haveSubtitlesFilter($scope, haveSubtitles);
            }
        }]);
    
