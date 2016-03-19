$(function () {
    //Display town name and country name in the input fields
    $('#townToBeEditInput').on('change', function () {
        var townName, townId, countryName;

        townName = $('#townToBeEditInput').val();
        townId = getTownId(townName);
        countryName = getTownCountry(townId);
        $('#editTownInput').attr('value', townName).text(townName);
        $('#editTownCountryInput').val(countryName);
        $('#editTownHidden').show();
    });

    //Edit town
    $('#editTownButton').click(function () {
        var townName, editedTownName, townCountryName, townId, countryId, method, data, url, message;

        townName = $('#townToBeEditInput').val();

        editedTownName = $('#editTownInput').val();
        isNullOrEmpty(editedTownName, 'Select town.');
        alreadyExist('townsData', editedTownName);

        townCountryName = $('#editTownCountryInput').val();
        townId = getTownId(townName);
        countryId = getCountryId(townCountryName);

        method = 'PUT';
        data = {
            'name': editedTownName,
            'country': {
                '_type': 'KinveyRef',
                '_id': countryId,
                '_collection': 'countries'
            }
        };
        url = 'towns/' + townId;
        message = 'You successfully edit ' + townName + ' with (' + editedTownName + ', ' + townCountryName + ').';
        ajax(method, url, data, message);
    });
});
