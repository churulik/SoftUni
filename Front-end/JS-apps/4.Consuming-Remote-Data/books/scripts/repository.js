function headers() {
    return {
        'Authorization': 'Basic dXNlcjoxMjM0',
        'Content-Type': 'application/json'
    }
}

function baseUrl() {
    return 'https://baas.kinvey.com/appdata/kid_ZyrEdAKG1-/'
}

function getBookUrl() {
    return 'https://baas.kinvey.com/appdata/kid_ZyrEdAKG1-/book'
}

function booksSessionStorage() {
    function getData() {
        if (sessionStorage['books'] != undefined) {
            return JSON.parse(sessionStorage['books'])
        }

        return sessionStorage['books'];
    }

    function setData(data) {
        sessionStorage['books'] = JSON.stringify(data);
    }

    return {
        getData: getData,
        setData: setData
    }
}

function updateBookSessionStorage() {
    $.ajax({
        method: 'GET',
        headers: headers(),
        url: getBookUrl()
    }).success(function (data) {
        booksSessionStorage().setData(data);
    }).error(function (error) {
        console.error(error.responseText);
    })
}
