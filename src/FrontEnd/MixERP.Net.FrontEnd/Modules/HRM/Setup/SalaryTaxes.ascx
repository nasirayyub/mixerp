<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalaryTaxes.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.SalaryTaxes" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Salary Taxes";

    scrudFactory.viewAPI = "/api/hrm/salary-tax-scrud-view";
    scrudFactory.viewTableName = "hrm.salary_tax_scrud_view";

    scrudFactory.formAPI = "/api/hrm/salary-tax";
    scrudFactory.formTableName = "hrm.salary_taxes";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "SalaryTaxName";

    scrudFactory.card = {
        header: "SalaryTaxCode",
        meta: "SalaryTaxName",
        description: "TaxAuthority"
    };

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
