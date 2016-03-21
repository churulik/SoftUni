<!doctype html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <title>Most frequent tag</title>
</head>
<body>
    <form method='get' action='#'>
        <input type='text' name='name' />
        <input type='submit' name='submit'/>
    </form>

    <?php

    if(isset($_GET['submit'])){
        $split = explode(', ', $_GET['name']);
        $count = array_count_values($split);
        arsort($count);
        foreach ($count as $key => $value) {
            echo "$key : $value <br />";
        }
        echo "Most Frequent Tag is: ".current(array_keys($count));
    }
    ?>
</body>
</html>
