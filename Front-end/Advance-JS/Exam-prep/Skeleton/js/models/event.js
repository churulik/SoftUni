var app = app || {};

(function (eventSystem) {
    function Event(options) {
        if (this.constructor === Event) {
            throw new Error('Cannot instantiate an abstract class.');
        }

        this.setTitle(options.title);
        this.setType(options.type);
        this.setDuration(options.duration);
        this.setDate(options.date);
    }

    Event.prototype.getTitle = function () {
        return this._title;
    };

    Event.prototype.setTitle = function (title) {
        lettersOrWhitespaces(title, 'The name should contain only letters or whitespaces.');
        return this._title = title;
    };

    Event.prototype.getType = function () {
        return this._type;
    };

    Event.prototype.setType = function (type) {
        lettersOrWhitespaces(type, 'The type should contain only letters or whitespaces.');
        return this._type = type;
    };

    Event.prototype.getType = function () {
        return this._type;
    };

    Event.prototype.setType = function (type) {
        lettersOrWhitespaces(type, 'The type should contain only letters or whitespaces.');
        return this._type = type;
    };

    Event.prototype.getDuration = function () {
        return this._duration;
    };

    Event.prototype.setDuration = function (duration) {
        digits(duration, 'The duration should contain only digits.');
        return this._duration = duration;
    };

    Event.prototype.getDate = function () {
        return this._date;
    };

    Event.prototype.setDate = function (date) {
        if (!(date instanceof Date)) {
            throw new Error('The date has to be instance of Date.');
        }
        return this._date = date;
    };

    eventSystem.event = Event;
})(app);