<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessEmail.aspx.cs" Inherits="ProcessEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Process Email</title>
    <style type="text/css">
        .auto-style1 {
            margin-right: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btnBackToAdmin" runat="server" CssClass="auto-style1" OnClick="btnBackToAdmin_Click" Text="Back to Admin" />
        <br />
        <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Make XML" Width="130px" />
        <br />
        <asp:Button ID="btnStep2" runat="server" Enabled="False" OnClick="btnStep2_Click" Text="Step 2" Width="130px" />
        <p>
            <asp:TextBox ID="txtOwnerID" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblErrorMessage" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:ListBox ID="lstRawXML" runat="server" Height="125px" Width="180px"></asp:ListBox>
        <asp:ListBox ID="lstEmail" runat="server" Height="125px" Width="180px"></asp:ListBox>
    </form>
</body>
</html>
