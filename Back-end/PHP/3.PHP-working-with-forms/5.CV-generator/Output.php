<?php
include('Validation.php')
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        .outerTable {
            margin-bottom: 15px;
        }
    </style>
    <script src="Print.js"></script>
</head>
<body>
    <h1>CV</h1>
    <table border='1' class="outerTable">
        <thead>
        <tr>
            <th colspan='2'>Personal Information</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>First Name</td>
            <td><?php echo $firstName; ?></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><?php echo $lastName; ?></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><?php echo $email; ?></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td><?php echo $phone; ?></td>
        </tr>
        <tr>
            <td>Gender</td>
            <td><?php echo $gender; ?></td>
        </tr>
        <tr>
            <td>Birth Date</td>
            <td><?php echo $birth; ?></td>
        </tr>
        <tr>
            <td>Nationality</td>
            <td><?php echo $_POST['nationality']; ?></td>
        </tr>
        </tbody>
    </table>

    <table border='1' class="outerTable">
        <thead>
        <tr>
            <th colspan='2'>Last Work Position</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Company Name</td>
            <td><?php echo $companyName; ?></td>
        </tr>
        <tr>
            <td>From</td>
            <td><?php echo $from; ?></td>
        </tr>
        <tr>
            <td>To</td>
            <td><?php echo $to; ?></td>
        </tr>
        </tbody>
    </table>

    <table border='1' class="outerTable">
        <thead>
        <tr>
            <th colspan='2'>Computer Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Programming language </td>
            <td>
                <table border='1'>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Skill level</th>
                    </tr>
                    </thead>
                    <tbody>
                        <?php for ($i = 0; $i < count($programLang); $i++): ?>
                            <tr>
                                <td><?php echo $programLang[$i]; ?></td>
                                <td><?php echo $skillLevel[$i]; ?></td>
                            </tr>
                        <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        </tbody>
    </table>

    <table border='1' class="outerTable">
        <thead>
        <tr>
            <th colspan='2'>Other Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Languages</td>
            <td>
                <table border='1'>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Comprehension</th>
                        <th>Reading</th>
                        <th>Writing</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php for ($i = 0; $i < count($language); $i++):?>
                    <tr>
                        <td><?php echo $language[$i]?></td>
                        <td><?php echo $comprehension[$i]?></td>
                        <td><?php echo $reading[$i]?></td>
                        <td><?php echo $writing[$i]?></td>
                    </tr>
                    <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>Driver's license</td>
            <td colspan='4'><?php echo $drivingLicences; ?></td>
        </tr>
        </tbody>
    </table>
    <button id="returnBtn" onclick="location.href='Form.php'">Return to the form</button>
    <button id="printBtn"  onclick="printPage()">Print this page</button>
</body>
</html>