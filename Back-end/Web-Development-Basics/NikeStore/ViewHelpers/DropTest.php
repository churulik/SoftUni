<?php
namespace NikeStore\ViewHelpers;

class DropTest
{
    private $output;
    private $options = '';
    private $attributes = [];

    public static function create()
    {
        return new self();
    }

    public function addAttr($attrName, $attrValue)
    {
        return $this;
    }

    public function setDefaultOption($valueContent)
    {
        $this->options = "\t<option value=\"\">$valueContent</option>".$this->options;
        return $this;
    }

    public function setContent($content, $idKey = 'id', $valueKey = 'value', $keySelected = null, $valueSelected = null)
    {
        foreach($content as $model){
            $this->options .= "<option";
            if($keySelected && $valueKey){
                if($model[$keySelected] == $valueSelected) {
                    $this->options .= " selected ";
                }
            }
            $this->options .= "value=\"{$model[$idKey]}\">" . $model[$valueKey] . "</option>\n";
        }

        return $this;
    }

    public function render()
    {
        $output = "select";
        foreach($this->attributes as $k => $v) {
            $output .= " ". $k."=".'"'.$v.'"';
            $output .= ">\n";
            $output .= $this->options;
            $output .= "</select>";

            echo $output;
        }
    }
}