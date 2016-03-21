function showHide() {
    var checkbox = document.getElementById('checkbox'),
        textbox = document.getElementById('textbox');

    if(checkbox.checked){
        textbox.style.visibility = "visible";
    } else {
        textbox.style.visibility = "hidden";
    }
}
