<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BonusSlabAssignment.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Setup.BonusSlabAssignment" %>

<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.AgentBonusSlabAssignment();

    scrudFactory.viewAPI = "/api/core/salesperson-bonus-setup";
    scrudFactory.viewTableName = "core.salesperson_bonus_setup_scrud_view";

    scrudFactory.formAPI = "/api/core/salesperson-bonus-setup";
    scrudFactory.formTableName = "core.salesperson_bonus_setups";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.queryStringKey = "SalesPersonBonusSetupId";

    scrudFactory.keys = [
        {
            property: "SalespersonId",
            url: '/api/core/salesperson/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
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