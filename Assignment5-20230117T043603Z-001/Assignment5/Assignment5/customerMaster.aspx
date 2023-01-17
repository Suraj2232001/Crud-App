<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerMaster.aspx.cs" Inherits="Assignment5.billingSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 2px;
            background-color: #CCFFFF;
        }
        .auto-style2 {
            width: 209px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblCustID" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="drdCustID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdCustID_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblCustName" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblCustAddress" runat="server" Text="Customer Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblCustMobile" runat="server" Text="Customer Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Height="35px" OnClick="btnAdd_Click" Text="Add" Width="95px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Height="35px" OnClick="btnSave_Click" Text="Save" Width="95px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Height="35px" OnClick="btnDelete_Click" Text="Delete" Width="95px" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnEdit" runat="server" Height="35px" OnClick="btnEdit_Click" Text="Edit" Width="95px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Height="35px" Width="95px" />
&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
