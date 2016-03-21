<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Modify string</title>
</head>
<body>
    <form action="#" method="GET">
        <input type="text" name="input"/>
        <input type="radio" name="check" value="Palindrome" checked/>Check Palindrome
        <input type="radio" name="check" value="Reverse String"/>Reverse String
        <input type="radio" name="check" value="Split"/>Split
        <input type="radio" name="check" value="Hash String"/>Hash String
        <input type="radio" name="check" value="Shuffle String"/>Shuffle String
        <input type="submit" name="submit" value="Submit"/>
    </form>
    <?php
    if(isset($_GET['submit'])){
        $input = $_GET['input'];
        $check = $_GET['check'];

        if($check === 'Palindrome'){
            if($input === strrev($input)) {
                echo "$input is a palindrome!";
            } else {
                echo "$input is not a palindrome!";
            }
        } elseif($check === "Reverse String") {
            echo strrev($input);

        } elseif($check === "Split"){
            $strSplit = str_split($input);
            foreach ($strSplit as $letters){
                echo $letters." ";
            }
        } elseif($check === "Hash String") {
            echo crypt($input, 'a8ied$2x$sag123@_sdasa#');

        } elseif($check === "Shuffle String"){
            echo str_shuffle($input);
        }
    }
    ?>
</body>
</html>