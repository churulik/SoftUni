'use strict';

app.controller('UserAdsController',
    function ($scope, $rootScope, userService, notifyService, pageSize) {
        $rootScope.pageTitle = 'My Ads';

        $scope.adsParams = {
            startPage: 1,
            pageSize: pageSize
        };

        $scope.reloadAds = function () {
            userService.getUserAds(
                $scope.adsParams,
                function success(data) {
                    $scope.ads = data;
                },
                function error(error) {
                    notifyService.showError('Cannot load ads', error)
                }
            );
        };


        $scope.reloadAds();

        $scope.$on('categorySelectionChanged', function (event, selectedCategoryId) {
            $scope.adsParams.categoryId = selectedCategoryId;
            $scope.adsParams.startPage = 1;
            $scope.reloadAds();
        });

        $scope.$on('townSelectionChanged', function (event, selectedtownId) {
            $scope.adsParams.townId = selectedtownId;
            $scope.adsParams.startPage = 1;
            $scope.reloadAds();
        });
    }
);
