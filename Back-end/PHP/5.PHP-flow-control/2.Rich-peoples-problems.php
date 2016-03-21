<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Rich people's problems</title>
</head>
<body>
    <form action="#" method="get">
        Enter cars <input type="text" name="cars"/>
        <input type="submit" name="submit" value="Show result"/>
    </form>

    <?php
    if(isset($_GET['submit'])) {
        $cars = $_GET['cars'];
        $splitCars = explode(", ", $cars);
        $colors = array ('yellow', 'blue', 'green', 'black', 'red', 'white',
            'silver', 'brown', 'darkgrey', 'darkred');

        ?>
    <table border="1">
        <tr>
            <th>Car</th>
            <th>Color</th>
            <th>Count</th>
        </tr>
        <?php foreach ($splitCars as $car){
            shuffle($colors);?>
          <tr>
              <td><?php echo $car; ?></td>
              <td><?php echo $colors[0]; ?></td>
              <td><?php echo rand(1, 5);?></td>
          </tr>
        <?php } ?>
    </table>
    <?php }
    ?>

</body>
</html>