<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Combo box</title>
</head>
<body>
    <form action="#" method="post">
        <input type="text" list="continents" name="continents"/>
        <datalist id="continents">
            <option value="Europe" name="Europe" onclick="">Europe</option>
            <option value="Asia" name="Asia">Asia</option>
            <option value="North America" name="North America">North America</option>
            <option value="South America" name="South America">South America</option>
            <option value="Australia" name="Australia">Australia</option>
            <option value="Africa" name="Africa">Africa</option>
        </datalist>
        <input type="text" list="countries" name="countries"/>
        <datalist id="countries">
            <option value="Europe" name="Europe">Europe</option>
            <option value="Asia" name="Asia">Asia</option>
            <option value="North America" name="North America">North America</option>
            <option value="South America" name="South America">South America</option>
            <option value="Australia" name="Australia">Australia</option>
            <option value="Africa" name="Africa">Africa</option>
        </datalist>
    </form>
    <?php
    if(isset($_POST['Australia'])){
        echo "<option value='Europe' name='Europe'>Europe</option>";
    }
    ?>
</body>
</html>