<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblMessage" runat="server" Text="Please enter the email address for delivery of your books."></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return to Bookstore" />
        <asp:GridView ID="gvISBN" runat="server" Visible="False">
        </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
