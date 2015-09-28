<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmploymentTaxDetails.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.EmploymentTaxDetails" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Employment Tax Details";

    scrudFactory.viewAPI = "/api/hrm/employment-tax-detail-scrud-view";
    scrudFactory.viewTableName = "hrm.employment_tax_detail_scrud_view";

    scrudFactory.formAPI = "/api/hrm/employment-tax-detail";
    scrudFactory.formTableName = "hrm.employment_tax_details";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "EmploymentTaxName";

    scrudFactory.card = {
        header: "EmploymentTaxDetailCode",
        meta: "EmploymentTaxDetailName",
        description: "EmploymentTax"
    };

    scrudFactory.keys = [
        {
            property: "EmploymentTaxId",
            url: '/api/hrm/employment-tax/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
