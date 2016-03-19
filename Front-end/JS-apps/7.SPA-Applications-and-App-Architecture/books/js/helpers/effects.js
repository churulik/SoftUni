function fadeInText (container, template) {
    $(container).css('opacity', 0);
    $(container).html(template).delay(100).animate({ opacity: 1 }, 700);
}