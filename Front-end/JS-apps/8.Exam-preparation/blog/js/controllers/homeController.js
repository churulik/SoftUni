var app = app || {};

app.homeController = (function () {
    function HomeController(homeViewBag) {
        this._homeViewBag = homeViewBag;
    }

    HomeController.prototype.showWelcomePage = function (selector) {
        this._homeViewBag.loadWelcomeTemplate(selector);
    };

    return {
        load: function (homeViewBag) {
            return new HomeController(homeViewBag);
        }
    }
})();
