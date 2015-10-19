<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentTerms.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Setup.PaymentTerms" %>
<style>
    .disableClick {
        pointer-events: none;
    }
</style>

<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.PaymentTerms();

    scrudFactory.viewAPI = "/api/core/payment-term-scrud-view";
    scrudFactory.viewTableName = "core.payment_term_scrud_view";

    scrudFactory.formAPI = "/api/core/payment-term";
    scrudFactory.formTableName = "core.payment_terms";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.live = "PaymentTermName";
    scrudFactory.queryStringKey = "PaymentTermId";

    scrudFactory.keys = [
        {
            property: "DueFrequencyId",
            url: '/api/core/frequency/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        //{
        //    property: "LateFeeId",
        //    url: '/api/core/late-fee/display-fields',
        //    data: null,
        //    isArray: false,
        //    valueField: "Key",
        //    textField: "Value"
        //},
         {
             property: "LateFeePostingFrequencyId",
             url: '/api/core/frequency/display-fields',
             data: null,
             isArray: false,
             valueField: "Key",
             textField: "Value"
         },
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
