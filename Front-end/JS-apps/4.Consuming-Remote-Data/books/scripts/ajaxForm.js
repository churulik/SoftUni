function ajaxForm(event, method, url, data, message) {
    event.preventDefault();
    $.ajax({
        method: method,
        headers: headers(),
        url: baseUrl() + url,
        data: JSON.stringify(data)
    }).success(function () {
        $('#message').css('color', 'green').text(message);
        updateBookSessionStorage();
    }).error(function (error) {
        console.error(error.responseText)
    });
}