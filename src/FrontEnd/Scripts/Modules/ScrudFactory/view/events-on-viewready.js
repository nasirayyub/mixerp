function popUnder(div, button) {
    $(".popunder").hide();
    div.removeClass("initially hidden");
    div.fadeIn(500).position({
        my: "left top",
        at: "left bottom",
        of: button
    });
};

$(document).on("viewready", function () {
    flagButton.click(function () {
        popUnder(flagPopUnder, flagButton);
    });

    filterButton.click(function () {
        popUnder(filterPopUnder, filterButton);
    });
});

function triggerViewReadyEvent() {
    if (!window.viewReady) {
        window.viewReady = true;
        $(document).trigger("viewready");
    };
};