function showView() {
    var target = $("[data-target]:last-child").attr("data-target") || "grid";

    var url = updateQueryString("View", target);
    window.history.pushState({ path: url }, '', url);
    window.scrudForm.hide();
    $("div[data-target]").hide();
    $("[data-target]").removeClass("active");
    $('[data-target="' + target + '"]').show().addClass("active");
    window.scrudView.fadeIn(500);
    loadPageCount(loadGrid);
};