function verify(primaryKey, verificationStatusId, reason) {
    var url = scrudFactory.formAPI;
    url += "/verify/";
    url += primaryKey + "/";
    url += verificationStatusId + "/";
    url += reason;

    return getAjaxRequest(url, "PUT");
};

$("#ApproveButton").click(function () {
    var primaryKey = getPrimaryKeyValue();

    if (!hasVerfication() || !primaryKey) {
        return;
    };

    var reason = reasonTextArea.val();
    var verificationStatusId = 2; //2 -> Approved, -3 -> Rejected

    var verifyAjax = verify(primaryKey, verificationStatusId, reason);

    verifyAjax.success(function () {
        docready();
        displayMessage(Resources.Labels.TaskCompletedSuccessfully(), "success");
    });
});

$("#RejectButton").click(function () {
    var primaryKey = getPrimaryKeyValue();

    if (!hasVerfication() || !primaryKey) {
        return;
    };

    var reason = reasonTextArea.val();
    var verificationStatusId = -3; //2 -> Approved, -3 -> Rejected

    var verifyAjax = verify(primaryKey, verificationStatusId, reason);

    verifyAjax.success(function () {
        docready();
        displayMessage(Resources.Labels.TaskCompletedSuccessfully(), "success");
    });
});
