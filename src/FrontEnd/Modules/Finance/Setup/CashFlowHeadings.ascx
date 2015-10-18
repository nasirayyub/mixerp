<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CashFlowHeadings.ascx.cs" Inherits="MixERP.Net.Core.Modules.Finance.Setup.CashFlowHeadings" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.CashFlowHeadings();

    scrudFactory.viewAPI = "/api/core/cash-flow-heading-scrud-view";
    scrudFactory.viewTableName = "core.cash_flow_heading_scrud_view";

    scrudFactory.formAPI = "/api/core/cash-flow-heading";
    scrudFactory.formTableName = "core.cash_flow_headings";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "CashFlowHeadingName";
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>