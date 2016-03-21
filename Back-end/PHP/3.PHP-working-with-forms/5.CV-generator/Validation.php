<?php
if($_POST){
    $firstName = $_POST['firstName'];
    $lastName = $_POST['lastName'];
    $email = $_POST['email'];
    $phone = $_POST['phone'];
    $birth = $_POST['birth'];
    $companyName = $_POST['company'];
    $from = $_POST['from'];
    $to = $_POST['to'];
    $programLang = $_POST['programming_lang'];
    $skillLevel = $_POST['skill_level'];
    $language = $_POST['language'];
    $comprehension = $_POST['comprehension'];
    $reading = $_POST['reading'];
    $writing = $_POST['writing'];


    if(!(ctype_alpha($firstName))|| mb_strlen($firstName) < 2 || mb_strlen($firstName) >= 20) {
        $firstName = 'Please, enter only letters (use between 2 and 20 symbols).';
    }

    if(!(ctype_alpha($lastName))|| mb_strlen($lastName) < 2 || mb_strlen($lastName) >= 20) {
        $lastName = 'Please, enter only letters (use between 2 and 20 symbols).';
    }

    if(!(preg_match('/^[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z0-9]+$/', $email))) {
        $email = 'Please, enter letters, numbers, only one “@” and only one “.”. Example: example@example.com. ';
    }
    if(!(preg_match('/^[+0-9-\s]+$/', $phone))) {
        $phone = 'Please, enter only numbers and “+”, “-”, “ ”.';
    }
    if(isset($_POST['gender'])){
        $gender = $_POST['gender'];
    } else {
        $gender = '-';
    }
    if(empty($birth)){
        $birth = '-';
    }
    if(!(ctype_alpha($companyName)) && (ctype_digit($companyName)) ||
        mb_strlen($companyName) < 2 || mb_strlen($companyName) >= 20) {
        $companyName = 'Please, enter only letters and numbers (use between 2 and 20 symbols).';
    }

    if(empty($from)) {
        $from = '-';
    }
    if(empty($to)){
        $to = '-';
    }


    for ($i = 0; $i < count($language); $i++) {
        if (!(ctype_alpha($language[$i])) || strlen($language[$i]) <= 2 || strlen($language[$i]) > 20) {
            $language[$i] = 'Please, enter only letters (use between 2 and 20 symbols).';
        }
        if ($comprehension[$i]==='-Comprehension-') {
            $comprehension[$i]='-';
        }
        if ($reading[$i]==='-Reading-') {
            $reading[$i] = '-';
        }
        if ($writing[$i]==='-Writing-') {
            $writing[$i] = '-';
        }
    }


    if(!empty($_POST['license'])){
        $drivingLicences = $_POST['license'];
        $drivingLicences = implode(', ', $drivingLicences);
    } else {
        $drivingLicences = "-";
    }
}
?>