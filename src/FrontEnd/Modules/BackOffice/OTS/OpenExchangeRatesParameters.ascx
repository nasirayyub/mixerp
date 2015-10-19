<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenExchangeRatesParameters.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.OTS.OpenExchangeRatesParameters" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.OpenExchangeRatesParameters();

    scrudFactory.viewAPI = "/api/config/open-exchange-rate-scrud-view";
    scrudFactory.viewTableName = "config.open_exchange_rate_scrud_view";

    scrudFactory.formAPI = "/api/config/open-exchange-rate";
    scrudFactory.formTableName = "config.open_exchange_rates";
    scrudFactory.removeKanban = true;
    scrudFactory.removeFilter = true;
    scrudFactory.removeImport = true;

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.layout = [
        ["Key", ""],
        ["Value", ""],
        ["Description", ""]
    ];
</script>
<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
