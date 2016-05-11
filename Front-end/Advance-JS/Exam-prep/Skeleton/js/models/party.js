var app = app || {};

(function (eventSystem) {
    function Party(options) {
        eventSystem.event.call(this, options);
        this.setIsCatered(options.isCatered);
        this.setIsBirthday(options.isBirthday);
        this.setOrganiser(options.organiser);
    }

    Party.extends(eventSystem.event);

    Party.prototype.getIsCatered = function () {
        return this._isCatered;
    };

    Party.prototype.setIsCatered = function (isCatered) {
        if (typeof isCatered !== 'boolean') {
            throw new Error('The isCatered has to be boolean.')
        }
        return this._isCatered = isCatered;
    };

    Party.prototype.getIsBirthday = function () {
        return this._isBirthday;
    };

    Party.prototype.setIsBirthday = function (isBirthday) {
        if (typeof isBirthday !== 'boolean') {
            throw new Error('The isBirthday has to be boolean.')
        }
        return this._isBirthday = isBirthday;
    };

    Party.prototype.getOrganiser = function () {
        return this._organizer;
    };

    Party.prototype.setOrganiser = function (organizer) {
        if (organizer.constructor.name !== 'Employee') {
            throw new Error('The organizer has to be an instance of Employee not of ' + organizer.constructor.name);
        }
        return this._organizer = organizer;
    };

    eventSystem.party = Party
})(app);