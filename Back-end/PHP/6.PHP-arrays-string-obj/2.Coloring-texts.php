<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Coloring texts</title>
</head>
<body>
    <form action="#" method="get">
        <input type="text" name="text"/>
        <input type="submit" name="submit" value="Color text"/>
    </form>

    <?php
    if(isset($_GET['submit'])){
        $text = $_GET['text'];
        $splitText = str_split($text);

        foreach ($splitText as $char) {
            $asciiValue = ord($char);
            if($asciiValue % 2 == 0){?>
            <span style="color: red"><?php echo $char ?></span>
            <?php } else {?>
                <span style="color: blue"><?php echo $char ?></span>
                <?php }?>
        <?php }
    }
    ?>
</body>
</html>