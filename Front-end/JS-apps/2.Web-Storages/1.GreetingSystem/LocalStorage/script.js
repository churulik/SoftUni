$(document).ready(function () {
    const sessionVisits = 'sessionVisits',
        totalVisits = 'totalVisits',
        name = 'name';
    var totalVisitsCount,
        sessionVisitsCount;

    function greeting() {
        $('#form').hide();
        $('#greeting').show()
            .prepend(' Your total visits are: ' + totalVisitsCount)
            .prepend(' Your session visits are: ' + sessionVisitsCount)
            .prepend('Hi ' + localStorage[name] + '.');
    }

    if (localStorage[name]) {
        totalVisitsCount = parseInt(localStorage[totalVisits]);
        totalVisitsCount++;
        localStorage[totalVisits] = totalVisitsCount;

        if (!sessionStorage[sessionVisits]) {
            sessionStorage[sessionVisits] = 0;
        }
        sessionVisitsCount = parseInt(sessionStorage[sessionVisits]);
        sessionVisitsCount++;
        sessionStorage[sessionVisits] = sessionVisitsCount;

        greeting()
    }

    $('#login').click(function () {
        var inputName = $('#name').val().trim();

        if (inputName === '') {
            alert("Enter valid name.");
            throw new Error('Enter valid name')
        }

        localStorage[name] = inputName;
        localStorage[totalVisits] = 0;
    });

    $('#logout').click(function () {
        $('#greeting').hide();
        localStorage.clear();
        sessionStorage.clear();
        $('#form').show();
    });
});



