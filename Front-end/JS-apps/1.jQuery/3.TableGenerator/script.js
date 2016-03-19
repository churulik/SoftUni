String.prototype.capitalizeFirstLetter = function() {
    return this.charAt(0).toUpperCase() + this.slice(1);
};

$(document).ready(function () {
    const json = '[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
        '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
        '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]';

    const table = $('<table>').appendTo('#cars');
    const thead = $('<thead>').appendTo(table);
    const trHead = $('<tr>').appendTo(thead);
    const tbody = $('<tbody>').appendTo(table);

    $.each($.parseJSON(json), function (index, obj) {
        const trBody = $('<tr>').appendTo(tbody);
        $.each(obj, function (key, value) {
            if (index == 0) {
                var heading = key.capitalizeFirstLetter();
                $('<th>').text(heading).appendTo(trHead);
            }
            $('<td>').text(value).appendTo(trBody);
        })
    });
});
