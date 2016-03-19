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

printArgsInfo.call();

printArgsInfo.call(null, 1, 2.3, 'Name', [], undefined, {});

printArgsInfo.apply();

printArgsInfo.apply(null, [1, 2.3, 'Name', [], undefined, {}]);