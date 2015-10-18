<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AutoVerification.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Policy.AutoVerification" %>
<asp:PlaceHolder ID="ScrudPlaceholder" runat="server" />

<script type="text/javascript">

    var effectiveFromTextbox = $("#effective_from_textbox");
    var endsOnTextbox = $("#ends_on_textbox");

    $(document).ready(function () {
        scrudCustomValidator();
    });

    function scrudCustomValidator() {
        var effectiveFrom = parseDate(effectiveFromTextbox.val());
        var endsOn = parseDate(endsOnTextbox.val());

        if (endsOn < effectiveFrom) {
            displayMessage(Resources.Warnings.DateErrorMessage());
            return false;
        };
        return true;
    };

</script>
