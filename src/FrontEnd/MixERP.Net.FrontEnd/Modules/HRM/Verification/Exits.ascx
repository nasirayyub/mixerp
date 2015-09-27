<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Exits.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Verification.Exits" %>
<script>
    var scrudFactory = new Object();
    
    scrudFactory.title = "Exits";

    scrudFactory.viewAPI = "/api/hrm/exit-scrud-view";
    scrudFactory.viewTableName = "hrm.exit_scrud_view";

    scrudFactory.formAPI = "/api/hrm/exit";
    scrudFactory.formTableName = "hrm.exits";
    scrudFactory.hasVerfication = true;

    scrudFactory.excludedColumns = ["Photo"];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>