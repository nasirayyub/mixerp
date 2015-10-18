<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Teams.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Setup.Teams" %>


<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.SalesTeams();

    scrudFactory.viewAPI = "/api/core/sales-team-scrud-view";
    scrudFactory.viewTableName = "core.sales_team_scrud_view";

    scrudFactory.formAPI = "/api/core/sales-team";
    scrudFactory.formTableName = "core.sales_teams";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.live = "SalesTeamName";
       
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>