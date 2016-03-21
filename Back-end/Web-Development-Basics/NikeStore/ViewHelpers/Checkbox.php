<?php
namespace NikeStore\ViewHelpers;

class Checkbox
{
    public static function input($name, $value, $display, $checked = null)
    {
        echo '<input type="checkbox" name="'.$name.'" value="'.$value.'" $checked />'.$display;
    }
}