<?php
$firstSunday = new DateTime('sunday this week');
$lastSunday = new DateTime('last sunday of this month');
$lastSunday = $lastSunday->modify('+1week');
$interval = new DateInterval('P1W');

$result = new DatePeriod($firstSunday, $interval, $lastSunday);

foreach($result as $sunday){
    echo $sunday->format("j F, Y").PHP_EOL;
}
