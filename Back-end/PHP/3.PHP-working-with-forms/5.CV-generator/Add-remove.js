var nextPcSkillsId = 0,
    nextOtherSkillsId = 0;

function addPcSkills() {
    nextPcSkillsId++;
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'programming_lang' + nextPcSkillsId);
    newDiv.innerHTML = "<input type='text' name='programming_lang[]' /> " +
    "<select name='skill_level[]'> " +
    "<option value='beginner'>Beginner</option> " +
    "<option value='intermediate'>Intermediate</option> " +
    "<option value='advanced'>Advanced</option> " +
    "</select>";
    document.getElementById('newPcSkill').appendChild(newDiv);
}

function removePcSkills(id) {
    nextPcSkillsId--;
    var newDiv = document.getElementById(id);
    document.getElementById('newPcSkill').removeChild(newDiv);
}

function addOtherSkills() {
    nextOtherSkillsId++;
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'language' + nextOtherSkillsId);
    newDiv.innerHTML = '<input type="text" name="language[]" /> ' +
    '<select name="comprehension[]"> ' +
    '<option value="-Comprehension-">-Comprehension-</option> ' +
    '<option value="Beginner">Beginner</option> ' +
    '<option value="Intermediate">Intermediate</option> ' +
    '<option value="Advanced">Advanced</option> ' +
    '</select> ' +
    '<select name="reading[]"> ' +
    '<option value="-Reading-">-Reading-</option> ' +
    '<option value="Beginner">Beginner</option> ' +
    '<option value="Intermediate">Intermediate</option> ' +
    '<option value="Advanced">Advanced</option> ' +
    '</select> ' +
    '<select name="writing[]"> ' +
    '<option value="-Writing-">-Writing-</option> ' +
    '<option value="Beginner">Beginner</option> ' +
    '<option value="Intermediate">Intermediate</option> ' +
    '<option value="Advanced">Advanced</option> ' +
    '</select>';
    document.getElementById('newOtherSkill').appendChild(newDiv);
}

function removeOtherSkills(id) {
    nextOtherSkillsId--;
    var newDiv = document.getElementById(id);
    document.getElementById('newOtherSkill').removeChild(newDiv);
}




