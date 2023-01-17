<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productMaster.aspx.cs" Inherits="Assignment5.productMaster" %>

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
        .auto-style3 {
            width: 209px;
            height: 33px;
        }
        .auto-style4 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblProdID" runat="server" Text=" Product ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="drdProdID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdCustID_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdQty" runat="server"></asp:TextBox>
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
