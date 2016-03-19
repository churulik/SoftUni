Array.prototype.flatten = function () {
    var arrayResult = [];
    flatten(this);

    function flatten(array) {
        var length = array.length;
        for (var i = 0; i < length; i++) {
            var element = array[i];
            if (Array.isArray(element)) {
                flatten(element);
                continue;
            }

            arrayResult.push(element);
        }
    }

    return arrayResult;
};

var array;
array = [1, 2, 3, 4];
console.log(array.flatten());

array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed


array = [undefined, 0, ['string', 'values'], 5.5, [[1, 2, true], [3, 4, false]], 10, {}, null, ' '];
console.log(array.flatten());