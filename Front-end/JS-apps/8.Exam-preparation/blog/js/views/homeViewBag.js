var app = app || {};

app.homeViewBag = (function () {
    function loadWelcomeTemplate(selector) {
        $(selector).load('templates/welcome.html');
    }

    return {
        load: function () {
            return {
                loadWelcomeTemplate: loadWelcomeTemplate
            }
        }
    }
})();
