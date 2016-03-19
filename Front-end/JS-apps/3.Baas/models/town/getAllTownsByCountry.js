$(function () {
    $('#displayAllTownsByCountryButton').click(function () {
        var countryName, countryId, towns, townsResult;

        countryName = $('#displayAllTownsByCountryInput').val();
        isNullOrEmpty(countryName, 'Select country.');

        countryId = getCountryId(countryName);
        towns = JSON.parse(sessionStorage['townsData']);
        townsResult = [];
        for (var i = 0; i < towns.length; i++) {
            if (towns[i].country._id == countryId) {
                townsResult.push(towns[i].name)
            }
        }

        if (townsResult.length == 0) {
            $('#message').css('color', 'black').text(countryName + ': no registered towns.')
        } else {
            townsResult.sort();
            $('#message').css('color', 'black').text(countryName + ': ' + townsResult.join(', '))
        }
    })
});

