<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="Assignment5.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 2px;
            background-color: #C0C0C0;
        }
        .auto-style4 {
            width: 201px;
        }
        .auto-style5 {
            width: 294px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblWelcome" runat="server" BorderStyle="Dashed" Text="Welcome To Sai Kirana" Height="500px" Width="1000px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblOwner" runat="server" BorderStyle="None" ForeColor="Red" Text="ONLY FOR OWNERS ONLY............"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="lblLoginID" runat="server" Text="LoginID"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:LinkButton ID="LinkCustomer" runat="server" OnClick="LinkCustomer_Click">Customer Login</asp:LinkButton>
                </td>
                <td colspan="2">
                    <asp:LinkButton ID="LinkProduct" runat="server" OnClick="LinkProduct_Click">Product Login</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="LinkBilling" runat="server" OnClick="LinkBilling_Click">Billing Login</asp:LinkButton>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
