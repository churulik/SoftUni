$(function () {
    $('#deleteTownButton').click(function () {
        var townName, townId, confirmation, method, data, url, message;

        townName = $('#deleteTownInput').val();
        isNullOrEmpty(townName, 'Select town.');
        townId = getTownId(townName);
        confirmation = confirm('Are you sure that you want to delete ' + townName);
        if (confirmation) {
            method = 'DELETE';
            data = {};
            url = 'towns/' + townId;
            message = 'You successfully delete ' + townName + '.';
            ajax(method, url, data, message);
        }
    });
});