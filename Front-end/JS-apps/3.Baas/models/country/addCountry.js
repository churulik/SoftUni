$(function () {
    $('#addCountryButton').click(function () {
        var countryName, countryDb, allCountries, countriesLength, method, url, data, message;

        countryName = $('#addCountryInput').val();
        isNullOrEmpty(countryName, 'Select country.');
        alreadyExist('countriesData', countryName);

        method = 'POST';
        url = 'countries';
        data = {'name': countryName};
        message = countryName + ' is add.';
        ajax(method, url, data, message);
    });
});