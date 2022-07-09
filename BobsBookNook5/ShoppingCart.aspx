<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btnBacktoBrowsing" runat="server" OnClick="btnBacktoBrowsing_Click" Text="Back to Browsing" />
        <br />
        <asp:Button ID="btnCheckout" runat="server" OnClick="btnCheckout_Click" Text="Checkout" Width="150px" />
        <br />
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <asp:GridView ID="gvShoppingCart" runat="server" DataKeyNames="ISBN" Visible="False" OnSelectedIndexChanged="gvShoppingCart_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="False" DataKeyNames="ISBN" OnSelectedIndexChanged="gvDisplay_SelectedIndexChanged">
         <Columns>
         <asp:TemplateField>
            <ItemTemplate>
            <asp:Image ID="Image1" runat ="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
            </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField DataField="Title" HeaderText="Title" />
         <asp:BoundField DataField="Author" HeaderText="Author" />
         <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
         <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowSelectButton="True" SelectText="Place Back on Shelf" />
         </Columns>
        </asp:GridView>

    </form>
</body>
</html>
