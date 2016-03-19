function add(a) {
    var sum = a;

    function innerAdd(b) {
        sum += b;
        return innerAdd;
    }

    innerAdd.toString = function () {
        return sum;
    };

    return innerAdd;
}

console.log(+add(1));
console.log(+add(2)(3));
console.log(+add(1)(1)(1)(1)(1));
console.log(+add(1)(0)(-1)(-1));

var addTwo = add(2);
console.log(+addTwo);

console.log(+addTwo(3));

addTwo = add(2);
console.log(+addTwo(3)(5));
