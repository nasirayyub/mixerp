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

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JournalVoucher.ascx.cs" Inherits="MixERP.Net.Core.Modules.Finance.JournalVoucher" %>
<script>
    var scrudFactory = new Object();
    scrudFactory.title = Resources.Titles.JournalVoucher();

    scrudFactory.hiddenAnnotation = ["UserId", "OfficeId"];
    
    scrudFactory.addNewUrl = "Entry/JournalVoucher.mix";

    scrudFactory.defaultAnnotation = [
    	{ 
    		key : "UserId",
    		value: window.userId
    	},
    	{
    	    key: "OfficeId",
    	    value: window.metaView.OfficeId
    	},
    	{
    	    key: "Book",
    	    value: "Journal"
    	},
    	{
    	    key: "Status",
    	    value: "Approved"
    	},
    	{
    	    key: "OfficeName",
    	    value: window.metaView.OfficeName
    	},
    	{
    		key : "From",
    		value: "bom"
    	},
    	{ 
    		key : "To",
    		value: "eom"
    	}
    ];

	scrudFactory.customActions = [
		{

			title: Resources.Labels.GoToChecklistWindow(),
			href: "/Modules/Finance/Confirmation/JournalVoucher.mix?TranId={id}",
			icon : "list icon"
		},
		{
			title: Resources.Titles.Print(),
			onclick: "showWindow('/Modules/Finance/Reports/GLAdviceReport.mix?TranId={id}');",
			icon : "print icon"
		}
	];


    scrudFactory.viewAPI = "/api/transactions/procedures/get-journal-view";
    scrudFactory.viewTableName = "transactions.get_journal_view";
</script>
<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>