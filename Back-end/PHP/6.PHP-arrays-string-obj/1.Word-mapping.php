<!doctype html>
<html lang="`">
<head>
    <meta charset="UTF-8">
    <title>Word mapping</title>
</head>
<body>
    <form action="#" method="GET">
        <input type="text" name="input"/>
        <input type="submit" name="submit" value="Count words"/>
    </form>
    <?php
    if(isset($_GET['submit'])) {
        $input = $_GET['input'];
        $toLower = strtolower($input);
        $splStr = preg_split("/[\W]+/", $toLower);
        $removeEmptyArr = array_filter($splStr);
        $count = array_count_values($removeEmptyArr); ?>
        <table border="1">
        <?php foreach ($count as $word => $sum){ ?>
            <tr>
                <td><?php echo $word; ?></td>
                <td><?php echo $sum; ?></td>
            </tr>
        <?php } ?>
        </table>
    <?php }
    ?>
</body>
</html>