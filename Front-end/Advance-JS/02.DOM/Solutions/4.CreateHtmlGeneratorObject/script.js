function createElement(element) {
    return document.createElement(element);
}

function createTextNode(text) {
    return document.createTextNode(text);
}

function appendChildToId(parent, child) {
    return document.getElementById(parent).appendChild(child)
}

var HTMLGenerator = (function () {
    function createParagraph(id, text) {
        var p = createElement('p');
        var textNode = createTextNode(text);
        p.appendChild(textNode);
        appendChildToId(id, p)
    }

    function createDiv(id, className) {
        var div = createElement('div');
        div.className += className;
        appendChildToId(id, div)
    }

    function createLink(id, text, url) {
        var a = createElement('a');
        a.href += url;
        var textNode = createTextNode(text);
        a.appendChild(textNode);
        appendChildToId(id, a)
    }

    return {
        createParagraph: createParagraph,
        createDiv: createDiv,
        createLink: createLink
    }
})();

HTMLGenerator.createParagraph('wrapper', 'Soft Uni');
HTMLGenerator.createDiv('wrapper', 'section');
HTMLGenerator.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');

