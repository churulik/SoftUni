var app = app || {};

app.userViewBag = (function () {
    function loadTemplate(templateName, selector) {
        return $.get('templates/user/' + templateName + '.html', function (template) {
            $(selector).html(template);
        });
    }

    function loadRegisterTemplate(selector) {
        loadTemplate('register', selector)
            .then(function () {
                $('#register-btn').click(function () {
                    var username, password, email, fullName;

                    username = $('#username').val();
                    password = $('#password').val();
                    email = $('#email').val();
                    fullName = $('#fullName').val();

                    Sammy(function () {
                        this.trigger('register', new RegisterInputBindingModel(username, password, email, fullName));
                    });
                });
            }, function (error) {
                console.log(error)
            });
    }

    function loadLoginTemplate(selector) {
        loadTemplate('login', selector)
            .then(function () {
                $('#login-btn').click(function () {
                    var username, password;

                    username = $('#username').val();
                    password = $('#password').val();

                    Sammy(function () {
                        this.trigger('login', new loginInputBindingModel(username, password));
                    });
                });
            }, function (error) {
                console.log(error)
            });
    }

    return {
        load: function () {
            return {
                loadRegisterTemplate: loadRegisterTemplate,
                loadLoginTemplate: loadLoginTemplate
            }
        }
    }
})();
