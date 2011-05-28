var garcom = {};

garcom.allPlaces = (function () {
    var api = {};

    api.initialize = function () {
        $(function () {
            $('#create_place_with_ajax').click(function () {
                var info = {
                    'name': $('#name').val()
                };
                $.post($(this).data('uri'), info, function () {
                    var listOfPlaces = $('#list_of_places');
                    $.get(listOfPlaces.data('uri'), null, function (data) {
                        listOfPlaces.replaceWith(data);
                    });
                });
            });
        });
    };

    return api;
} ());