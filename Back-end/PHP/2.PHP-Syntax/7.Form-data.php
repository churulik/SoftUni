<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Form data</title>
    <style>
        p {
            margin: 0;
            padding-bottom: 5px;
        }
    </style>
</head>
<body>
    <form action="#" method="post">
        <p></p><input type="text" name="name" placeholder="Name..."/></p>
        <p><input type="text" name="age" placeholder="Age..."/></p>
        <p><input type="radio" name="male">Male</p>
        <p><input type="radio" name="female">Female</p>
        <p><input type="submit" name="submit"/></p>
    </form>

 <?php
 if (isset($_POST['submit'])) {
     if (isset($_POST['name']) && $_POST['name'] != ''){
         echo "My name is ".htmlspecialchars($_POST['name']).". ";
     }
     if (isset($_POST['age']) && $_POST['age'] != ''){
         echo "I am ".htmlspecialchars($_POST['age'])." years old. ";
     }

     if (isset ($_POST['male'])) {
         echo "I am male.";
     } else if (isset($_POST['female'])) {
         echo "I am female.";
     }
 }
?>
</body>
</html>