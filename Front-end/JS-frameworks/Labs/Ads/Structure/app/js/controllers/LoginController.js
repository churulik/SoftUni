'use strict';

app.controller('LoginController',
    function ($scope, $rootScope, $location, authService, notifyService) {
        $rootScope.pageTitle = 'Login';
        $scope.login = function (userData) {
            authService.login(userData,
                function success() {
                    notifyService.showInfo('Login successful');
                    $location.path('/');
                },
                function error (error) {
                    notifyService.showError('Unsuccessful login', error)
                }
            )
        }
    }
);