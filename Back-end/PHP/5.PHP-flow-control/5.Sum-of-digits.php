<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sum of digits</title>
</head>
<body>
    <form action="#" method="GET">
        Input string: <input type="text" name="input"/>
        <input type="submit" name="submit" value="Submit"/>
        <?php
        if(isset($_GET['submit'])){
            $input = $_GET['input'];
            $numbers = explode(", ", $input); ?>
            <table border="1">
            <?php foreach ($numbers as $num){
                $sum = 0;
                if(is_numeric($num)) {
                    for ($i = 0; $i < strlen($num); $i++ ){
                        $subNum = substr($num, $i, 1);
                        $toInt = (int)$subNum;
                        $sum += $toInt;
                    }
                    ?>

                        <tr>
                            <td><?php echo $num ?></td>
                            <td><?php echo $sum ?></td>
                        </tr>

                <?php $sum = 0; } else { ?>
                        <tr>
                            <td><?php echo $num ?></td>
                            <td><?php echo "I cannot sum that" ?></td>
                        </tr>
                <?php }
            } ?>
            </table>
        <?php }
        ?>
    </form>
</body>
</html>