var app = app || {};

app.requester = (function () {
    function Requester(baseUrl, appKey, appSecret) {
        this._baseUrl = baseUrl;
        this._appKey = appKey;
        this._appSecret = appSecret;
    }

    function getHeaders(isJSON, useSession) {
        var headers = {}, token;

        if (isJSON) {
            headers['Content-Type'] = 'application/json';
        }

        if (useSession) {
            headers['Authorization']= 'Kinvey ' + sessionStorage['token'];
        } else {
            token = this._appKey + ':' + this._appSecret;
            headers['Authorization']= 'Basic ' + btoa(token);
        }

        return headers;
    }

    Requester.prototype.get = function (url) {
        var headers = getHeaders.call(this, false, true);
        return this.makeRequest('GET', url, headers);
    };

    Requester.prototype.post = function (url, data, useSession) {
        var headers = getHeaders.call(this, data, useSession);
        return this.makeRequest('POST', url, headers, data);
    };

    Requester.prototype.put = function (url, data, useSession) {
        var headers = getHeaders.call(this, data, useSession);
        return this.makeRequest('PUT', url, headers, data);
    };

    Requester.prototype.delete = function (url) {
        var headers = getHeaders.call(this, false, true);
        return this.makeRequest('DELETE', url, headers);
    };

    Requester.prototype.makeRequest = function (method, url, headers, data) {
        var defer = Q.defer();

        $.ajax({
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data) || undefined,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error);
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