$('#before').click(function () {
    const before = $('<li>').text('Before');
    $('#now').before(before);
});

$('#after').click(function () {
    const after = $('<li>').text('After');
    $('#now').after(after);
});
