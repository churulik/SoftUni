var app = app || {};

(function (eventSystem) {
    function Lecture(options) {
        eventSystem.event.call(this, options);
        this.setTrainer(options.trainer);
        this.setCourse(options.course);
    }

    Lecture.extends(eventSystem.event);

    Lecture.prototype.getTrainer = function () {
        return this._trainer;
    };

    Lecture.prototype.setTrainer = function (trainer) {
        if (!(trainer instanceof eventSystem.trainer)) {
            throw new Error('The trainer has to be an instance of Trainer not of ' + trainer.constructor.name);
        }
        return this._trainer = trainer;
    };

    Lecture.prototype.getCourse = function () {
        return this._course;
    };

    Lecture.prototype.setCourse = function (course) {
        if (!(course instanceof eventSystem.course)) {
            throw new Error('The course has to be an instance of Course not of ' + course.constructor.name);
        }
        return this._course = course;
    };

    eventSystem.lecture = Lecture;
})(app);