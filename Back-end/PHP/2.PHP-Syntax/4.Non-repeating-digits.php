<?php
$n = 1234;
$n_length = strlen((string)$n);
$result = [];

if($n_length > 2) {
    if ($n_length > 3) {
        $n = 987;
    }
    for($i = 102; $i <= $n; $i++){
        $firstDigit = substr($i, 0, 1);
        $secondDigit = substr($i, 1, 1);
        $thirdDigit = substr($i, 2, 2);
        if ($firstDigit != $secondDigit &&
            $firstDigit != $thirdDigit &&
            $secondDigit != $thirdDigit) {
            array_push($result, $i);
        }
    }
} else {
    echo "no";
}

echo implode(", ", $result);