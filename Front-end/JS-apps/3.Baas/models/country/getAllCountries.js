$(function () {
    $('#getCountries').click(function () {
        var countries = JSON.parse(sessionStorage['countriesData']);

        $('#message').css('color', 'black').text(countries.map(function (country) {
            return country.name
        }).join(', '));
    });
});