<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmploymentTaxes.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.EmploymentTaxes" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Employment Taxes";

    scrudFactory.viewAPI = "/api/hrm/employment-tax-scrud-view";
    scrudFactory.viewTableName = "hrm.employment_tax_scrud_view";

    scrudFactory.formAPI = "/api/hrm/employment-tax";
    scrudFactory.formTableName = "hrm.employment_taxes";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "EmploymentTaxName";

    scrudFactory.keys = [
        {
            property: "TaxAuthorityId",
            url: '/api/core/tax-authority/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
