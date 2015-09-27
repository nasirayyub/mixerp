<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contracts.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Verification.Contracts" %>
<script>
    var scrudFactory = new Object();
    
    scrudFactory.title = "Contracts";

    scrudFactory.viewAPI = "/api/hrm/contract-verification-scrud-view";
    scrudFactory.viewTableName = "hrm.contract_verification_scrud_view";

    scrudFactory.formAPI = "/api/hrm/contract";
    scrudFactory.formTableName = "hrm.contracts";
    scrudFactory.hasVerfication = true;

    scrudFactory.excludedColumns = ["Photo"];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>