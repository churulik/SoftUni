<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
</head>
<body>
    <?php

    ?>
    <form action="#" method="post">
        <label for=""><p>Enter HTML tags:</p></label>
        <input type="text" name="tag"/>
        <input type="submit" name="submit"/>
    </form>
    <?php
    if(isset($_POST['submit'])){
        $validTags = ['a', 'abbr', 'acronym', 'address','applet', 'applet','area', 'b','base', 'basefont',
            'bdo','bgsound','big','blockquote','blink','body','br','button','caption', 'center','cite',
            'code','col','colgroup','dd','dfn','del','dir','dl','div','dt', 'embed','em','fieldset','font',
            'form','frame','frameset','h1' ,'h2', 'h3' ,'h4' ,'h5', 'h6' ,'head' ,'hr', 'html' ,'iframe' ,
            'img', 'input' ,'ins' ,'isindex', 'i' ,'kbd' ,'label', 'legend' ,'li' ,'link', 'marquee' ,'menu' ,
            'meta', 'noframe' ,'noscript' ,'optgroup', 'option' ,'ol' ,'p', 'pre' ,'q' ,'s', 'script' ,'select' ,
            'small', 'span' ,'strike' ,'strong', 'style' ,'sub' ,'sup', 'table' ,'td' ,'th', 'tr' ,'tbody' ,
            'textarea', 'tfoot' ,'thead' ,'title', 'tt' ,'u' ,'ul' ,'var'];
        session_start();
        if(!isset($_SESSION["score"])){
            $_SESSION["score"] = 0;
        }
        if(in_array($_POST['tag'], $validTags)) {
            echo "<h1>Valid HTMIL tag!</h1>";
            $_SESSION["score"]+= 1;

        } else {
            echo "<h1>Invalid HTMIL tag!</h1>";
        }
        echo "<h1>Score: {$_SESSION["score"]}</h1>";

    }
    ?>
</body>
</html>