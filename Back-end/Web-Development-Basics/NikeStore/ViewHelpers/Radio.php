<?php
namespace NikeStore\ViewHelpers;

class Radio
{
    public static function input($name, $value, $display, $checked = null)
    {
        echo '<input type="radio" name="'.$name.'" value="'.$value.'"'.$checked.' />'.$display;
    }

}