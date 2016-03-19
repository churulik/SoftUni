(function () {
    var requester, container, router;
    var userModel, booksModel;
    var userController, booksController;
    var userViewBag, booksViewBag;

    requester = app.requester.config('https://baas.kinvey.com/','kid_ZyrEdAKG1-', 'f529995250df4009856d729c346ded45');
    container = '#container';

    userModel = app.userModel.load(requester);
    booksModel = app.booksModel.load(requester);

    userViewBag = app.userViewBag.load();
    booksViewBag = app.booksViewBag.load();

    userController = app.userController.load(userModel, userViewBag);
    booksController = app.booksController.load(booksModel, booksViewBag);

    router = Sammy(function () {
        this.before(function() {
            if (!sessionStorage['token']) {
                $('#nav-logout').hide();
                $('#nav-add-book').hide();
                $('#nav-my-books').hide();
                $('#nav-home').show();
                $('#nav-register').show();
                $('#nav-login').show();
            } else {
                $('#nav-register').hide();
                $('#nav-login').hide();
                $('#nav-home').show();
                $('#nav-logout').show();
                $('#nav-add-book').show();
                $('#nav-my-books').show();
            }
        });
        this.before({except: {path: '#\/(register|login)?'}}, function () {
            if (!sessionStorage['token']) {
                this.redirect('#/login');
                return false;
            }
        });

        this.before('#\/(register|login)', function () {
            if (sessionStorage['token']) {
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function () {
            booksController.showAllBooks(container, 'templates/home.html');
        });

        this.get('#/register', function () {
            userController.showRegistrationPage(container, 'templates/user/register.html');
        });

        this.get('#/login', function () {
            userController.showLoginPage(container, 'templates/user/login.html');
        });

        this.get('#/logout', function () {
            userController.logout();
        });

        this.get('#/add-new-book', function () {
            booksController.showAddNewBookPage(container, 'templates/book/addNewBook.html');
        });

        this.get('#/my-books', function () {
            booksController.showUserBooks(container, 'templates/book/myBooks.html');
        });

        //Event listeners
        this.bind('redirectUrl', function () {
            this.redirect('#/');
        });

        //User event listeners
        this.bind('register', function (e, data) {
            userController.register(data)
        });

        this.bind('login', function (e, data) {
            userController.login(data);
        });

        //Book event listeners
        this.bind('addNewBook', function (e, data) {
            booksController.addNewBook(data);
        });

        this.bind('editBook', function (e, book) {
            booksController.editBook(book);
        });

        this.bind('deleteBook', function (e, bookId) {
            booksController.deleteBook(bookId);
        });
    });

    router.run('#/');
})();


