$(function () {
    function listAllBooks(data) {
        $('#beautify').show().text(JSON.stringify(data, null, 2));

        $('#rawBtn').click(function () {
            $('#beautify').hide();
            $('#raw').show().text(JSON.stringify(data));
        });

        $('#beautifyBtn').click(function () {
            $('#raw').hide();
            $('#beautify').show().text(JSON.stringify(data, null, 2));
        });
    }

    getBooks(function (data) {
        listAllBooks(data)
    });
});
