function printPage() {

    var printButton = document.getElementById("printBtn");
    var returnButton = document.getElementById("returnBtn");
    printButton.style.visibility = 'hidden';
    returnButton.style.visibility = 'hidden';
    window.print();
    printButton.style.visibility = 'visible';
    returnButton.style.visibility = 'visible';
}
