<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nationalities.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Other.Nationalities" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = window.Resources.Titles.Nationalities();

    scrudFactory.viewAPI = "/api/core/nationality";
    scrudFactory.viewTableName = "core.nationalities";

    scrudFactory.formAPI = "/api/core/nationality";
    scrudFactory.formTableName = "core.nationalities";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "NationalityName";
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
