'use strict';

angular.module('issueTracker.filters.common', [])
    .filter('uniqueObject', function () {
        return function (collection, key, value) {
            var output = [],
                keys = [];
            angular.forEach(collection, function (obj) {
                var item = obj[key][value];
                
                if (keys.indexOf(item) === -1) {
                    keys.push(item);
                    output.push(obj);
                }
            });

            return output;
        };
    });