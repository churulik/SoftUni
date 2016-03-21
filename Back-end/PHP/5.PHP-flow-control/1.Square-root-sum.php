<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Square root</title>
</head>
<body>
    <table border="1">
        <tr>
            <th>Number</th>
            <th>Square</th>
        </tr>
        <?php
        function squareRoot($numbers) {
            $sum = 0;
            foreach ($numbers as $number) {
                $squareNum = sqrt($number);
                $roundNum = round($squareNum, 2)?>
                <tr>
                    <td><?php echo $number; ?></td>
                    <td><?php echo $roundNum; ?></td>
                </tr>
                <?php
                $sum += $roundNum;
            } ?>
            <tr>
                <td><b>Total:</b></td>
                <td><?php echo $sum; ?></td>
            </tr>
        <?php
        }
        squareRoot([0, 2, 4, 6, 8, 9, 10, 11, 94]);
        ?>
    </table>
</body>
</html>
