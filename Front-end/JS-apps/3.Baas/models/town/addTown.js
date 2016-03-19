$(function () {
    $('#addTownButton').click(function () {
        var countryName, townName, townDb, allTowns, townLength, countryId, method, data, url, message;

        countryName = $('#selectCountryInput').val();
        isNullOrEmpty(countryName, 'Select country.');

        townName = $('#addTownInput').val();
        alreadyExist('townsData', townName);

        countryId = getCountryId(countryName);

        method = 'POST';
        data = {
            'name': townName,
            'country': {
                '_type': 'KinveyRef',
                '_id': countryId,
                '_collection': 'countries'
            }
        };
        url = 'towns';
        message = townName + ' is add to ' + countryName + '.';
        ajax(method, url, data, message);
    });

});
