<?php
include('Validation.php');
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <script src="Add-remove.js"></script>
    <style>
        fieldset {
            width: 600px;
            margin-bottom: 10px;
        }
        p {
            margin: 0;
        }
    </style>
</head>
<body>
    <form action="Output.php" method="post">
        <fieldset>
            <legend>Personal Information</legend>
            <div>
                <input type="text" placeholder="First Name" name="firstName" />
            </div>
            <div>
                <input type="text" placeholder="Last Name" name="lastName" />
            </div>
            <div>
                <input type="text" placeholder="Email" name="email" />
            </div>
            <div>
                <input type="text" placeholder="Phone Number" name="phone" />
            </div>
            <div>
                Female<input type="radio" name="gender" value="Female"/>
                Male<input type="radio" name="gender" value="Male"/>
            </div>
            <div>
                <label for="birth"><p>Birth date</p></label>
                <input type="date" name="birth" />
            </div>
            <div>
                <label for="nationality"><p>Nationality</p></label>
                <select name="nationality" >
                    <option value="Bulgarian">Bulgarian</option>
                    <option value="Other">Other</option>
                </select>
            </div>
        </fieldset>
        <fieldset>
            <legend>Last Work Position</legend>
            <div>
                <label for="company_name">Company Name</label>
                <input type="text" name="company" pattern="[A-Za-z0-9]{2,20}"
                       title="Only letters and numbers, between 2 and 20 symbols."/>
            </div>
            <div>
                <label for="from">From</label>
                <input type="date" name="from" />
            </div>
            <div>
                <label for="to">To</label>
                <input type="date" name="to" />
            </div>
        </fieldset>
        <fieldset>
            <legend>Computer Skills</legend>
            <div>
                <label for="programming_lang">Programming Languages</label>
                <div>
                    <input type="text" name="programming_lang[]" />
                    <select name="skill_level[]">
                        <option value="beginner">Beginner</option>
                        <option value="intermediate">Intermediate</option>
                        <option value="advanced">Advanced</option>
                    </select>
                </div>


                <div id="newPcSkill">

                </div>
                <input type="button" onclick="removePcSkills('programming_lang' + nextPcSkillsId)" value="Remove Language" />
                <input type="button" onclick="addPcSkills()" value="Add Language" />
            </div>

        </fieldset>
        <fieldset>
            <legend>Other Skills</legend>
            <label for="languages">Languages</label>
            <div>
                <input type="text" name="language[]" />
                <select name="comprehension[]">
                    <option value="-Comprehension-">-Comprehension-</option>
                    <option value="Beginner">Beginner</option>
                    <option value="Intermediate">Intermediate</option>
                    <option value="Advanced">Advanced</option>
                </select>
                <select name="reading[]">
                    <option value="-Reading-">-Reading-</option>
                    <option value="Beginner">Beginner</option>
                    <option value="Intermediate">Intermediate</option>
                    <option value="Advanced">Advanced</option>
                </select>
                <select name="writing[]">
                    <option value="-Writing-">-Writing-</option>
                    <option value="Beginner">Beginner</option>
                    <option value="Intermediate">Intermediate</option>
                    <option value="Advanced">Advanced</option>
                </select>
            </div>

            <div id="newOtherSkill">

            </div>
            <input type="button" onclick="removeOtherSkills('language' + nextOtherSkillsId)" value="Remove Language" />
            <input type="button" onclick="addOtherSkills()" value="Add Language"/>
            <div>
                <label for="driver_license"><p>Driver's License</p></label>
                B<input type="checkbox" name="license[]" value="B"/>
                A<input type="checkbox" name="license[]" value="A"/>
                C<input type="checkbox" name="license[]" value="C"/>
            </div>
        </fieldset>
        <input type="submit" value="Generate CV" name="GenerateCV"/>
    </form>


</body>
</html>