function getElementById(element) {
    return document.getElementById(element)
}

function emailValidation() {
    var div = getElementById('display-validation');
    var email = getElementById('email').value;

    if (email.replace(/ /g, '') === '') {
        return div.style.display = 'none';
    }

    div.innerHTML = email;
    div.style.display = 'block';

    var regex = /^(([^<>()[\]\\.,;:\s@']+(\.[^<>()[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (regex.test(email)) {
        div.style.backgroundColor = '#90EE90';
    } else {
        div.style.backgroundColor = '#FF0000';
    }
}