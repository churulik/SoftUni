String.prototype.startsWith = function (substring) {
    return substring === this.substr(0, substring.length);
};

String.prototype.endsWith = function (substring) {
    return substring === this.substr(-substring.length);
};

String.prototype.left = function (count) {
    return this.substr(0, count);
};

String.prototype.right = function (count) {
    return this.substr(-count);
};

String.prototype.padLeft = function (count, character) {
    if (count <= this.length) {
        return this.toString();
    }

    character = character || ' ';
    var newString = '';
    for (var i = count; i > 0; i--) {
        if (this.length >= i) {
            newString += this[this.length - i];
        }
        else {
            newString += character
        }
    }

    return newString;
};

String.prototype.padRight = function (count, character) {
    if (count <= this.length) {
        return this.toString();
    }

    character = character || ' ';
    var newString = '';
    for (var i = 0; i < count; i++) {
        if (this.length > i) {
            newString += this[i];
        }
        else {
            newString += character
        }
    }

    return newString;
};

String.prototype.repeat = function (count) {
    var result = '';
    for (var i = 0; i < count; i++) {
        result += this;
    }

    return result;
};

var example;

example = 'This is an example string used only for demonstration purposes.';
console.log(example.startsWith('This'));
console.log(example.startsWith('this'));
console.log(example.startsWith('other'));
console.log();

console.log(example.endsWith('poses.'));
console.log(example.endsWith('example'));
console.log(example.startsWith('something else'));
console.log();

console.log(example.left(9));
console.log(example.left(90));
console.log();

console.log(example.right(9));
console.log(example.right(90));
console.log();

example = 'abcdefgh';
console.log(example.left(5).right(2));
console.log();

var hello = 'hello';
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, '.'));
console.log(hello.padLeft(10, '.'));
console.log(hello.padLeft(2, '.'));
console.log();

console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, '.'));
console.log(hello.padRight(10, '.'));
console.log(hello.padRight(2, '.'));

var character = '*';
console.log(character.repeat(5));
// Alternative syntax
console.log('~'.repeat(3));

console.log('*'.repeat(5).padLeft(10, '-').padRight(15, '+'));
