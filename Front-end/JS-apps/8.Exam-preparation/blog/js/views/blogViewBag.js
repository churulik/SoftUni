var app = app || {};

app.blogViewBag = (function () {
    function loadTemplate(templateName, selector, data) {
        if (data) {
            return $.get('templates/blog/' + templateName + '.html', function (template) {
                var renderedData = Mustache.render(template, data);
                $(selector).html(renderedData);
            });
        }

        return $.get('templates/blog/' + templateName + '.html', function (template) {
            $(selector).html(template);
        });
    }

    function getPostDetails(myPosts, element) {
        var postId, post;

        postId = $(element).parent().attr('data-id');
        post = myPosts.myPosts.filter(function (post) {
            return post.id === postId;
        });

        return post[0];
    }

    function loadHomeTemplate(selector, data) {
        loadTemplate('home', selector, data)
            .then(function () {
                $('#pagination').pagination({
                    items: data.pagination.numberOfItems,
                    itemsOnPage: data.pagination.itemsOnPage,
                    cssStyle: 'light-theme',
                    hrefTextPrefix: data.pagination.hrefPrefix
                }).pagination('selectPage', data.pagination.selectedPage);
            });
    }

    function loadAddPostTemplate(selector) {
        loadTemplate('addPost', selector)
            .then(function () {
                $('#add-post-btn').click(function () {
                    var title, text, data;
                    title = $('#title').val();
                    text = $('#text').val();

                    Sammy(function () {
                        this.trigger('addPost', new BlogInputBindingModel(title, text, sessionStorage['username']));
                    });

                    if (sessionStorage['numberOfPosts']) {
                        sessionStorage['numberOfPosts'] = Number(sessionStorage['numberOfPosts']) + 1;
                    }

                    if (sessionStorage['numberOfMyPosts']) {
                        sessionStorage['numberOfMyPosts'] = Number(sessionStorage['numberOfMyPosts']) + 1;
                    }
                });
            }, function (error) {
                console.log(error);
            });
    }

    function loadMyPostsTemplate(selector, myPosts) {
        loadTemplate('myPosts', selector, myPosts)
            .then(function () {
                $('#pagination').pagination({
                    items: myPosts.pagination.numberOfItems,
                    itemsOnPage: myPosts.pagination.itemsOnPage,
                    cssStyle: 'light-theme',
                    hrefTextPrefix: myPosts.pagination.hrefPrefix
                }).pagination('selectPage', myPosts.pagination.selectedPage);

                $('.edit-post').click(function () {
                    var post = getPostDetails(myPosts, this);

                    Sammy(function () {
                        this.trigger('showEditPostPage', post);
                    });
                });

                $('.delete-post').click(function () {
                    var post = getPostDetails(myPosts, this);

                    Sammy(function () {
                        this.trigger('showDeletePostPage', post);
                    });
                });

            }, function (error) {
                console.log(error);
            });
    }

    function loadEditPostTemplate(selector, data) {
        loadTemplate('editPost', selector, data)
            .then(function () {
                $('#edit-post-btn').click(function () {
                    var id, title, text;

                    id = $(this).parent().data('id');
                    title = $('#title').val();
                    text = $('#text').val();

                    Sammy(function () {
                        this.trigger('editPost', new EditPostInputBindingModel(id, title, text));
                    })
                });

                $('#cancel-edit-btn').click(function () {
                    Sammy(function () {
                        this.trigger('redirectUrl', {url: '#/my-posts/'});
                    })
                });
            }, function (error) {
                console.log(error);
            });
    }

    function loadDeletePostTemplate(selector, data) {
        loadTemplate('deletePost', selector, data)
            .then(function () {
                $('#delete-post-btn').click(function () {
                    var postId = $(this).parent().data('id');
                    Sammy(function () {
                        this.trigger('deletePost', postId);
                    });
                    sessionStorage['numberOfPosts'] = Number(sessionStorage['numberOfPosts']) - 1;
                    sessionStorage['numberOfMyPosts'] = Number(sessionStorage['numberOfMyPosts']) - 1;
                });

                $('#cancel-delete-btn').click(function () {
                    Sammy(function () {
                        this.trigger('redirectUrl', {url: '#/my-posts/'});
                    })
                });
            }, function (error) {
                console.log(error);
            });
    }

    return {
        load: function () {
            return {
                loadHomeTemplate: loadHomeTemplate,
                loadAddPostTemplate: loadAddPostTemplate,
                loadMyPostsTemplate: loadMyPostsTemplate,
                loadEditPostTemplate: loadEditPostTemplate,
                loadDeletePostTemplate: loadDeletePostTemplate
            }
        }
    }
})();