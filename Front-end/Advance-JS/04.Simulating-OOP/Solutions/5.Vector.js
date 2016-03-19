var Vector = (function () {
    function Vector(dimension) {
        checkVectorDimension(dimension);
        this.dimension = dimension;
    }

    function checkVectorDimension(vector) {
        if (vector === undefined || vector.length === 0) {
            throw new Error('Enter valid vector.')
        }
    }

    function checkVectorDimensions(vector, other) {
        if (vector.length !== other.length) {
            throw new Error('Vector dimensions must always be the same.')
        }
    }

    function ExecuteRequest(vector, other, operator) {
        checkVectorDimensions(vector, other);
        var operators = {
            '+': function (a, b) {
                return a + b
            },
            '-': function (a, b) {
                return a - b
            }
        };

        var sum = [];
        var length = vector.length;
        for (var i = 0; i < length; i++) {
            sum[i] = operators[operator](vector[i], other[i]);
        }

        return new Vector(sum);
    }

    Vector.prototype.add = function (other) {
        return ExecuteRequest(this.dimension, other.dimension, '+');
    };

    Vector.prototype.subtract = function (other) {
        return ExecuteRequest(this.dimension, other.dimension, '-');
    };

    Vector.prototype.dot = function (other) {
        var sum = 0;
        var length = this.dimension.length;
        for (var i = 0; i < length; i++) {
            sum += this.dimension[i] * other.dimension[i];
        }

        return new Vector(sum);
    };

    Vector.prototype.norm = function () {
        var sum = 0;
        var length = this.dimension.length;
        for (var i = 0; i < length; i++) {
            sum += Math.pow(this.dimension[i], 2);
        }

        return Math.sqrt(sum);
    };

    Vector.prototype.toString = function () {
        if (this.dimension instanceof Array) {
            var join = this.dimension.join(', ');
            return '(' + join + ')';
        }

        return this.dimension;
    };

    return Vector;
})();


var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);

console.log(a.toString());
console.log(c.toString());

// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);

var result = a.add(b);
console.log(result.toString());

//a.add(c); // Error

result = a.subtract(b);
console.log(result.toString());

//a.subtract(c); // Error

result = a.dot(b);
console.log(result.toString());

console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());