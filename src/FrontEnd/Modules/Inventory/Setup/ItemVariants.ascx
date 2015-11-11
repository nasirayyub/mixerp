<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemVariants.ascx.cs" Inherits="MixERP.Net.Core.Modules.Inventory.Setup.ItemVariants" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.ItemVariants();

    scrudFactory.viewAPI = "/api/core/item-variant-scrud-view";
    scrudFactory.viewTableName = "core.item_variant_scrud_view";

    scrudFactory.formAPI = "/api/core/item-variant";
    scrudFactory.formTableName = "core.item_variants";
    scrudFactory.live = "ItemVariantName";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs", "Photo"];

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.keys = [
        {
            property: "ItemId",
            url: '/api/core/item/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>

<div data-ng-include="'/Modules/ScrudFactory/View.html'"></div>
<div data-ng-include="'/Modules/ScrudFactory/Form.html'"></div>
