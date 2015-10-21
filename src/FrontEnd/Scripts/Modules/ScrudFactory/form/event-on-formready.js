function triggerFormReadyEvent() {
    if (!window.formReady) {
        window.formReady = true;
        $(document).trigger("formready");
        showForm();
    };
};