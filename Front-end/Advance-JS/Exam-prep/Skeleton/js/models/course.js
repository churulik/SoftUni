var app = app || {};

(function (eventSystem) {
    function Course(name, numberOfLectures) {
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);
    }

    Course.prototype.getName = function () {
        return this._name;
    };

    Course.prototype.setName = function (name) {
        lettersOrWhitespaces(name, 'The course name has contain only letters and whitespaces.');
        return this._name = name;
    };

    Course.prototype.getNumberOfLectures = function () {
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function (numberOfLectures) {
        digits(numberOfLectures, 'The number of lectures has contain only digits.');
        return this._numberOfLectures = numberOfLectures;
    };

    eventSystem.course = Course;
})(app);