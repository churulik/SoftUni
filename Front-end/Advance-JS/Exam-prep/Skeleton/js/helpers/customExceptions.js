function lettersOrWhitespaces(parametar, message) {
    var regex = /^[A-Za-z\s]+$/g;
    if(!regex.test(parametar)){
        throw new Error(message)
    }
}

function digits(parametar, message) {
    if(isNaN(parametar)){
        throw new Error(message);
    }
}