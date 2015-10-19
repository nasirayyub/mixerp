<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BonusSlabDetails.ascx.cs"
    Inherits="MixERP.Net.Core.Modules.Sales.Setup.BonusSlabDetails" %>

<style>
    .disableClick {
        pointer-events: none;
    }
</style>

<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.BonusSlabDetails();

    scrudFactory.viewAPI = "/api/core/bonus-slab-detail-scrud-view";
    scrudFactory.viewTableName = "core.bonus_slab_details_scrud_view";

    scrudFactory.formAPI = "/api/core/bonus-slab-detail";
    scrudFactory.formTableName = "core.bonus_slab_details";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.queryStringKey = "BonusSlabDetailsId";

    scrudFactory.keys = [
        {
            property: "BonusSlabId",
            url: '/api/core/bonus-slab/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        }
    ];


</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>

<script type="text/javascript">

    $(document).on("formready", function () {
        var amountFromTextBox = $("#amount_from");
        var amountToTextBox = $("#amount_to");
        var saveButton = $("#SaveButton");

        amountToTextBox.blur(function () {
            customValidate(amountFromTextBox, amountToTextBox, saveButton);
        });
    });

    function customValidate(amountFromTextBox, amountToTextBox, saveButton) {
        var from = parseFloat2(amountFromTextBox.val());
        var to = parseFloat2(amountToTextBox.val());

        if (to <= from) {
            saveButton.addClass("disableClick");
            displayMessage(Resources.Warnings.CompareAmountErrorMessage());
            makeDirty(amountToTextBox);
            return false;
        };
        saveButton.removeClass("disableClick");
        removeDirty(amountToTextBox);
        return true;
    };

</script>

