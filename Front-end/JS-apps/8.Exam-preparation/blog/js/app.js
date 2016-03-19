(function () {
    var requester, router, selector, postsPerPage = 2;
    var userModel, blogModel;
    var homeViewBag, userViewBag, blogViewBag;
    var homeController, userController, blogController;

    requester = app.requester.config('https://baas.kinvey.com/',
        'kid_-y4zAoxaCx', 'cd7126a7dcad4b5b8fb93f7ee574249e');

    userModel = app.userModel.load(requester);
    blogModel = app.blogModel.load(requester);

    homeViewBag = app.homeViewBag.load();
    userViewBag = app.userViewBag.load();
    blogViewBag = app.blogViewBag.load();

    homeController = app.homeController.load(homeViewBag);
    userController = app.userController.load(userModel, userViewBag);
    blogController = app.blogController.load(blogModel, blogViewBag, postsPerPage);

    selector = '#container';

    router = Sammy(function () {
        this.before(function () {
            if (sessionStorage['token']) {
                $('#greeting').text('Welcome, ' + sessionStorage['username']);
                $('#container').empty();
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before({except: {path: '#\/(register\/|login\/)?'}}, function () {
            if (!sessionStorage['token']) {
                noty({
                    theme: 'relax',
                    text: 'Login first',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
                this.redirect('#/login/');
                return false;
            }
        });

        this.before('#\/(register\/|login\/)?', function () {
            if (sessionStorage['token']) {
                this.redirect('#/home/');
                return false;
            }
        });

        /** Home model */
        this.get('#/', function () {
            homeController.showWelcomePage(selector);
        });

        /** User model */
        this.get('#/register/', function () {
            userController.showRegisterPage(selector);
        });

        this.get('#/login/', function () {
            userController.showLoginPage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        /** Blog model*/
        this.get('#/home/([-0-9]+)?', function () {
            var page = 1;

            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            blogController.showHomePage(selector, page);
        });

        this.get('#/add-post/', function () {
            blogController.showAddPostPage(selector);
        });

        this.get('#/my-posts/([-0-9]+)?', function () {
            var page = 1;
            
            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            blogController.showMyPostsPage(selector, page);
        });

        /** Event handlers */
        this.bind('redirectUrl', function (e, data) {
            this.redirect(data.url);
        });

        //User event handler
        this.bind('register', function (e, data) {
            userController.register(data);
        });

        this.bind('login', function (e, data) {
            userController.login(data);
        });

        //Blog event handlers
        this.bind('addPost', function (e, data) {
            blogController.addPost(data);
        });

        this.bind('showEditPostPage', function (e, data) {
            blogController.showEditPostPage(selector, data);
        });

        this.bind('showDeletePostPage', function (e, data) {
            blogController.showDeletePostPage(selector, data);
        });

        this.bind('editPost', function (e, post) {
            blogController.editPost(post);
        });

        this.bind('deletePost', function (e, postId) {
            blogController.deletePost(postId);
        });
    });

    router.run('#/');
})();