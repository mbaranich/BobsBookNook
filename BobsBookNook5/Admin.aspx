<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bob's BookNook Admin Page</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        td {
            vertical-align: top ;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td rowspan="2">
                    <asp:ListBox ID="lstProgress" runat="server" Height="350px" Width="200px"></asp:ListBox>
                </td>
                <td>Your Software OwnerID <asp:TextBox ID="txtOwnerID" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Button ID="btnResetUser" runat="server" Text="Reset User" OnClick="btnResetUser_Click" />
                    <br />
                    <br />
                    If you click [Clear Database] you will have to reload all xml and jpg files
                    <asp:Button ID="btnClearDB" runat="server" BackColor="Red" ForeColor="Yellow" Text="Clear Databse" OnClick="btnClearDB_Click" />
                    <br />
                    <br />
                    Browse for and select BookJacket images, then Click [Load Images]<br />
&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnLoadImages" runat="server" Text="Load Images" OnClick="btnLoadImages_Click" />
                    <br />
                    Browse for BookInventory.xml file, then click [Import Book Data]<br />
&nbsp;<asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="btnLoadXML" runat="server" Text="Import Book Data" OnClick="btnLoadXML_Click" />
                    <br />
                    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnViewInventory" runat="server" Text="View Inventory" OnClick="btnViewInventory_Click" Width="125px" />
                    <br />
                    <asp:Button ID="btnToBookstore" runat="server" OnClick="btnToBookstore_Click" Text="To Bookstore" Width="125px" />
                    <br />
                    <asp:Button ID="btnProcessBestsellers" runat="server" OnClick="btnProcessBestsellers_Click" Text="Process Bestsellers" Width="125px" />
                    <br />
                    <asp:Button ID="btnRemoveBookTitlesfromCategory" runat="server" OnClick="btnRemoveBookTitlesfromCategory_Click" Text="Remove Book Titles from Category" Width="210px" />
                    <br />
                    <asp:Button ID="btnProcessEmail" runat="server" OnClick="btnProcessEmail_Click" Text="Email Marketing" Width="125px" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="False">
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
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:ListBox ID="lstHidden" runat="server" Visible="False"></asp:ListBox>
        <asp:GridView ID="gvHidden" runat="server" Visible="False">
        </asp:GridView>
    </form>
</body>
</html>
