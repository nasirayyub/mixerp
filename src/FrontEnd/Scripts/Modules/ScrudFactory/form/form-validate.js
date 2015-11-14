function appendError(message) {
    var item = $("<li/>");
    item.html(message);
    console.log(message);
    
    if(scrudFactory.tabs.length > 1){
        $("#ScrudFormErrorModal .error-list").append(item);
    };
};

function resetError() {
    $("#ScrudFormErrorModal .error-list").html("");
};


function validate() {
    resetError();
    var required = $(".form.factory .image.form-field, .form.factory [required]:not(:disabled):not([readonly]):not(.hidden.column)");
    required.trigger("blur");
    $(".ui-timepicker-input").timepicker("hide");
    
    var errorFields = window.scrudForm.find(".error:not(.big.error)");

    $.each(errorFields, function (i, v) {
        var label = $(v).closest(".field").find("label");
        var message = label.html() + " : " + window.Resources.Labels.ThisFieldIsRequired();
        appendError(message);
    });

    var errorCount = errorFields.length;

    if (!errorCount) {
        if (typeof (window.customFormValidator) === "function") {
            var isValid = window.customFormValidator();

            return isValid;
        };

        return true;
    };

    if(scrudFactory.tabs.length > 1){
        $("#ScrudFormErrorModal").modal({ blurring: true }).modal("show");
    };

    return false;
};

function initializeValidators() {
    $(".dropdown input.search").blur(function () {
        $(this).parent().find("select").trigger("blur");
    });

    function validateField(el) {
        var val = el.val();
        var errorMessage = el.closest(".field").find(".error-message");

        if (!errorMessage.length) {
            errorMessage = $("<span class='error-message' />");
            el.closest(".field").append(errorMessage);
        };

        if (isNullOrWhiteSpace(val)) {
            isValid = false;
            makeDirty(el);

            el.closest(".field").find(".error-message").html(Resources.Labels.ThisFieldIsRequired());
        } else {
            removeDirty(el);
            el.closest(".field").find(".error-message").html("");
        };
    }

    $(".form.factory [required]:not(:disabled):not([readonly])").blur(function () {
        var el = $(this);
        validateField(el);
    });
};