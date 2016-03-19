$(document).ready(function () {
    const fiveMinutes = 60 * 5,
        display = $('#time'),
        time = 'time',
        answers = ['Google', '1975', 'Netscape'],
        questionsCount = $('.question').length,
        answer = 'answer',
        correct = 'correct',
        incorrect = 'incorrect';
    var interval;

    //Timer
    function startTime(duration, display) {
        function countdown() {
            var minutes,
                seconds,
                timer = localStorage[time] ? localStorage[time] : duration;
            minutes = parseInt(timer / 60, 10);
            seconds = parseInt(timer % 60, 10);

            minutes = minutes < 10 ? '0' + minutes : minutes;
            seconds = seconds < 10 ? '0' + seconds : seconds;

            display.text(minutes + ':' + seconds + ' minutes');

            if (timer == 0) {
                clearInterval(interval);
                display.text(minutes + ':' + seconds + ' minutes').css('color', 'red');
                $('#submit').hide();
                $('#reset').show();
            } else {
                timer--;
            }

            localStorage[time] = timer;
        }

        countdown();

        interval = setInterval(countdown, 1000);
    }

    startTime(fiveMinutes, display);

    //Save answers
    for (var i = 1; i <= questionsCount; i++) {
        (function () {
            var number = i;
            $('input:radio[name=q' + number + ']').click(function () {
                localStorage[answer + number] = $('input:radio[name=q' + number + ']:checked').val();
            });

            if (localStorage[answer + number]) {
                $('input:radio[value=' + localStorage[answer + number] + ']').prop('checked', true)
            }
        })();
    }

    //Display answers
    function displayAnswers(answerNumber, givenAnswer, correctAnswer) {
        $('#answers').show();
        if (givenAnswer == correctAnswer) {
            $('#a' + answerNumber).show().text('Q' + answerNumber + ': ' + correct).css('color', 'forestgreen');
        } else {
            $('#a' + answerNumber).show().text('Q' + answerNumber + ': ' + incorrect).css('color', 'darkred');
        }
    }

    //Submit questions
    $('#submit').click(function () {
        var results = $('form').serialize().split('&');
        if (results.length == questionsCount) {
            $.ajax({
                type: 'post',
                url: '',
                success: function () {
                    clearInterval(interval);
                    for (var i = 1; i <= questionsCount; i++) {
                        displayAnswers(i, localStorage[answer + i], answers[i - 1]);
                    }
                    localStorage.clear();
                    $('#submit').hide();
                    $('#reset').show();
                }
            });

            return false;
        }
    });

    //Reset questions
    $('#reset').click(function () {
        localStorage.clear();
        location.reload();
    })
});
