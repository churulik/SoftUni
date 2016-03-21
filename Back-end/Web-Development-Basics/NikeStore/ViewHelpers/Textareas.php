<?php
namespace NikeStore\ViewHelpers;

class Textareas
{
    public static function input($name, $id = null, $cols = 30, $rows = 10)
    {
        echo '<textarea name="'.$name.'" id="'.$id.'" cols="'.$cols.'" rows="'.$rows.'"></textarea>';
    }
}