<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Wages.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.Wages" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = "Wage Setups";
    
    scrudFactory.viewAPI = "/api/hrm/wage-setup";
    scrudFactory.viewTableName = "hrm.wage_setup";

    scrudFactory.formAPI = "/api/hrm/wage-setup";
    scrudFactory.formTableName = "hrm.wage_setup";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "WageSetupName";

    scrudFactory.layout = [
        ["WageSetupId", ""],
        ["WageSetupCode", "WageSetupName", "", ""],
        ["CurrencyCode", "AccountId", "", ""],
        ["MaxWeekHours", "HourlyRate", "", ""],
        ["OvertimeApplicable", "OvertimeHourlyRate", "", ""],
        ["Description", ""]
    ];

    scrudFactory.keys = [
        {
            property: "CurrencyCode",
            url: '/api/core/currency/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "AccountId",
            url: '/api/hrm/wage-account-selector-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>

<script>
    $(document).on("formready", function() {
        $("#overtime_applicable").change(function () {
            var applicable = $(this).val() === "yes";
            var targetEl = $("#overtime_hourly_rate");

            targetEl.prop("disabled", !applicable);

            if (!applicable) {
                targetEl.val("0");
            };
        });

        $("#overtime_applicable").trigger("change");
    });
</script>