/**
 * You are given a JSON string containing an array of Students (Objects).
 * Your task is to scale their scores upwards by increasing them with 10%.
 * After that you should add a field that shows whether the student has passed or
 * failed the exam (passed exam means 100 or more points at the exam).
 * Finally you should filter out only the students that have passed the exam and
 * print them out sorted alphabetically.
 */

function courseGradeScaling (input) {

    for (var i in input) {
        input[i].score = input[i].score + (input[i].score * (10 / 100));

        var element = input[i];
        element.hasPassed = true;

    }


    var filter = input.filter (function (sc){
           return sc.score > 100;
    });


    var sort_by = function(field, reverse, primer){

        var key = primer ?
            function(x) {return primer(x[field])} :
            function(x) {return x[field]};

        reverse = !reverse ? 1 : -1;

        return function (a, b) {
            return a = key(a), b = key(b), reverse * ((a > b) - (b > a));
        }
    };
    var sort =  filter.sort(sort_by ('name'));

    console.log (JSON.stringify(sort));
}

courseGradeScaling (
    [
        {
            'name' : 'Пешо',
            'score' : 91
        },
        {
            'name' : 'Лилия',
            'score' : 290
        },
        {
            'name' : 'Алекс',
            'score' : 343
        },
        {
            'name' : 'Габриела',
            'score' : 400
        },
        {
            'name' : 'Жичка',
            'score' : 70
        }
    ]
);
