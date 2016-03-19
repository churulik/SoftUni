var domModule = (function () {
    function appendChild(parent, child) {
        var parentNode = document.querySelector(parent);
        return parentNode.appendChild(child);
    }

    function removeChild(parent, child) {
        var parentNode = document.querySelector(parent);
        var childNode = parentNode.querySelector(child);
        return parentNode.removeChild(childNode);
    }

    function addHandler(element, eventType, eventHandler) {
        var query = document.querySelectorAll(element);
        var queryLength = query.length;
        for (var i = 0; i < queryLength; i++) {
            query[i].setAttribute(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };

})();
var liElement = document.createElement('li');

domModule.appendChild('.birds-list', liElement);

domModule.removeChild('ul.birds-list', 'li:first-child');

domModule.addHandler('li.bird', 'click', function () {
    alert('I\'m a bird!')
});

var elements = domModule.retrieveElements('.bird');
var elementsLength = elements.length;
for (var i = 0; i < elementsLength; i++) {
    console.log(elements[i])
}