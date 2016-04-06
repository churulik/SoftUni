'use strict';

angular.module('videoSystem.databaseServices', [])
    .factory('databaseServices', function () {
        function videoSeed() {
            var movie1 = {
                    title: 'The Godfather',
                    pictureUrl: 'https://jmcmerty.files.wordpress.com/2012/11/the-godfather-poster-4.png',
                    length: '3:32',
                    category: 'Action',
                    subscribers: 300000000,
                    date: new Date(2016, 3, 4),
                    rating: 0,
                    haveSubtitles: true,
                    comments: []
                },
                movie2 = {
                    title: 'Gladiator',
                    pictureUrl: 'https://s-media-cache-ak0.pinimg.com/736x/44/31/bd/4431bd4cc9381ba8fe482e83367f3a49.jpg',
                    length: '2:32',
                    category: 'Action',
                    subscribers: 100000000,
                    date: new Date(),
                    rating: 9.09,
                    haveSubtitles: false,
                    comments: [
                        {
                            username: 'Pesho Peshev',
                            content: 'Super film!',
                            date: new Date(),
                            rating: 9,
                            websiteUrl: 'http://pesho.com/'
                        }
                    ]
                },
                movie3 = {
                    title: 'How to train your dragon',
                    pictureUrl: 'http://static2.comicvine.com/uploads/original/11/117787/4452648-4580717005-How-t.jpg',
                    length: '2:00',
                    category: 'Animation',
                    subscribers: 600000,
                    date: new Date(2016, 2, 31),
                    rating: 5.00,
                    haveSubtitles: true,
                    comments: [
                        {
                            username: 'The dragon',
                            content: 'Super film!',
                            date: new Date(2016, 12, 15, 12, 30, 0),
                            rating: 5,
                            websiteUrl: 'http://dragon.com/'
                        }
                    ]
                },
                movie4 = {
                    title: 'Bridge of spice',
                    pictureUrl: 'http://2.bp.blogspot.com/-Zkm2BW3Ap9I/VecDmy2TIII/AAAAAAAAel0/U6EspFBcTXw/s1600/Bridge%2Bof%2BSpies%2BLaunch%2BOne%2BSheet.jpg',
                    length: '1:50',
                    category: 'Drama',
                    subscribers: 50000,
                    date: new Date(2016, 1, 31),
                    rating: 6.00,
                    haveSubtitles: true,
                    comments: [
                        {
                            username: 'Bejka',
                            content: 'Super film!',
                            date: new Date(2016, 12, 15, 12, 30, 0),
                            rating: 2,
                            websiteUrl: 'http://bejka.com/'
                        },
                        {
                            username: 'Gibo',
                            content: 'Evala!',
                            date: new Date(2016, 12, 15, 12, 30, 0),
                            rating: 10,
                            websiteUrl: 'http://gibo.com/'
                        }
                    ]
                };

            sessionStorage['database'] = JSON.stringify([movie1, movie2, movie3, movie4]);
        }

        function retrieveData() {
            return JSON.parse(sessionStorage['database']);
        }

        function retrieveDataByTitle(titleName) {
            var database = JSON.parse(sessionStorage['database']);
            return database.filter(function (video) {
                return video.title == titleName
            })[0];
        }

        function pushData(data) {
            var database = JSON.parse(sessionStorage['database']);
            database.push(data);
            sessionStorage['database'] = JSON.stringify(database);
        }

        function pushComment(video, comment) {
            var database = JSON.parse(sessionStorage['database']);
            var getVideo = database.filter(function (currentVideo) {
                return currentVideo.title == video.title
            })[0];

            getVideo['comments'].push(comment);
            var videoCommentsCount = getVideo['comments'].length;
            //Update video rating
            getVideo.rating = (((Number(getVideo.rating) * (videoCommentsCount - 1)) + Number(comment.rating)) / videoCommentsCount).toFixed(2);

            sessionStorage['database'] = JSON.stringify(database);
        }

        return {
            videoSeed: videoSeed,
            retrieveData: retrieveData,
            retrieveDataByTitle: retrieveDataByTitle,
            pushData: pushData,
            pushComment: pushComment
        }
    });
