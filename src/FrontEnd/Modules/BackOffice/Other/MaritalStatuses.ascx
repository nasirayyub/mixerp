<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MaritalStatuses.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Other.MaritalStatuses" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = window.Resources.Titles.MaritalStatuses();

    scrudFactory.viewAPI = "/api/core/marital-status";
    scrudFactory.viewTableName = "core.marital_statuses";

    scrudFactory.formAPI = "/api/core/marital-status";
    scrudFactory.formTableName = "core.marital_statuses";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "MaritalStatusName";
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
