<?php
//$person = array("Edison", "Pirlo", "Wankel", "Bilbo");
//$creator = array('Light bulb' => 'Edison', 'Soccer' => 'Pirlo', "Apple" => 'Me');
//sort($person);
//asort($creator);
//
////foreach($person as $sortedName) {
////    echo $sortedName.PHP_EOL;
////}
//foreach($creator as $invention => $inventor){
//    echo "{$invention} created {$inventor}".PHP_EOL;
//}

class Person
{
    public $name = '';

    function name($newname = NULL)
    {
        if(!is_null($newname)) {
            $this->name = $newname;
        }

        return $this->name;
    }
}

$ed = new Person;
$ed->name('Edison');
echo "Hello, {$ed->name}";

