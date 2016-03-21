<?php
namespace NikeStore\Configs;

class Autoloader
{
    public static function init()
    {
        spl_autoload_register(function($class) {
            $split = explode('\\',$class);
            array_shift($split);
            $fullClassName = implode(DIRECTORY_SEPARATOR, $split);
            if(file_exists($fullClassName.'.php')){
                require_once $fullClassName.'.php';
            }
            if(file_exists("models/$class.php")){
                require_once "models/$class.php";
            }
        });
    }
}