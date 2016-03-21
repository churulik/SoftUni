function input() {
    var a = document.getElementById('a').value,
        b = document.getElementById('b').value,
        c = document.getElementById('c').value;

    var discriminant = Math.sqrt(b * b - 4 * a * c);

    if (discriminant === 0) {
        document.getElementById('result').innerHTML = 'x = ' +  - b / (2 * a);
        document.getElementById('result1').innerHTML = '';
    }

    else if (discriminant > 0) {
        document.getElementById('result').innerHTML = 'x1 = ' +  (- b - discriminant) / (2 * a);
        document.getElementById('result1').innerHTML = 'x2 = ' +  (- b + discriminant) / (2 * a);
    }

    else {
        document.getElementById('result').innerHTML = 'No real rots';
        document.getElementById('result1').innerHTML = '';
    }

}
