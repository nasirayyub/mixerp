<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecurringInvoiceSetup.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Setup.RecurringInvoiceSetup" %>
<style>
    .disableClick {
        pointer-events: none;
    }
</style>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.RecurringInvoiceSetup();

    scrudFactory.viewAPI = "/api/core/recurring-invoice-setup-scrud-view";
    scrudFactory.viewTableName = "core.recurring_invoice_setup_scrud_view";

    scrudFactory.formAPI = "/api/core/recurring-invoice-setup";
    scrudFactory.formTableName = "core.recurring_invoice_setup";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.queryStringKey = "RecurringInvoiceSetupId";

    scrudFactory.keys = [
        {
            property: "RecurringInvoiceId",
            url: '/api/core/recurring-invoice/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "PartyId",
            url: '/api/core/party/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "RecurrenceTypeId",
            url: '/api/core/recurrence-type/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "RecurringFrequencyId",
            url: '/api/core/frequency/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "AccountId",
            url: '/api/core/recurring-invoice-account-selector-view/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "PaymentTermId",
            url: '/api/core/payment-term/display-fields',
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
        var startFromTextbox = $("#starts_from");
        var endsOnTextbox = $("#ends_on");
        var saveButton = $("#SaveButton");

        endsOnTextbox.blur(function () {
            customValidate(startFromTextbox, endsOnTextbox, saveButton);
        });
    });

    function customValidate(startFromTextbox, endsOnTextbox, saveButton) {
        var startDate = parseDate(startFromTextbox.val());
        var endDate = parseDate(endsOnTextbox.val());

        if (endDate <= startDate) {
            saveButton.addClass("disableClick");
            makeDirty(endsOnTextbox);
            displayMessage(Resources.Warnings.InvalidDate());
            return false;
        }
        saveButton.removeClass("disableClick");
        return true;
    };

</script>
