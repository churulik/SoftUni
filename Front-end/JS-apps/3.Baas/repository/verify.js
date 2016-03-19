function alreadyExist(storageName, dataName) {
    var storage, allData, length;
    storage = JSON.parse(sessionStorage[storageName]);
    allData = storage.map(function (data) {
        return data.name;
    });
    length = allData.length;
    for (var i = 0; i < length; i++) {
        if (allData[i] == dataName) {
            $('#message').css('color', 'red').text(dataName + ' already exist.');
            throw new Error(dataName + ' already exist.');
        }
    }
}

function isNullOrEmpty(dataName, message) {
    if (dataName == null || dataName == '') {
        $('#message').css('color', 'red').text(message);
        throw new Error(message)
    }
}
