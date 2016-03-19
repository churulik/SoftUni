$(document).ready(function () {
    const active = 'active';
    const oldActive = 'oldActive';
    const intervalRate = 5000;

    $('.slide').first().addClass(active);
    $('.slide').hide();
    $('.active').show();

    function nextSlide() {
        $('.active').removeClass(active).addClass(oldActive);
        if ($('.oldActive').is(':last-child')) {

            $('.slide').first().addClass(active);
        } else {
            $('.oldActive').next().addClass(active);
        }

        $('.oldActive').removeClass(oldActive);
        $('.slide').fadeOut();
        $('.active').fadeIn();
    }

    var interval = setInterval(function () {
        nextSlide();
    }, intervalRate);

    $('#email').click(function () {
        clearInterval(interval)
    });

    function resetInterval() {
        clearInterval(interval);
        interval = setInterval(function () {
            nextSlide();
        }, intervalRate);
    }

    $('#next').click(function () {
        nextSlide();
        resetInterval();

    });

    $('#prev').click(function () {
        $('.active').removeClass(active).addClass(oldActive);
        if ($('.oldActive').is(':first-child')) {
            $('.slide').last().addClass(active);
        } else {
            $('.oldActive').prev().addClass(active);
        }

        $('.oldActive').removeClass(oldActive);
        $('.slide').fadeOut();
        $('.active').fadeIn();
        resetInterval();
    })
});
