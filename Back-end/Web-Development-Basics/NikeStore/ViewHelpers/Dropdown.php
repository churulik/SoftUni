<?php
namespace NikeStore\ViewHelpers;

class Dropdown
{

    public static function open($name, $id = null)
    {
        echo '<select name="'.$name.'" id="'.$id.'">';
    }
    public static function option($value, $text){
        echo "<option value=\"'.$value.'\">$text</option>";
    }
    public static function close()
    {
        return '</select>';
    }

}

