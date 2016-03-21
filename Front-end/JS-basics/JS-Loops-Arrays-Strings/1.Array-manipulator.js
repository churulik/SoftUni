/**
 * You are given an array of objects.
 * Your task is to write a JavaScript code that filters out
 * the numbers of that array (removes all non-number objects).
 * Then you should: 1. Find the Min number, 2. Find the Max number, 3.
 * Find the most frequent number.
 * Finally you should print out the numbers you have found and
 * the filtered array sorted in descending order.
 */

function arrayManipulator(input) {

    var filter = input.filter (
        function(num) {
            return (typeof num === "number");
        }
    );

    var minNum = Math.min.apply(null, filter);
    var maxNum = Math.max.apply(null, filter);

    var mostFreqNum = findMostFreqNum();

    filter.sort(function (a, b) {
        return a < b
    });

    function findMostFreqNum(){
        var frequency = {};
        var max = 0;
        var result;

        for (var filteredNum in filter) {
            frequency[filter[filteredNum]] = (frequency[filter[filteredNum]] || 0) + 1;
            if (frequency[filter[filteredNum]] > max) {
                max = frequency[filter[filteredNum]];
                result = filter [filteredNum];
            }
        }

        return result;
    }



    console.log('Min number: '+ minNum);
    console.log('Max number: ' + maxNum);
    console.log('Most frequent number: '+ mostFreqNum);
    console.log(filter);
}

arrayManipulator(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0,
    "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);