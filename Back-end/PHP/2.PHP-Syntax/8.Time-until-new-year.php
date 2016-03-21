<?php

$now = getdate();
$nowFormat = new DateTime("$now[year]-$now[mon]-$now[mday] $now[hours]:$now[minutes]:$now[seconds]");
$newYear = new DateTime('2016-01-01 00:00:00');
$interval = $nowFormat->diff($newYear);

$hours = ($interval -> h) + (($interval -> days) * 24);
$minutes = ($interval -> i) + $hours * 60;
$seconds = ($interval -> s) + $minutes * 60;

echo "Hours until new year : ".$hours.PHP_EOL;
echo "Minutes until new year : ".number_format($minutes, 0, ' ', ' ').PHP_EOL;
echo "Seconds until new year : ".number_format ($seconds, 0, ' ', ' ').PHP_EOL;
echo "Days:Hours:Minutes:Seconds ".$interval->days.":".$interval->h.":".$interval->m.":".$interval->s;
