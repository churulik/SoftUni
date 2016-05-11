var app = app || {};

(function (eventSystem) {
    function Hall(name, capacity) {
        this.setName(name);
        this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype.getName = function () {
        return this._name;
    };

    Hall.prototype.setName = function (name) {
        lettersOrWhitespaces(name, 'The hall name has contain only letters and whitespaces.');
        return this._name = name;
    };

    Hall.prototype.getCapacity = function () {
        return this._capacity;
    };

    Hall.prototype.setCapacity = function (capacity) {
        digits(capacity, 'The hall capacity has contain only digits.');
        return this._capacity = capacity;
    };

    Hall.prototype.addEvent = function (event) {
        if (event instanceof eventSystem.party) {
            this.parties.push(event);
        }

        if (event instanceof eventSystem.lecture) {
            this.lectures.push(event);
        }
    };

    eventSystem.hall = Hall;
})(app);