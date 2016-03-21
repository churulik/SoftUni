<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sidebar builder</title>
    <style>
        h1 {
            font-size: 20px;
            border-bottom: 1px solid #000000;
        }
        div {
            border: 1px solid #000000;
            width: 130px;
            margin-top: 20px;
            border-radius: 15px;
            padding: 10px 0 10px 10px;
            background: linear-gradient(aliceblue, lightskyblue);
        }
        ul  {
            list-style-type: circle;
            padding-left: 20px;
        }
        li {
            text-decoration: underline;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form action="#" method="get">
       Categories: <input type="text" name="categories"/>
        Tags: <input type="text" name="tags"/>
        Months: <input type="text" name="months"/>
        <input type="submit" name="submit" value="Generate"/>
    </form>
    <?php
    if(isset($_GET['submit'])) {
        $categories = $_GET['categories'];
        $tags = $_GET['tags'];
        $months = $_GET['months'];

        $catSplit = explode(", ", $categories);
        $tagSplit = explode(", ", $tags);
        $monthSplit = explode(", ", $months); ?>
        <div>
            <h1>Categories</h1>
                <ul>
                    <?php foreach ($catSplit as $cat) { ?>
                        <li><?php echo $cat ?></li>
                    <?php } ?>
                </ul>
        </div>
        <div>
            <h1>Tags</h1>
                <ul>
                    <?php foreach ($tagSplit as $tag) { ?>
                        <li><?php echo $tag ?></li>
                    <?php } ?>
                </ul>
        </div>
        <div>
            <h1>Months</h1>
                <ul>
                    <?php foreach ($monthSplit as $month) { ?>
                        <li><?php echo $month ?></li>
                    <?php } ?>
                </ul>
        </div>
    <?php }
    ?>
</body>
</html>