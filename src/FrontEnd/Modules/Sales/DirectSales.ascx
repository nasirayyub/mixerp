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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DirectSales.ascx.cs" Inherits="MixERP.Net.Core.Modules.Sales.DirectSales" %>
<asp:PlaceHolder runat="server" ID="Placeholder1"></asp:PlaceHolder>


<script>
    var scrudFactory = new Object();
    scrudFactory.title = Resources.Titles.DirectSales();

    scrudFactory.hiddenAnnotation = ["UserId", "Book", "OfficeId"];
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
    		key : "Book",
    		value: "Sales.Direct"
    	},
    	{ 
    		key : "DateFrom",
    		value: "-1y"
    	},
    	{ 
    		key : "DateTo",
    		value: "1y"
    	}
    ];

	scrudFactory.card = {
		header: "Party",
		meta: "StatementReference",
		description:"Office"
	}; 

	scrudFactory.customActions = [
		{
			title: "Go to checklist window.",
			href : "/Modules/Sales/Confirmation/DirectSales.mix?TranId={id}",
			icon : "list icon"
		},
		{
			title: "Print",
			onclick : "showWindow('/Modules/Sales/Reports/DirectSalesInvoiceReport.mix?TranId={id}');",
			icon : "print icon"
		}
	];


    scrudFactory.viewAPI = "/api/transactions/procedures/get-product-view";
    scrudFactory.viewTableName = "transactions.get_product_view";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];
    
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>