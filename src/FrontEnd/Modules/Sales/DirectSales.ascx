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
<script>
    var scrudFactory = new Object();
    scrudFactory.title = Resources.Titles.DirectSales();

    scrudFactory.hiddenAnnotation = ["UserId", "Book", "OfficeId"];
    
    scrudFactory.addNewUrl = "/Modules/Sales/Entry/DirectSales.mix";

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
			href : "/Modules/Sales/Confirmation/DirectSales.mix?TranId={id}",
			icon : "list icon"
		},
		{
			title: Resources.Titles.Print(),
			onclick : "showWindow('/Modules/Sales/Reports/DirectSalesInvoiceReport.mix?TranId={id}');",
			icon : "print icon"
		}
	];

    scrudFactory.customButtons = [
        {
            id: "ReturnButton",
            text: Resources.Titles.Return(),
            href : "",
            onclick : "onReturn();"
        }
    ];


    scrudFactory.viewAPI = "/api/transactions/procedures/get-product-view";
    scrudFactory.viewTableName = "transactions.get_product_view";    
</script>

<script>
    function onReturn(){
        var id = getSelectedCheckBoxItemIds(2, 3, $("#ScrudView"))[0];
        if(!id){
            displayMessage(Resources.Titles.NothingSelected());
            return;
        };

        var url = "/Modules/Sales/Entry/Return.mix?TranId=" + id;
        window.location = url;
    };
</script>

<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>