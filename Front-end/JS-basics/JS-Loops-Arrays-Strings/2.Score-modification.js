/**
 * You are given an array of numbers.
 * Your tasks are to first filter out all valid exam scores (between 0 and 400)
 * and afterwards scale them downwards by removing 20% out of each score.
 * Finally you should print out the changed scores sorted in ascending order.
 */


function scoreModification(input){
    function  filterOut(numbers){
        return numbers > 0 && numbers < 400;
    }

    var filter = input.filter(filterOut);

    function calculate() {
        for (var i = 0; i < filter.length; i++) {
            filter[i] = filter[i] -  (filter[i] * (20 / 100));
        }
        filter.sort(function(a, b){
            return a > b;
        });

        return filter;
    }
    console.log (calculate());

}

scoreModification([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);