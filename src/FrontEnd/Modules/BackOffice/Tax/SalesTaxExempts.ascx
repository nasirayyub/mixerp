<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesTaxExempts.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Tax.SalesTaxExempts" %>

<asp:PlaceHolder runat="server" ID="ScrudPlaceholder" />
<script type="text/javascript">
    function scrudCustomValidator() {
        var validFromTextbox = $("#valid_from_textbox");
        var validTillTextbox = $("#valid_till_textbox");
        var priceFromTextbox = $("#price_from_textbox");
        var priceToTextbox = $("#price_to_textbox");

        var validFrom = parseDate(validFromTextbox.val());
        var validTill = parseDate(validTillTextbox.val());
        var priceFrom = parseFloat2(priceFromTextbox.val());
        var priceTo = parseFloat2(priceToTextbox.val());

        if (validTill < validFrom) {
            displayMessage(Resources.Warnings.DateErrorMessage());
            return false;
        };
        if (priceTo <= priceFrom) {
            displayMessage(Resources.Warnings.ComparePriceErrorMessage());
            return false;
        };

        return true;
    };

</script>