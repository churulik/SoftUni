<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Annual expenses</title>
</head>
<body>
    <form action="#" method="get">
        Enter number of years: <input type="text" name="years">
        <input type="submit" name="submit" value="Show costs"/>
    </form>
    <?php if(isset($_GET['submit'])){?>
        <table border="1">
            <tr>
                <th>Year</th>
                <th>January</th>
                <th>February</th>
                <th>March</th>
                <th>April</th>
                <th>May</th>
                <th>June</th>
                <th>July</th>
                <th>August</th>
                <th>September</th>
                <th>October</th>
                <th>November</th>
                <th>December</th>
                <th>Total:</th>
            </tr>
    <?php
        $years = $_GET['years'];

        $currentYear = 2015;
        $totalExpenses = 0;
        while($years >= 0){?>
            <tr>
                <td><?php echo $currentYear ?></td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td>
                    <?php $expenses = rand(0, 999);
                    $totalExpenses += $expenses;
                    echo $expenses; ?>
                </td>
                <td><?php echo $totalExpenses ?></td>
            </tr>
            <?php $years--;
            $currentYear--;
            $totalExpenses = 0;
        } ?>
        </table>
    <?php }?>
</body>
</html>