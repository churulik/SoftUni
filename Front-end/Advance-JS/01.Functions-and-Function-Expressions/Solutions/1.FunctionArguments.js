function printArgsInfo() {
    var argumentsLength = arguments.length;
    for (var i = 0; i < argumentsLength; i++) {
        if (Object.prototype.toString.call(arguments[i]) === '[object Array]') {
            console.log(arguments[i] + ' (array)')
        } else {
            console.log(arguments[i] + ' (' + typeof arguments[i] + ')')
        }
    }
    console.log()
}

printArgsInfo(2, 3, 2.5, -110.5564, false);

printArgsInfo(null, undefined, '', 0, [], {});
// Note that [].toString() returns ""
printArgsInfo([1, 2], ['string', 'array'], ['single value']);

printArgsInfo('some string', [1, 2], ['string', 'array'], ['mixed', 2, false, 'array'], {name: 'Peter', age: 20});

printArgsInfo([[1, [2, [3, [4, 5]]]], ['string', 'array']]);