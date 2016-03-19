var app = app || {};

app.userViewBag = (function () {
    function showRegistrationPage(container, path) {
        $.get(path, function (templ) {
            fadeInText(container, templ);
            app.validate.register();
            app.submitForm.register();
        });
    }

    function showLoginPage(container, path) {
        $.get(path, function (templ) {
            fadeInText(container, templ);
            app.validate.login();
            app.submitForm.login();
        });
    }

    return {
        load: function () {
            return {
                showRegistrationPage: showRegistrationPage,
                showLoginPage: showLoginPage
            }
        }
    }
})();