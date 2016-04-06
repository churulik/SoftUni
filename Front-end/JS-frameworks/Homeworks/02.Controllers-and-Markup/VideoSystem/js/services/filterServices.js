'use strict';

angular.module('videoSystem.filterServices', [])
    .factory('filterServices', function () {
        function filterByDate($scope, day) {
            var dateNow = new Date();
            if (day === 'today') {
                $scope.dateFilter = function (video) {
                    var videoDate = new Date(video.date);
                    return videoDate.toDateString() === dateNow.toDateString();
                };
            } else if (day === 'lastThreeDays') {
                dateNow.setDate(dateNow.getDate() - 3);
                $scope.dateFilter = function (video) {
                    var videoDate = new Date(video.date);
                    return videoDate.getTime() >= dateNow.getTime();
                };
            } else if (day === 'thisWeek') {
                dateNow.setDate(dateNow.getDate() - 7);
                $scope.dateFilter = function (video) {
                    var videoDate = new Date(video.date);
                    return videoDate.getTime() >= dateNow.getTime();
                };
            } else if (day === 'thisMonth') {
                dateNow.setMonth(dateNow.getMonth() - 1);
                $scope.dateFilter = function (video) {
                    var videoDate = new Date(video.date);
                    return videoDate.getTime() >= dateNow.getTime();
                };
            } else if (day === 'all') {
                $scope.dateFilter = function (video) {
                    return video;
                };
            }
        }

        function categoryFilter($scope, category) {
            $scope.categoryFilter = function (video) {
                if (category == 'all') {
                    return video;
                }
                return video.category === category;
            }
        }

        function haveSubtitlesFilter($scope, haveSubtitles) {
            if (haveSubtitles == 'true') {
                $scope.haveSubtitleFilter = function (video) {
                    return video.haveSubtitles == true;
                }
            } else if (haveSubtitles == 'false') {
                $scope.haveSubtitleFilter = function (video) {
                    return video.haveSubtitles == false;
                }
            } else if (haveSubtitles == 'all') {
                $scope.haveSubtitleFilter = function (video) {
                    return video;
                }
            }
        }

        return {
            filterByDate: filterByDate,
            categoryFilter: categoryFilter,
            haveSubtitlesFilter: haveSubtitlesFilter
        }
    });
