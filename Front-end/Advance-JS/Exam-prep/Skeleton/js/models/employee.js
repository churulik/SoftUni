var app = app || {};

(function (eventSystem) {
    function Employee(name, workHours) {
        this.setName(name);
        this.setWorkhours(workHours);
    }

    Employee.prototype.getName = function () {
        return this._name;
    };

    Employee.prototype.setName = function (name) {
        lettersOrWhitespaces(name, 'The employee name has contain only letters and whitespaces.');
        return this._name = name;
    };

    Employee.prototype.getWorkhours = function () {
        return this._workHourse;
    };

    Employee.prototype.setWorkhours = function (workHours) {
        digits(workHours, 'The work hours has contain only digits.');
        return this._workHourse = workHours;
    };

    eventSystem.employee = Employee;
})(app);