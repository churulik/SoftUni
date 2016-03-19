$(function () {
    $('#editCountryButton').click(function () {
        var countryName, editName, countryId, method, data, url, message;

        countryName = $('#countryToBeEditInput').val();
        editName = $('#editCountryInput').val();
        isNullOrEmpty(editName, 'Select country.');
        alreadyExist('countriesData', editName);

        countryId = getCountryId(countryName);

        method = 'PUT';
        data = {'name': editName};
        url = 'countries/' + countryId;
        message = 'You successfully edit ' + countryName + ' to ' + editName + '.';
        ajax(method, url, data, message);
    });
});