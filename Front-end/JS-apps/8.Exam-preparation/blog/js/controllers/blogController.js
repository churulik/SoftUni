var app = app || {};

app.blogController = (function () {
    function BlogController(blogModel, blogViewBag, postsPerPage) {
        this._blogModel = blogModel;
        this._blogViewBag = blogViewBag;
        this._postsOnPage = postsPerPage;
    }

    function onSuccess(text, type, redirectTo) {
        noty({
            theme: 'relax',
            text: text,
            type: type,
            timeout: 2000,
            closeWith: ['click']
        });

        Sammy(function () {
            this.trigger('redirectUrl', {url: redirectTo})
        });
    }

    BlogController.prototype.showHomePage = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._postsOnPage;

        return this._blogModel.getAllPosts(this._postsOnPage, skipPages)
            .then(function (posts) {                
                var outputData = {
                    posts: [],
                    pagination: {
                        numberOfItems: sessionStorage['numberOfPosts'],
                        itemsOnPage: _this._postsOnPage,
                        selectedPage: page,
                        hrefPrefix: '#/home/'
                    },
                    isEdible : false
                };

                posts.forEach(function (post) {
                    outputData.posts.push(new BlogOutputBindingModel(post.title, post.text, post.author));
                });

                _this._blogViewBag.loadHomeTemplate(selector, outputData);
            }).done();
    };

    BlogController.prototype.showAddPostPage = function (selector) {
        this._blogViewBag.loadAddPostTemplate(selector);
    };

    BlogController.prototype.showMyPostsPage = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._postsOnPage;
        
        return this._blogModel.getMyPosts(this._postsOnPage, skipPages)
            .then(function (myPosts) {               
                var outputData = {
                    myPosts: [],
                    pagination: {
                        numberOfItems: sessionStorage['numberOfMyPosts'],
                        itemsOnPage: _this._postsOnPage,
                        selectedPage: page,
                        hrefPrefix: '#/my-posts/'
                    },
                    isEdible : false
                };

                myPosts.forEach(function (myPost) {
                    outputData.myPosts.push(new MyPostsOutputBindingModel(myPost._id, myPost.title, myPost.text, myPost.author));
                });

                _this._blogViewBag.loadMyPostsTemplate(selector, outputData);
            }).done();
    };

    BlogController.prototype.showEditPostPage = function (selector, data) {
        this._blogViewBag.loadEditPostTemplate(selector, data);
    };

    BlogController.prototype.showDeletePostPage = function (selector, data) {
        this._blogViewBag.loadDeletePostTemplate(selector, data);
    };

    BlogController.prototype.addPost = function (data) {
        return this._blogModel.addPost(data)
            .then(function () {
                onSuccess('The post is add!', 'alert', '#/home/');
            }).done();
    };

    BlogController.prototype.editPost = function (post) {
        var postId = post.id;
        var data = new BlogInputBindingModel(post.title, post.text, sessionStorage['username']);
        return this._blogModel.editPost(postId, data)
            .then(function () {
                onSuccess('Post edit', 'success', '#/my-posts/');
            }).done();
    };

    BlogController.prototype.deletePost = function (postId) {
        return this._blogModel.deletePost(postId)
            .then(function () {
                onSuccess('Post deleted', 'success', '#/my-posts/');
            }).done();
    };

    return {
        load: function (blogModel, blogViewBag, postsPerPage) {
            return new BlogController(blogModel, blogViewBag, postsPerPage)
        }
    }
})();
