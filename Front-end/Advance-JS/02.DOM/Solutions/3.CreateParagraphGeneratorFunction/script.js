function createParagraph(id, text) {
    var p = document.createElement('p');
    var textNode = document.createTextNode(text);
    p.appendChild(textNode);
    document.getElementById(id).appendChild(p)
}

createParagraph('wrapper', 'Some text');

