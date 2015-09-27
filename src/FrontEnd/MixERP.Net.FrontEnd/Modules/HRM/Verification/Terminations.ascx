<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Terminations.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Verification.Terminations" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = "Terminations";

    scrudFactory.viewAPI = "/api/hrm/termination-verification-scrud-view";
    scrudFactory.viewTableName = "hrm.termination_verification_scrud_view";

    scrudFactory.formAPI = "/api/hrm/termination";
    scrudFactory.formTableName = "hrm.terminations";

    scrudFactory.hasVerfication = true;

    scrudFactory.excludedColumns = ["Photo"];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
