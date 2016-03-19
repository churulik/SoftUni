$(function () {
    if (booksSessionStorage().getData() == undefined) {
        updateBookSessionStorage();
    }
});