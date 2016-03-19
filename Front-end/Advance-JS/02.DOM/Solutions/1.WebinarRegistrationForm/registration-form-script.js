function getElementById(element){
    return document.getElementById(element)
}
function displayInvoice(){
    if(getElementById('invoice-checkbox').checked){
        getElementById('display-invoice').style.display = 'block';
    } else {
        getElementById('display-invoice').style.display = 'none';
    }
}
