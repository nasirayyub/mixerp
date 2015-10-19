<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Salespersons.ascx.cs"
    Inherits="MixERP.Net.Core.Modules.Sales.Setup.Salespersons" %>


<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.SalesPersons();

    scrudFactory.viewAPI = "/api/core/salesperson-scrud-view";
    scrudFactory.viewTableName = "core.salesperson_scrud_view";

    scrudFactory.formAPI = "/api/core/salesperson";
    scrudFactory.formTableName = "core.salespersons";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.live = "SalesPersonName";
    scrudFactory.queryStringKey = "SalesPersonId";

    scrudFactory.keys = [
        {
            property: "SalesTeamId",
            url: '/api/core/sales-team/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "AccountId",
            url: '/api/core/salesperson-account-selector-view/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
