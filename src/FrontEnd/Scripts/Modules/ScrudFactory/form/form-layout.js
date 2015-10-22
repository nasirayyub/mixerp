function createLayout(collection) {
    var skip = [];

    if (typeof (scrudFactory.layout) !== "undefined") {
        $.each(scrudFactory.layout, function (i, currentLayout) {
            var actualColumns = _.uniq(currentLayout);
            var fieldWith = 16 / currentLayout.length;

            var fields = $("<div class='fields' />");

            $.each(actualColumns, function (index, propertyName) {
                var value = _.findIndex(collection, { "PropertyName": propertyName });

                if (value >= 0) {
                    skip.push(value);

                    var weight = currentLayout.reduce(function (x, y) {
                        return x + (y === propertyName);
                    }, 0);

                    var cssClass = semanticGrid[fieldWith * weight] + " wide field";

                    createFieldGroup(fields, collection[value], cssClass);
                };

            });

            if (fields.children().length > 0) {
                scrud.append(fields);
            };
        });
    };


    var range = _.range(collection.length);
    var missing = $(range).not(skip).get();

    missing = window.chunk_array(missing, 2);

    $.each(missing, function () {
        fields = $("<div class='fields' />");
        createFieldGroup(fields, collection[this[0]], "four wide field");

        if (this[1] !== undefined) {
            createFieldGroup(fields, collection[this[1]], "four wide field");
        };

        if (fields.children().length > 0) {
            scrud.append(fields);
        };
    });



    initializeAjaxRequest();
    initializeUploader();
    initializeValidators();

    var initialValue = $(".initial.value").html();

    $("input.live").keyup(function () {
        var val = $(this).val();

        if (!val.length) {
            $(".initial.value").html(initialValue);
            $(".huge.header .sub.header").html("");
            $(".live:not(input)").html("");
        } else {
            $(".initial.value").html("");
            $(".huge.header .sub.header").html(initialValue);

            $(".live:not(input)").html(val);
        };
    });

    $("input.live").trigger("keyup");
};