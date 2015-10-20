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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartyTypes.ascx.cs" Inherits="MixERP.Net.Core.Modules.Inventory.Setup.PartyTypes" %>

<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.PartyTypes();

    scrudFactory.viewAPI = "/api/core/party-type-scrud-view";
    scrudFactory.viewTableName = "core.party_types_scrud_view";

    scrudFactory.formAPI = "/api/core/party-type";
    scrudFactory.formTableName = "core.party_types";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;

    scrudFactory.queryStringKey = "PartyTypeId";

    scrudFactory.keys = [
        {
            property: "AccountId",
            url: '/api/core/party-type-account-selector-view/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
