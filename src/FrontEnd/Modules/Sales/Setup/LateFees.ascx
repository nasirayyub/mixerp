<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LateFees.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Setup.LateFees" %>

<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.LateFees();

    scrudFactory.viewAPI = "/api/core/late-fee-scrud-view";
    scrudFactory.viewTableName = "core.late_fee_scrud_view";

    scrudFactory.formAPI = "/api/core/late-fee";
    scrudFactory.formTableName = "core.late_fee";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.live = "LateFeeName";
    scrudFactory.keys = [
        {
            property: "AccountId",
            url: '/api/core/late-fee-account-selector-view/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>