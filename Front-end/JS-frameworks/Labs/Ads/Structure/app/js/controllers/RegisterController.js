'use strict';

app.controller('RegisterController',
    function ($scope,$rootScope, $location, townsService, authService, notifyService) {
        $rootScope.pageTitle = 'Register';

        $scope.userData = {townId: null};
        $scope.towns = townsService.getTowns();

        $scope.register = function (userData) {
            authService.register(userData,
                function success() {
                    notifyService.showInfo('Registration successful');
                    $location.path('/');
                },
                function error(error) {
                    notifyService.showError('Unsuccessful registration', error)
                }
            )
        }
    }
);