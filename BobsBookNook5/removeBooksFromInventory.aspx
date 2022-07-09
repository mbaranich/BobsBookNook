<%@ Page Language="C#" AutoEventWireup="true" CodeFile="removeBooksFromInventory.aspx.cs" Inherits="removeBooksFromInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove Books from Inventory</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnReturntoAdmin" runat="server" OnClick="btnReturntoAdmin_Click" Text="Return to Admin" />
        <br />
        <asp:GridView ID="gvDeleteBooks" runat="server" AutoGenerateColumns="False" DataKeyNames="ISBN" OnSelectedIndexChanged="gvDeleteBooks_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat ="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:CommandField ButtonType="Button" NewText="" SelectText="Delete Book" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
