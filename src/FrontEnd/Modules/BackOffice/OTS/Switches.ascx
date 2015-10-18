<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Switches.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.OTS.Switches" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.Switches();

    scrudFactory.viewAPI = "/api/config/switch-scrud-view";
    scrudFactory.viewTableName = "config.switch_scrud_view";

    scrudFactory.formAPI = "/api/config/switch";
    scrudFactory.formTableName = "config.switches";
    scrudFactory.removeKanban = true;
    scrudFactory.removeFilter = true;
    scrudFactory.removeImport = true;

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.layout = [
        ["Key", ""],
        ["Value", ""]
    ];
</script>
<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
