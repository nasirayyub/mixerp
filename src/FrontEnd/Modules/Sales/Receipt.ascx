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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Receipt.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.Receipt" %>
<script>
    var scrudFactory = new Object();
    scrudFactory.title = Resources.Titles.SalesReceipt();

    scrudFactory.hiddenAnnotation = ["UserId", "OfficeId"];
    
    scrudFactory.addNewUrl = "/Modules/Sales/Entry/Receipt.mix";

    scrudFactory.defaultAnnotation = [
    	{ 
    		key : "UserId",
    		value: window.userId
    	},
    	{ 
    		key : "OfficeId",
    		value: window.metaView.OfficeId
    	},
    	{ 
    		key : "DateFrom",
    		value: "bom"
    	},
    	{ 
    		key : "DateTo",
    		value: "eom"
    	}
    ];

	scrudFactory.customActions = [
		{
			title: Resources.Labels.GoToChecklistWindow(),
			href: "/Modules/Sales/Confirmation/Receipt.mix?TranId={id}",
			icon : "list icon"
		},
		{
			title: Resources.Titles.Print(),
			onclick: "showWindow('/Modules/Sales/Reports/CustomerReceiptReport.mix?TranId={id}');",
			icon : "print icon"
		}
	];


	scrudFactory.viewAPI = "/api/transactions/procedures/get-receipt-view";
	scrudFactory.viewTableName = "transactions.get_receipt_view";
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>