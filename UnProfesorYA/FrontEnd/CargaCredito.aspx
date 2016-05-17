<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargaCredito.aspx.cs" Inherits="FrontEnd.CargaCredito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TxtTarjeta" runat="server" Width="229px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSOS" runat="server" Text="Prestamo SOS" OnClick="BtnSOS_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnTarjeta" runat="server" Text="Carga Prepaga" OnClick="BtnTarjeta_Click" style="height: 26px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
