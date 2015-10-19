<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CUOM.ascx.cs" Inherits="MixERP.Net.Core.Modules.Inventory.Setup.CUOM" %>
<asp:PlaceHolder ID="ScrudPlaceholder" runat="server" />
<script type="text/javascript">
    function scrudCustomValidator() {
        var baseUnitIdDropdownlist = $("#base_unit_id_dropdownlist");
        var compareUnitIdDropdownlist = $("#compare_unit_id_dropdownlist");

        var baseUnit = parseInt2(baseUnitIdDropdownlist.getSelectedValue());
        var compareUnit = parseInt2(compareUnitIdDropdownlist.getSelectedValue());

        if (baseUnit === compareUnit) {
            displayMessage(Resources.Errors.CompoundUnitOfMeasureErrorMessage());
            return false;
        };
        return true;
    };
</script>