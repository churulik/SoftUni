/**
 * Write a JavaScript function extractObjects(array).
 * As a function argument you are given an array of different objects with different data types .
 * Your task is to write the JavaScript function that filters out the Objects
 * (all primitive data type objects and arrays are filtered) and
 * returns a new array with the extracted elements.
 * Note: Try to write the filter algorithm yourself and not use .filter() function.
 * (Hint: Use procedural for loop)
 */
sortLetters('HelloWorld', true);
sortLetters('HelloWorld', false);

function sortLetters(string, boolean) {
    var strSplit = string.split('');
    var sort = strSplit.sort(insensitive);

    if(boolean === true) {
        console.log("'" + sort.join('') + "'");
   }
    if (boolean === false) {
        console.log("'" + strSplit.reverse().join('') + "'");
    }

    function insensitive(str1, str2){
        var str1Lower = str1.toLowerCase();
        var str2Lower = str2.toLowerCase();
        return str1Lower > str2Lower ? 1 : str1Lower < str2Lower ? -1 : 0;
    }
}