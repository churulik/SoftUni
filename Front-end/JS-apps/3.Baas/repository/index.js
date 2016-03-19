$(function () {
    $('#countryButton').click(function () {
        $('#countryButton').fadeIn('slow', function () {
            $('#countryButton').hide(function () {
                $('#countryButton').fadeOut('slow');
            });
        });
        $('#townButton').fadeIn('slow', function () {
            $('#townButton').hide(function () {
                $('#townButton').fadeOut('slow');
            });
        });

        $('#back').fadeOut('slow', function () {
            $('#back').show(function () {
                $('#back').fadeIn('slow');
            });
        });

        $('#contentCountry').fadeOut('slow', function () {
            $('#contentCountry').show(function () {
                $('#contentCountry').fadeIn('slow');
            });
        });
    });

    $('#townButton').click(function () {
        $('#countryButton').fadeIn('slow', function () {
            $('#countryButton').hide(function () {
                $('#countryButton').fadeOut('slow');
            });
        });
        $('#townButton').fadeIn('slow', function () {
            $('#townButton').hide(function () {
                $('#townButton').fadeOut('slow');
            });
        });

        $('#back').fadeOut('slow', function () {
            $('#back').show(function () {
                $('#back').fadeIn('slow');
            });
        });

        $('#contentTown').fadeOut('slow', function () {
            $('#contentTown').show(function () {
                $('#contentTown').fadeIn('slow');
            });
        });
    });

    $('#backCountry').click(function () {
        $('#contentCountry').fadeIn('slow', function () {
            $('#contentCountry').hide(function () {
                $('#contentCountry').fadeOut('slow');
            });
        });

        $('#countryButton').fadeOut('slow', function () {
            $('#countryButton').show(function () {
                $('#countryButton').fadeIn('slow');
            });
        });

        $('#townButton').fadeOut('slow', function () {
            $('#townButton').show(function () {
                $('#townButton').fadeIn('slow');
            });
        });
    });

    $('#backTown').click(function () {
        $('#contentTown').fadeIn('slow', function () {
            $('#contentTown').hide(function () {
                $('#contentTown').fadeOut('slow');
            });
        });

        $('#countryButton').fadeOut('slow', function () {
            $('#countryButton').show(function () {
                $('#countryButton').fadeIn('slow');
            });
        });

        $('#townButton').fadeOut('slow', function () {
            $('#townButton').show(function () {
                $('#townButton').fadeIn('slow');
            });
        });
    });

});