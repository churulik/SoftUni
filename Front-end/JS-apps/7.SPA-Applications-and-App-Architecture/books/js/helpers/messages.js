var app = app || {};
app.message = (function () {
    function message(className, text) {
        setTimeout(function () {
            $('#message').attr('class',className).text(text);
            $('#message-container').fadeIn('slow', function () {
                $('#message-container').show();
            });
        }, 500);



        setTimeout(function () {
            $('#message-container').fadeOut('slow', function () {
                $('#message-container').hide();
            });

        }, 3000)
    }

    function infoMessage(text) {
        message('alert alert-info', text)
    }

    function successMessage(text) {
        message('alert alert-success', text)
    }

    function errorMessage(text) {
        message('alert alert-danger', text)
    }

    return {
        infoMessage: infoMessage,
        successMessage: successMessage,
        errorMessage: errorMessage
    }
})();

