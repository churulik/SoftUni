var specialConsole = (function () {
    function ExecuteRequest(arguments) {
        var argumentsLength = arguments.length;
        if (argumentsLength === 0) {
            console.log()
        } else if (argumentsLength === 1) {
            console.log(arguments[0])
        } else {
            var message = arguments[0];
            var numberOfPlaceholdersRegex = /({[0-9]})/g;
            var numberOfPlaceholders = message.match(numberOfPlaceholdersRegex);
            if (numberOfPlaceholders.length !== argumentsLength - 1) {
                throw new Error('The number of placeholders (' + numberOfPlaceholders.length + ') ' +
                    'and arguments (' + (argumentsLength - 1) + ') is different. ' +
                    'Enter valid number of placeholders and arguments.');
            }

            for (var i = 1; i < argumentsLength; i++) {
                var currentPlaceholder = '{' + (i - 1) + '}';

                var placeholderRegex = new RegExp('({[' + (i - 1) + ']})');
                var findPlaceholder = message.match(placeholderRegex);
                if (findPlaceholder == null) {
                    throw new Error('Enter valid placeholder')
                }

                message = message.replace(currentPlaceholder, arguments[i]);
            }

            console.log(message)
        }
    }

    function writeLine() {
        ExecuteRequest(arguments)
    }

    function writeError() {
        ExecuteRequest(arguments)
    }

    function writeWarning() {
        ExecuteRequest(arguments)
    }

    function writeInfo() {
        ExecuteRequest(arguments)
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
        writeInfo: writeInfo
    };
})();

specialConsole.writeLine();
specialConsole.writeLine('Message: hello');
specialConsole.writeLine('Message: {0} {1}', 'hello', 'da');
specialConsole.writeLine('Object: {0}', {
    name: 'Gosho', toString: function () {
        return this.name
    }
});
specialConsole.writeError('Error: {0}', 'A fatal error has occurred.');
specialConsole.writeWarning('Warning: {0}', 'You are not allowed to do that!');
specialConsole.writeInfo('Info: {0}', 'Hi there! Here is some info for you.');
specialConsole.writeError('Error object: {0}', {
    msg: 'An error happened', toString: function () {
        return this.msg
    }
});
