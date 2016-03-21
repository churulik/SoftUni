<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Find primes in range</title>
</head>
<body>
    <form action="#" method="GET">
        Start Index: <input type="text" name="start"/>
        End: <input type="text" name="end"/>
        <input type="submit" name="submit" value="Submit"/>
    </form>
    <?php if(isset($_GET['submit'])){
        $start = $_GET['start'];
        $end = $_GET['end'];

        function isPrime ($num) {
            if($num == 1) {
                return false;
            }
            if ($num == 2) {
                return true;
            }
            if ($num %2 == 0) {
                return false;
            }
            for($i = 3; $i <= ceil(sqrt($num)); $i = $i + 2) {
                if($num % $i == 0)
                    return false;
            }

            return true;
        }
        while($start <= $end){
            if(isPrime($start)){
                echo "<b>$start</b>".PHP_EOL;
            } else {
                echo $start.PHP_EOL;
            }
            $start++;
        }
    }
    ?>
</body>
</html>