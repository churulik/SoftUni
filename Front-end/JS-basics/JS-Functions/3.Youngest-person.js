/**
 * Write a JavaScript function findYoungestPerson(array)
 * that accepts as parameter an array of people,
 * finds the youngest person that has a smartphone and returns his full name.
 * Write a JS program youngestPerson.js to execute your function for the below examples
 * and print the result at the console.
 */


var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

var array = people;

findYoungestPerson(array);

function findYoungestPerson(array) {

    array.sort(compare);

    for (var i = 0; i < array.length; i++) {
        if(array[i].hasSmartphone === true) {
            console.log('The youngest person is ' + array[i].firstname + ' '+ array[i].lastname);
            break;
        }

    }

    function compare(a, b){
        if (a.age < b.age) {
            return - 1;
        }
        if (a.age > b.age) {
            return 1;
        }
        return 0;
    }
}