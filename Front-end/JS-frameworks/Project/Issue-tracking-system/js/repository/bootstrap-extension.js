(function () {
    'use strict';
    
    //Change class 'active' on nav menus
    $(".nav li").click(function () {
        $(".nav li").removeClass("active");
        $(this).addClass("active");
    });
})();