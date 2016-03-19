$(function () {
    $('#createForm').submit(function (event) {
        var title, author, isbn, tags, arrayOfTags, data;

        title = $('#title').val();
        author = $('#author').val();
        isbn = $('#isbn').val();
        tags = $('#tags').val();
        arrayOfTags = tags.split(',');
        data = {
            title: title,
            author: author,
            isbn: isbn,
            tags: arrayOfTags
        };

        ajaxForm(event, 'POST', 'book', data, 'The book is created.')
    });
});