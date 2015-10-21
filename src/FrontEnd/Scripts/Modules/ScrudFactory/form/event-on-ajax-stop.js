$(document).ajaxStop(function () {
    $("#scrud").show();
    $("#scrud").parent().removeClass("loading");
    loadDefaultValues();
    loadDropdowns();
    setRegionalFormat();
    loadDatepicker();
    triggerFormReadyEvent();
});