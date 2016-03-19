var app = app || {};

app.requester = (function () {
    function Requester(baseUrl, appKey, appSecret) {
        this._baseUrl = baseUrl;
        this._appKey = appKey;
        this._appSecret = appSecret;
    }

    Requester.prototype.defaultHomeRequest = function (url) {
        var defer = Q.defer();

        $.ajax({
            method: 'GET',
            url: url,
            headers: {
                'Authorization': 'Basic ZGVmYXVsdDoxMjM0'
            },
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error)
            }
        });

        return defer.promise;
    };

    Requester.prototype.getMethod = function (url) {
        return this.makeRequest('GET', url, null, true);
    };

    Requester.prototype.postMethod = function (url, data, useSession) {
        return this.makeRequest('POST', url, data, useSession);
    };

    Requester.prototype.putMethod = function (url, data) {
        return this.makeRequest('PUT', url, data, true);
    };
    Requester.prototype.deleteMethod = function (url) {
        return this.makeRequest('DELETE', url, null, true);
    };

    Requester.prototype.makeRequest = function (method, url, data, useSession) {
        var token, defer, _this;

        _this = this;
        defer = Q.defer();

        $.ajax({
            method: method,
            url: url,
            beforeSend: function (xhr, settings) {
                if (useSession) {
                    token = sessionStorage['token'];
                    xhr.setRequestHeader('Authorization', 'Kinvey ' + token);
                } else {
                    token = _this._appKey + ':' + _this._appSecret;
                    xhr.setRequestHeader('Authorization', 'Basic ' + btoa(token));
                }

                if (data) {
                    xhr.setRequestHeader('Content-Type', 'application/json');
                    settings.data = JSON.stringify(data);
                }
            },
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error)
            }
        });

        return defer.promise;
    };
    return {
        config: function (baseUrl, appKey, appSecret) {
            return new Requester(baseUrl, appKey, appSecret)
        }
    }
})();
