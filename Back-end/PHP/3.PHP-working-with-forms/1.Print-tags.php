<!doctype html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <title>Print tags</title>
</head>
<body>
    <form method='get' action='#'>
        <input type='text' name='name' />
        <input type='submit' name='submit'/>
    </form>

    <?php
    if(isset($_GET['submit'])){
        $split = explode(", ", $_GET['name']);
        foreach ($split as $key => $value){
            echo "$key : $value <br />";
        }
    }
    ?>
</body>
</html>

