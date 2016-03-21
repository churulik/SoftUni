<?php
function variable($input){

    if(is_int($input) || is_float($input)){
        var_dump($input);
    } else {
        echo gettype($input);
    }

}

variable(
    //"hello"
    15
    //1.234
    //array(1,2,3)
    //(object)[2,34]
);

