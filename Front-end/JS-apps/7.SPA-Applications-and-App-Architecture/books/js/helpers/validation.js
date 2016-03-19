var app = app || {};

app.validate = (function () {
    function successBorder(query) {
        query.css('border-color', 'green');
    }

    function errorBorder(query) {
        query.css('border-color', 'red');
    }

    function successIcon(query) {
        query.html('<span class="glyphicon glyphicon-ok form-control-feedback" style="color: green"></span>');
    }

    function errorIcon(query) {
        query.html('<span class="glyphicon glyphicon-remove form-control-feedback" style="color: red"></span>');
    }

    function register() {
        $('form').change(function (data) {
            var username, password, confirmPassword, usernameExists;

            username = data.currentTarget[0].value;
            password = data.currentTarget[1].value;
            confirmPassword = data.currentTarget[2].value;

            $.ajax({
                method: 'POST',
                url: 'https://baas.kinvey.com/rpc/kid_ZyrEdAKG1-/check-username-exists',
                headers: {
                    'Authorization': 'Basic ' + btoa('kid_ZyrEdAKG1-:f529995250df4009856d729c346ded45')
                },
                data: {
                    username: username
                },
                success: function (data) {
                    if (!data.usernameExists) {
                        successBorder($('#username'));
                        successIcon($('#validate-username'));
                        usernameExists = false;
                    } else {
                        errorBorder($('#username'));
                        errorIcon($('#validate-username'));
                        usernameExists = true;
                    }

                    if (password !== '') {
                        successBorder($('#password'));
                        successIcon($('#validate-password'))
                    } else {
                        errorBorder($('#password'));
                        errorIcon($('#validate-password'));
                    }

                    if (password === confirmPassword && password !== '' && confirmPassword !== '') {
                        successBorder($('#confirm-password'));
                        successIcon($('#validate-confirm-password'));
                    } else if (password !== confirmPassword && password !== '' && confirmPassword !== ''){
                        errorBorder($('#confirm-password'));
                        errorIcon($('#validate-confirm-password'));
                    }

                    if (username !== '' && password !== '' && confirmPassword !== ''
                        && password === confirmPassword && !usernameExists) {
                        $('#register-btn').attr('disabled', false);
                    } else {
                        $('#register-btn').attr('disabled', true);
                    }
                },
                error: function (error) {
                    console.log(error)
                }
            });
        });
    }

    function login() {
        $('form').keyup(function (data) {
            var username, password;
            username = data.currentTarget[0].value;
            password = data.currentTarget[1].value;

            if (username !== '' && password !== '') {
                $('#login-btn').attr('disabled', false);
            } else {
                $('#login-btn').attr('disabled', true);
            }
        });
    }

    return {
        register: register,
        login: login
    }
})();
