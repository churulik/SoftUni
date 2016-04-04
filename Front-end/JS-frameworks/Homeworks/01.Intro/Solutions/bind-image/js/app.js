angular.module('image', [])
    .controller('ImageController', ['$scope', function ($scope) {
        $scope.img = '';
        $scope.regex = /\.(jpeg|jpg|gif|png|ico)$/;
    }]);
