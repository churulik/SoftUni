function valid(){
    var email = document.getElementById('email'),
        div = document.getElementById('div'),
        validEmail= /@softuni.bg/;

    if(validEmail.test(email.value)) {
        div.innerHTML +=email.value;
        div.style.backgroundColor = '#90EE90';
    } else {
        div.innerHTML +=email.value;
        div.style.backgroundColor = "red";
    }



}
