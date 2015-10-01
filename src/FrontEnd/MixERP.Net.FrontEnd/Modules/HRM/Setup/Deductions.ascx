<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Deductions.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.Deductions" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Deduction Setups";

    scrudFactory.viewAPI = "/api/hrm/deduction-setup-scrud-view";
    scrudFactory.viewTableName = "hrm.deduction_setup_scrud_view";

    scrudFactory.formAPI = "/api/hrm/deduction-setup";
    scrudFactory.formTableName = "hrm.deduction_setups";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "DeductionSetupName";

    scrudFactory.card = {
        header: "DeductionSetupCode",
        meta: "DeductionSetupName",
        description: "Account"
    };

    scrudFactory.keys = [
        {
            property: "AccountId",
            url: '/api/hrm/deduction-account-selector-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];

</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
