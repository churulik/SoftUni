var app = app || {};

(function (eventSystem) {
    function Trainer(name, workHours) {
        eventSystem.employee.call(this, name, workHours);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.extends(eventSystem.employee);

    Trainer.prototype.addCourse = function (course) {
        if (!(course instanceof eventSystem.course)) {
            throw new Error('The course has to be instance of Course.');
        }
        this.courses.push(course);
    };

    Trainer.prototype.addFeedback = function (feedback) {
        if (typeof feedback !== 'string') {
            throw new Error('The feedback has to be string.');
        }
        this.feedbacks.push(feedback);
    };

    eventSystem.trainer = Trainer;
})(app);