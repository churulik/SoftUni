$(function () {
    var json = {
        "person": []
    };

    $('button').click(function () {
        var name, job, website;

        name = $('#name').val();
        job = $('#job').val();
        website = $("#website").val();

        json.person.push({name: name, job: job, website: website});

        $.get('template.html', function (template) {

            var outputHtml = Mustache.render(template, json);
            $('#container').html(outputHtml);
            $("tbody:odd").css("background-color", "#e6ffe6");
        });
    });
});

