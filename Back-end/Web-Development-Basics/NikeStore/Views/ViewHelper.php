<?php
namespace NikeStore\Views;

class ViewHelper
{
    public function radio($name){
        return '<input type="radio" name="category" value="$name" />'.$name;
    }
}