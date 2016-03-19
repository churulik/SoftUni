function traverse(selector) {
    var query = document.querySelector(selector);

    traverseSelector(query, '');

    function traverseSelector(qyery, spacing) {
        var queryLength = qyery.childNodes.length;

        for (var i = 0; i < queryLength; i++) {
            var child = qyery.childNodes[i];

            if (child.nodeType === 1) {

                var output = spacing + child.localName + ': ';

                if(child.id !== '') {
                    output += 'id="' + child.id + '" ';
                }

                if(child.className !== ''){
                    output += 'class="' + child.className + '"';
                }

                console.log(output);

                traverseSelector(child, spacing + '    ');
            }
        }
    }
}

var selector = '.birds';
traverse(selector);
