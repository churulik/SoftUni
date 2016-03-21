var HTMLGen = {
    createParagraph: function createParagraph(id, text) {
        var p = document.createElement('p'),
            t = document.createTextNode(text);
        p.appendChild(t);
        document.getElementById(id).appendChild(p);
    },
    createDiv: function createDiv(id, addClass) {
        var div = document.createElement('div');
        div.className = addClass;
        document.getElementById(id).appendChild(div);

    },
    createLink: function createLink(id, text, url) {
        var a = document.createElement('a'),
            t = document.createTextNode(text);
        a.appendChild(t);
        a.href = url;
        document.getElementById(id).appendChild(a);
    }
};


HTMLGen.createParagraph('wrapper', 'Soft Uni');
HTMLGen.createDiv('wrapper', 'section');
HTMLGen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');
