var fillTownDropDownList = (function () {
    function saveTownsDataToStorage(data) {
        sessionStorage['townsData'] = JSON.stringify(data);
    }

    function clearTownsDropDownList() {
        var dropDowListChild = $('.townDropDown');
        for (var i = 0; i < dropDowListChild.length; i++) {
            var dropDowList = dropDowListChild[i];
            while (dropDowList.firstChild) {
                dropDowList.removeChild(dropDowList.firstChild);
            }
        }
    }

    function fillTownDropDownList() {
        $.ajax({
            method: 'GET',
            headers: {
                'Authorization': 'Basic dXNlcjoxMjM0',
                'Content-Type': 'application/json'
            },
            url: 'https://baas.kinvey.com/appdata/kid_ZJEuHxuRCx/towns?query={}&sort=name'
        }).success(function (data) {
            saveTownsDataToStorage(data);
            clearTownsDropDownList();

            //Add towns to drop-down lists
            var countries = data.map(function (town) {
                return town.name
            });
            $('.townDropDown').append($('<option>')
                .attr('value', 'Select town')
                .attr('selected', '')
                .attr('disabled', '')
                .text('Select town'));
            countries.forEach(function (town) {
                $('.townDropDown').append($('<option>').attr('value', town).text(town));
            });
        }).error(function (error) {
            console.error(error.responseText)
        });
    }

    return fillTownDropDownList;
})();

fillTownDropDownList();

function getTownId(townName) {
    var towns, townId;

    towns = JSON.parse(sessionStorage['townsData']);
    for (var i = 0; i < towns.length; i++) {
        if (towns[i].name == townName) {
            townId = towns[i]._id;
            return townId;
        }
    }
}

function getTownCountry(townId) {
    var towns, townCountryName;

    towns = JSON.parse(sessionStorage['townsData']);
    for (var i = 0; i < towns.length; i++) {
        if (towns[i]._id == townId) {

            townCountryName = getCountryName(towns[i].country._id);
            return townCountryName;
        }
    }
}