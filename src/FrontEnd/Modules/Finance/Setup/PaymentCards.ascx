<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentCards.ascx.cs" Inherits="MixERP.Net.Core.Modules.Finance.Setup.PaymentCards" %>
<script src="/Scripts/underscore/underscore-min.js"></script>
<script>
    var scrudFactory = new Object();
    scrudFactory.title = window.Resources.Titles.PaymentCards();

    scrudFactory.viewAPI = "/api/core/payment-card-scrud-view";
    scrudFactory.viewTableName = "core.payment_card_scrud_view";

    scrudFactory.formAPI = "/api/core/payment-card";
    scrudFactory.formTableName = "core.payment_cards";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.live = "PaymentCardName";
    scrudFactory.queryStringKey = "AccountId";

    scrudFactory.card = {
        header: "PaymentCardCode",
        meta: "PaymentCardName",
        description:"CardType"
    };

    scrudFactory.layout = [
        ["PaymentCardId", ""],
        ["PaymentCardCode", "PaymentCardName", "", ""],
        ["CardTypeId", ""]
    ];

    scrudFactory.keys = [
        {
            property: "CardTypeId",
            url: '/api/core/card-type/display-fields',
            data: null,
            isArray:false,
            valueField: "Key",
            textField: "Value"
        }
    ];


</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>