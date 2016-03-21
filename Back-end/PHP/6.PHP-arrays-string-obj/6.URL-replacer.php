<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <style>
        body, textarea {
            width: 250px;
        }
    </style>
</head>
<body>
    <form action="#" method="get">
        <textarea name="text" rows="10" placeholder="Text"></textarea>
        <input type="submit" name="submit" value="Submit"/>
    </form>
    <?php
    if(isset($_GET['submit'])){
        $text = $_GET['text'];
        echo htmlspecialchars(preg_replace('/(<a href=")(.*?)(">)(.*?)(<\/a>)/', '[URL=$2]$4[/URL]', $text));
    }
    ?>
</body>
</html>