<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProvidentFunds.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.ProvidentFunds" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Provident Funds";

    scrudFactory.viewAPI = "/api/hrm/provident-fund-scrud-view";
    scrudFactory.viewTableName = "hrm.provident_fund_scrud_view";

    scrudFactory.formAPI = "/api/hrm/provident-fund";
    scrudFactory.formTableName = "hrm.provident_funds";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "ProvidentFundName";

    scrudFactory.keys = [
        {
            property: "FundHoldingAccountId",
            url: '/api/hrm/provident-fund-holding-account-selector-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "ProvidentFundExpenseAccountId",
            url: '/api/hrm/provident-fund-expense-account-selector-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
