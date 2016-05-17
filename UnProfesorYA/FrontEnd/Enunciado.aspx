<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enunciado.aspx.cs" Inherits="FrontEnd.Enunciado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Button ID="BtnEjercicio" runat="server" Text="Comprar Ejercicio" Visible ="false" />
                </td>
                <td>
                    <asp:Button ID="BtnExplicacion" runat="server" Text="Comprar Explicacion" Visible ="false" />
                </td>
                <td>
                    <asp:Button ID="BtnVideo" runat="server" Text="Comprar Video" Visible="false" />
                </td>
            </tr>
        </table>
    <div>
        <asp:Image ID="enunciadosEjercicios" ImageUrl="http" Width="100%" runat="server" />   
    </div>
    </form>
</body>
</html>
