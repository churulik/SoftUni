(function () {
    var books = [{"book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "34,24", "language": "French"},
        {"book": "The Great Gatsby", "author": "F. Scott Fitzgerald", "price": "39,26", "language": "English"},
        {"book": "Nineteen Eighty-Four", "author": "George Orwell", "price": "15,39", "language": "English"},
        {"book": "Ulysses", "author": "James Joyce", "price": "23,26", "language": "German"},
        {"book": "Lolita", "author": "Vladimir Nabokov", "price": "14,19", "language": "German"},
        {"book": "Catch-22", "author": "Joseph Heller", "price": "47,89", "language": "German"},
        {"book": "The Catcher in the Rye", "author": "J. D. Salinger", "price": "25,16", "language": "English"},
        {"book": "Beloved", "author": "Toni Morrison", "price": "48,61", "language": "French"},
        {"book": "Of Mice and Men", "author": "John Steinbeck", "price": "29,81", "language": "Bulgarian"},
        {"book": "Animal Farm", "author": "George Orwell", "price": "38,42", "language": "English"},
        {"book": "Finnegans Wake", "author": "James Joyce", "price": "29,59", "language": "English"},
        {"book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "42,94", "language": "English"}];

    function firstTask() {
        var sortAndGroupByLanguage, sort, li, orderBy, ul;
        sortAndGroupByLanguage = _(books)
            .sortBy('language')
            .groupBy('language')
            .value();

        _.each(sortAndGroupByLanguage, function (content, language) {
            li = $('<li id="' + language + '">').appendTo($('#firstTask'));
            li.append($('<b>').text(language));
            orderBy = _.orderBy(content, ['author', 'price']);
            _.map(orderBy, function (book) {
                ul = $('<ul>').appendTo($('#' + language));
                ul.append($('<li>').text(book.author + ' - ' + book.book + ' - $' + book.price));
            });
        });
    }

    function secondTask() {
        var groupByAuthor, getAllPricesPerAuthor, priceToNumber, replace, avg, round;

        groupByAuthor = _.groupBy(books, 'author');
        _.each(groupByAuthor, function (content, author) {
            getAllPricesPerAuthor = _.map(groupByAuthor[author], 'price');
            priceToNumber = _.map(getAllPricesPerAuthor, function (str) {
                replace = str.replace(',', '.');
                return parseFloat(replace);
            });

            avg = _.mean(priceToNumber);
            round = _.round(avg, 2);
            $('#secondTask').append($('<li>').text(author + ' - $' + round))
        });
    }

    function thirdTask() {
        var filter, group, li;

        filter = _.filter(books, function (language) {
            return (language.language == 'English' || language.language == 'German')
                && parseFloat(language.price) < 30;
        });

        group = _.groupBy(filter, 'author');
        _.map(group, function (content, author) {
            li = $('#thirdTask').append($('<li>').html('<b>' + author + '</b>'));
            _.each(content, function (book) {
                li.append($('<ul>').append($('<li>').text(book.book + ' - $' + book.price + ' (' + book.language + ')')))
            })
        })
    }

    firstTask();
    secondTask();
    thirdTask();
})();
