<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bob's Book Nook</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        td {
            vertical-align: top ;
        }
        .auto-style4 {
            width: 513px;
            height: 212px;
        }
        .auto-style5 {
            width: 188px;
            height: 176px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td>
                    <img alt="Logo" class="auto-style5" src="logo.png" />&#39;<br />
                    <asp:Button ID="btnClearSearchOptions" runat="server" OnClick="btnClearSearchOptions_Click" Text="Clear Search Options" />
                    <asp:Button ID="btnViewBestSellers" runat="server" OnClick="btnViewBestSellers_Click" Text="View Best Sellers" />
                </td>
                <td>
                    <img alt="Banner" class="auto-style4" src="banner.png" /></td>
            </tr>
            <tr>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:GridView ID="gvAuthors" runat="server" AutoGenerateColumns="False" DataKeyNames="Author" OnSelectedIndexChanged="gvAuthors_SelectedIndexChanged" BackColor="#F4641B">
                                    <Columns>
                                        <asp:BoundField DataField="Author" HeaderText="Author" />
                                        <asp:CommandField ButtonType="Button" CausesValidation="False" SelectText="View" ShowCancelButton="False" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </td>
                            <td>
                                <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="Category" OnSelectedIndexChanged="gvCategories_SelectedIndexChanged" BackColor="#F4641B">
                                    <Columns>
                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                        <asp:CommandField ButtonType="Button" CausesValidation="False" SelectText="View" ShowCancelButton="False" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:GridView ID="gvCatalog" runat="server" AutoGenerateColumns="False" BackColor="#F4641B">
                     <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                     <asp:Image ID="Image1" runat ="server" ImageUrl='<%# (string) FormatImageURL( (string) Eval("Image")) %>' />
                        </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:HyperLinkField DataNavigateUrlFields="ISBN" DataNavigateUrlFormatString="ShoppingCart.aspx?Id={0}" DataTextField="ISBN" DataTextFormatString="Buy Me" HeaderText="Click to Purchase" NavigateUrl="~/ShoppingCart.aspx" Target="_top" Text="ISBN" />
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
