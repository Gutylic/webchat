<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactenos.aspx.cs" Inherits="FrontEnd.Contactenos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 419px;
        }
        .auto-style2 {
            height: 19px;
        }
        .auto-style3 {
            width: 419px;
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>Usuario</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="410px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Mail</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TxtBoxCOrreo" runat="server" Width="412px"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>Repetir</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtBoxRepetirCorreo" runat="server" Width="409px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Telefono</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListPais" runat="server">
                         <asp:ListItem Value="" Text=""></asp:ListItem>
                         <asp:ListItem Value="Argentina" Text="Argentina"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtBoxArea" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TxtBoxCelular" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtBoxComentario" runat="server" Height="52px" TextMode="MultiLine" Width="405px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="BtnEnvioComentario" runat="server" Text="Enviar Comentario" OnClick="BtnEnvioComentario_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
