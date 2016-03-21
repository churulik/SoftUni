<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Table</title>
    <link rel="stylesheet" href="6.HTML-table.css"/>
</head>
<body>
    <table border="1">

        <?php
        function htmlTable($data){
            $name = $data[0];
            $phoneNum = $data[1];
            $age = $data[2];
            $address = $data[3];

            echo "<tr><td class='key'>Name</td><td class='value'>{$name}</td></tr>";
            echo "<tr><td class='key'>Phone number</td><td class='value'>{$phoneNum}</td></tr>";
            echo "<tr><td class='key'>Age</td><td class='value'>{$age}</td></tr>";
            echo "<tr><td class='key'>Address</td><td class='value'>{$address}</td></tr>";
        }

        htmlTable([
            'Gosho',
            '0882-321-423',
            '24',
            'Hadji Dimitar'
        ]);
        ?>

    </table>
</body>
</html>

