'use strict';

//Change class 'active' in nav bar
(function () {
    $(".nav li").click(function () {
        $(".nav li").removeClass("active");
        $(this).addClass("active");
    });
})();