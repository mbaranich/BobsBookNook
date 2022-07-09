<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bob's Book Nook Login</title>
    <style type="text/css">
        #buttonDiv {
            text-align:center;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Enter your ownerID:</td>
                <td>
                    <asp:TextBox ID="txtOwnerID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Re-enter ownerID:</td>
                <td>
                    <asp:TextBox ID="txtOwnerID0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
