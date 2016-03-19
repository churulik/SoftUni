$(function () {
    $('#deleteCountryButton').click(function () {
        var countryName, countryId, method, url, data, message, confirmation;

        countryName = $('#deleteCountryInput').val();
        isNullOrEmpty(countryName, 'Select country.');
        confirmation = confirm('Are you sure that you want to delete ' + countryName);
        if (confirmation) {
            countryId = getCountryId(countryName);
            method = 'DELETE';
            url = 'countries/' + countryId;
            data = {};
            message = 'You successfully delete ' + countryName;
            ajax(method, url, data, message);
        }
    });
});

