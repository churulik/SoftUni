createParagraph('wrapper', 'Some text');

function createParagraph(id, text) {
    var p = document.createElement('p'),
        t = document.createTextNode(text);
    p.appendChild(t);
    document.getElementById(id).appendChild(p);
}
