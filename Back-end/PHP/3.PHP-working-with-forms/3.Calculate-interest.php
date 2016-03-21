<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Calculate interest</title>
</head>
<body>
    <form action="#" method="post" >
        <label for="enter amount">Enter Amount</label>
        <input type="text" name="amount"/>
        <div>
            <span><input type="radio" value="USD" name="currency"/>USD</span>
            <span><input type="radio" value="EUR" name="currency"/>EUR</span>
            <span><input type="radio" value="BGN" name="currency"/>BGN</span>
        </div>
        <label for="CIA">Compound Interest Amount</label>
        <input type="text" name="CIA"/>
        <div>
            <select name="options">
                <option value="6 Months">6 Months</option>
                <option value="1 Year">1 Year</option>
                <option value="2 Years">2 Years</option>
                <option value="5 Years">5 Years</option>
            </select>
            <input type="submit" name="calculate" value="calculate"/>
            <?php
            if(isset($_POST['calculate'])){
                $interestPerMonth = 100 + ($_POST['CIA'] / 12);
                $currentAmount = $_POST['amount'];
                $futureAmount = 0;
                if($_POST['options'] == '6 Months'){
                    for($i = 1; $i <= 6; $i++){
                        $futureAmount = ($currentAmount * $interestPerMonth) / 100;
                        $currentAmount = $futureAmount;
                    }
                } else if($_POST['options'] == '1 Year'){
                    for($i = 1; $i <= 12; $i++){
                        $futureAmount = ($currentAmount * $interestPerMonth) / 100;
                        $currentAmount = $futureAmount;
                    }
                } else if($_POST['options'] == '2 Years'){
                    for($i = 1; $i <= 24; $i++){
                        $futureAmount = ($currentAmount * $interestPerMonth) / 100;
                        $currentAmount = $futureAmount;
                    }
                } else if($_POST['options'] == '5 Years'){
                    for($i = 1; $i <= 60; $i++){
                        $futureAmount = ($currentAmount * $interestPerMonth) / 100;
                        $currentAmount = $futureAmount;
                    }
                }

                if(isset($_POST['currency']) && $_POST['currency'] == 'USD'){
                    echo "$".round($futureAmount, 2);
                } else if(isset($_POST['currency']) && $_POST['currency'] == 'EUR'){
                    echo "€".round($futureAmount, 2);
                } else if(isset($_POST['currency'])&& $_POST['currency'] == 'BGN'){
                    echo "BGN ".round($futureAmount, 2);
                }
            }
            ?>
        </div>
    </form>


</body>
</html>