function ajax(method, url, data, message){
    $.ajax({
        method: method,
        headers: {
            'Authorization': 'Basic dXNlcjoxMjM0',
            'Content-Type': 'application/json'
        },
        url: 'https://baas.kinvey.com/appdata/kid_ZJEuHxuRCx/' + url,
        data: JSON.stringify(data)
    }).success(function () {
        $('#message').css('color', 'green').text(message);
        fillCountryDropDownList();
        fillTownDropDownList();
    }).error(function (error) {
        console.error(error.responseText)
    })
}
