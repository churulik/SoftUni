<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sentence extractor</title>
    <style>
        body, textarea, #word {
            width: 250px;
        }
        #word {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form action="#" method="get">
        <textarea name="text" rows="10" placeholder="Text"></textarea>
        <input type="text" name="word" id="word" placeholder="Word"/>
        <input type="submit" name="submit" value="Submit"/>
    </form>
    <?php
    if(isset($_GET['submit'])){
        $text = $_GET['text'];
        $word = $_GET['word'];

        $textSplit = preg_split("/(?<=[.!?])\s+/", $text);
        foreach($textSplit as $sentence){
            if(preg_match("/\b$word\b/", $sentence)){
                if(preg_match("/[.!?]$/", $sentence)){
                    echo $sentence." ";
                }

            }
        }
    }
    ?>
</body>
</html>