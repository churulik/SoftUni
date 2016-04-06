'use strict';

angular.module('videoSystem', ['ngRoute',
        'videoSystem.home',
        'videoSystem.video',
        'videoSystem.databaseServices',
        'videoSystem.filterServices',
        'videoSystem.videoDetails'
    ])
    .constant('VIDEO_CATEGORIES',
        ['Action', 'Adventure', 'Animation', 'Comedy', 'Criminal', 'Computers', 'Drama', 'Fantasy', 'Horror', 'Musical', 'Thriller'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({
            redirectTo: '/'
        })
    }]);
   
    