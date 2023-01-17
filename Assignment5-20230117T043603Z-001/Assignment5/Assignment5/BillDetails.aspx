<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDetails.aspx.cs" Inherits="Assignment5.BillDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            border-style: solid;
            border-width: 2px;
        }
        .auto-style3 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style2">
            <tr>
                <td>
                    <asp:Label ID="lblProdID" runat="server" Text="Product ID"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResProdID" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drdProdName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdProdName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblCustID" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResCustID" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drdCustomerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdCustomerName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblResProdName" runat="server"></asp:Label>
                </td>
                <td class="auto-style3"></td>
                <td class="auto-style3">
                    <asp:Label ID="LblCustName" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblResCustName" runat="server"></asp:Label>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProdPrice" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResAddress" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResQty" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblMobNo" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResMobile" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReqQty" runat="server" Text="Required Qty"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtReqQty" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBillNo" runat="server" Text="Bill No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDetails" runat="server" OnClick="btnDetails_Click" Text="Click to Fill Details" />
                </td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm Order" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
                <td colspan="2">
                    <asp:Label ID="lblTotalBill" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
