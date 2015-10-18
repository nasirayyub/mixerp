<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SMTP.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.OTS.SMTP" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.SMTPConfiguration();

    scrudFactory.viewAPI = "/api/config/smtp";
    scrudFactory.viewTableName = "config.smtp";

    scrudFactory.formAPI = "/api/config/smtp";
    scrudFactory.formTableName = "config.smtp";
    scrudFactory.removeKanban = true;
    scrudFactory.removeFilter = true;
    scrudFactory.removeImport = true;

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;
    scrudFactory.live = "FromEmailAddress";
</script>
<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
