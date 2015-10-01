<%--
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses />.
--%>
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
