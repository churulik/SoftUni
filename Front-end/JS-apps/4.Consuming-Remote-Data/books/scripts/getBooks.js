function getBooks(bookFunction) {
    if (booksSessionStorage().getData() == undefined) {
        $.ajax({
            method: 'GET',
            headers: headers(),
            url: getBookUrl()
        }).success(function (data) {
            booksSessionStorage().setData(data);
            bookFunction(data);
        }).error(function (error) {
            console.error(error.responseText);
        })
    } else {
        var data = booksSessionStorage().getData();
        bookFunction(data)
    }
}