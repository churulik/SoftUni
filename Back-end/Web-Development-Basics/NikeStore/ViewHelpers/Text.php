<?php
namespace NikeStore\ViewHelpers;

class Text
{
    public static function input($name, $id = null, $class = null, $placeholder = null)
    {
        echo '<input type="text" name="'.$name.'" id="'.$id.'" class="'.$class.'" placeholder="'.$placeholder.'"/>';
    }
}