<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaxMaster.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Tax.TaxMaster" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.TaxMaster();

    scrudFactory.viewAPI = "/api/core/tax-master-scrud-view";
    scrudFactory.viewTableName = "core.tax_master_scrud_view";

    scrudFactory.formAPI = "/api/core/tax-master";
    scrudFactory.formTableName = "core.tax_master";
    scrudFactory.live = "TaxMasterName";

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
