var app = app || {};

app.blogModel = (function () {
    function BlogModel(requester) {
        this._requester = requester;
        this._url = requester._baseUrl + 'appdata/' + requester._appKey + '/posts';
    }

    BlogModel.prototype.getAllPosts = function (showAmount, skipPages) {
        var url = this._url + '?limit=' + showAmount + '&skip=' + skipPages;
        if (!sessionStorage['numberOfPosts']) {
            var _this = this;
            var countUrl = this._url + '/_count';
            return this._requester.get(countUrl)
                .then(function (numberOfPosts) {
                    sessionStorage['numberOfPosts'] = numberOfPosts.count;
                    return _this._requester.get(url);
                }, function (error) {
                    console.log(error)
                });
        }
        return this._requester.get(url);
    };

    BlogModel.prototype.addPost = function (data) {
        return this._requester.post(this._url, data, true);
    };

    BlogModel.prototype.getMyPosts = function (showAmount, skipPages) {
        var getMyPostsCountUrl, data, url, _this = this;

        url = _this._url +
            '?query={"author":"' + sessionStorage['username'] + '"}' +
            '&limit=' + showAmount +
            '&skip=' + skipPages;

        if (!sessionStorage['numberOfMyPosts']) {
            getMyPostsCountUrl = this._url + '/_group?limit=1';
            data = {
                "key": {},
                "initial": {
                    "count": 0
                },
                "reduce": "function(doc,out){ out.count++;}",
                "condition": {
                    "author": sessionStorage['username']
                }
            };
            return this._requester.post(getMyPostsCountUrl, data, true)
                .then(function (numberOfMyPosts) {                    
                    sessionStorage['numberOfMyPosts'] = numberOfMyPosts[0].count;
                    return _this._requester.get(url);
                }, function (error) {
                    console.log(error)
                });
        }

        return this._requester.get(url);
    };

    BlogModel.prototype.editPost = function (postId, data) {
        var url = this._url + '/' + postId;
        return this._requester.put(url, data, true);
    };

    BlogModel.prototype.deletePost = function (postId) {
        var url = this._url + '/' + postId;
        return this._requester.delete(url);
    };

    return {
        load: function (requester) {
            return new BlogModel(requester);
        }
    }
})();
