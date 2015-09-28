<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalaryTaxIncomeBrackets.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Setup.SalaryTaxIncomeBrackets" %>
<script>
	var scrudFactory = new Object();

    scrudFactory.title = "Salary Tax Income Brackets";

    scrudFactory.viewAPI = "/api/hrm/salary-tax-income-bracket-scrud-view";
    scrudFactory.viewTableName = "hrm.salary_tax_income_bracket_scrud_view";

    scrudFactory.formAPI = "/api/hrm/salary-tax-income-bracket";
    scrudFactory.formTableName = "hrm.salary_tax_income_brackets";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

	scrudFactory.card = {
	    header: "SalaryTax",
	    meta: "SalaryFrom",
        description:"SalaryTo"
	};

	scrudFactory.keys = [
        {
            property: "SalaryTaxId",
            url: '/api/hrm/salary-tax/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
