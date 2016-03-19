var fillCountryDropDownList = (function () {
    function saveCountriesDataToStorage(data) {
        sessionStorage['countriesData'] = JSON.stringify(data);
    }

    function clearCountriesDropDownList() {
        var dropDowListChild = $('.countryDropDown');
        for (var i = 0; i < dropDowListChild.length; i++) {
            var dropDowList = dropDowListChild[i];
            while (dropDowList.firstChild) {
                dropDowList.removeChild(dropDowList.firstChild);
            }
        }
    }

    function fillCountryDropDownList() {
        $.ajax({
            method: 'GET',
            headers: {
                'Authorization': 'Basic dXNlcjoxMjM0',
                'Content-Type': 'application/json'
            },
            url: 'https://baas.kinvey.com/appdata/kid_ZJEuHxuRCx/countries?query={}&sort=name'
        }).success(function (data) {
            saveCountriesDataToStorage(data);
            clearCountriesDropDownList();

            //Add countries to drop-down lists
            var countries = data.map(function (country) {
                return country.name
            });
            $('.countryDropDown').append($('<option>')
                .attr('value', 'Select country')
                .attr('selected', '')
                .attr('disabled', '')
                .text('Select country'));
            countries.forEach(function (country) {
                $('.countryDropDown').append($('<option>').attr('value', country).text(country));
            });
        }).error(function (error) {
            console.error(error.responseText)
        });
    }

    return fillCountryDropDownList;
})();

fillCountryDropDownList();

function getCountryId(countryName) {
    var countries, countryId;

    countries = JSON.parse(sessionStorage['countriesData']);
    for (var i = 0; i < countries.length; i++) {
        if (countries[i].name == countryName) {
            countryId = countries[i]._id;
            return countryId;
        }
    }
}

function getCountryName(countryId) {
    var countries = JSON.parse(sessionStorage['countriesData']);
    for (var i = 0; i < countries.length; i++) {
        if (countries[i]._id == countryId) {
            return countries[i].name;
        }
    }
}