function slider() {
    $('#1').show('fade', 1000)
        .delay(5000)
        .hide('slide', {direction: 'left'}, 1000);
    var slideCount = $('.slider img').size();
    var count = 2;

    setInterval(function () {
        $('#' + count).show('slide', {direction: 'right'}, 500)
            .delay(5000)
            .hide('slide', {direction: 'left'}, 500);
        if(count == slideCount){
            count = 1;
        } else {
            count += 1;
        }
    }, 6500)
}
