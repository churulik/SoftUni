var buttons = document.getElementsByClassName('btn');

for (var i = 0; i < buttons.length; i++) {
    buttons[i].addEventListener('click', function(){
        console.log(this.parentNode);
        //console.log(this.previousElementSibling.value)

    })

}
