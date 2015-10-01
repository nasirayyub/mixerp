<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Deduction.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Payroll.Deduction" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = "Salary Deductions";

    scrudFactory.viewAPI = "/api/hrm/salary-deduction-scrud-view";
    scrudFactory.viewTableName = "hrm.salary_deduction_scrud_view";

    scrudFactory.formAPI = "/api/hrm/salary-deduction";
    scrudFactory.formTableName = "hrm.salary_deductions";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs", "Photo"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.card = {
        header: "Employee",
        meta: "DeductionSetup",
        description: "Amount"
    };

    scrudFactory.keys = [
        {
            property: "EmployeeId",
            url: '/api/hrm/employee-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "DeductionSetupId",
            url: '/api/hrm/deduction-setup/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "PayGradeId",
            url: '/api/hrm/pay-grade/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "SalaryFrequencyId",
            url: '/api/hrm/salary-frequency/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "CurrencyCode",
            url: '/api/core/currency/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "ProvidentFundId",
            url: '/api/hrm/provident-fund/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "EmploymentTaxId",
            url: '/api/hrm/employment-tax/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
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
