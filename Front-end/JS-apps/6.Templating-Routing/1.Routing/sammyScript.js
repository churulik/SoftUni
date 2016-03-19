$('button').click(function () {
    var personsName = $('#person-name').val();
    $('ul').append($('<li><a href="#/' + personsName +'" onclick="greeting(this)">' + personsName +'</a></li>'));
});

function greeting(value) {
    var url, personName, router;

        url = value.hash;
        personName = value.innerHTML;

        router = Sammy(function () {
        this.get(url, function() {
            $('#container').html('<h2>Hello, ' + personName + '!</h2>')
        });
    });

    router.run(url);
}