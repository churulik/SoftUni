var Person = (function () {
    function Person(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    Person.prototype = {
        get fullName() {
            return this.firstName + ' ' + this.lastName;
        },

        set fullName(value) {
            var name = value.split(' ');
            this.firstName = name[0];
            this.lastName = name[1];
        }
    };

    return Person;
})();

var person = new Person('Peter' , 'Jackson' );

// Getting values
console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);

// Changing values
person.firstName = 'Michael' ;
console.log(person.firstName);
console.log(person.fullName);
person.lastName = 'Williams' ;
console.log(person.lastName);
console.log(person.fullName);

// Changing the full name should work too
person.fullName = 'Alan Marcus' ;
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);



