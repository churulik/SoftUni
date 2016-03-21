<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Text filter</title>
    <style>
        body, textarea, #banlist {
            width: 250px;
        }
        #banlist {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form action="#" method="get">
        <textarea name="text" rows="10" placeholder="Text"></textarea>
        <input type="text" name="banlist" id="banlist" placeholder="Banlist"/>
        <input type="submit" name="submit" value="Submit"/>
    </form>
    <?php
    if(isset($_GET['submit'])){
        $text = $_GET['text'];
        $ban = $_GET['banlist'];
        $banSplit = explode(", ", $ban);

        foreach($banSplit as $word){
            $asterisksLength = "";
            for ($i = 0; $i < strlen($word); $i++){
                $asterisksLength .= "*";
            }
            echo preg_replace("/$word/", "$asterisksLength", "$text");
        }
    }
    ?>
</body>
</html>