<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSelector.aspx.cs" Inherits="MixERP.Net.FrontEnd.General.ItemSelector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scrud Item Selector</title>

    <script src="/Scripts/jquery-1.9.1.js"></script>
    <link href='/Scripts/semantic-ui/semantic.min.css' rel='stylesheet' type='text/css' />

    <style type="text/css">
        html, body, form {
            height: 100%;
            background-color: white !important;
            font-family: "Titillium Web", "Open Sans","Segoe UI", Helvetica,Arial,sans-serif !important;
            font-size:12px;
        }

        form {
            padding: 12px;
        }

        .grid td, .grid th {
            white-space: nowrap;
        }

        .filter {
            width: 172px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <asp:PlaceHolder runat="server" ID="SelectorPlaceholder"></asp:PlaceHolder>
    </form>
</body>
</html>
