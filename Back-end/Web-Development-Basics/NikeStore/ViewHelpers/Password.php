<?php
namespace NikeStore\ViewHelpers;

class Password
{
    public static function input($name, $id = null, $class = null, $placeholder = null)
    {
        echo '<input type="password" name="'.$name.'" id="'.$id.'" class="'.$class.'" placeholder="'.$placeholder.'"/>';
    }
}