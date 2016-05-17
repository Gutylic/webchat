<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="FrontEnd.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        reEstoy logueado <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
    <asp:Button ID="BtnCerrarSession" runat="server" Text="X" OnClick="CerrarSession_Click" />

        <br />
        <br />
        <asp:Button ID="BtnPanelControl" runat="server" Text="Panel Control" OnClick="BtnPanelControl_Click" />

        <br />
        <asp:Button ID="BtnPanelSaldo" runat="server" Text="Panel Saldo" OnClick="BtnPanelSaldo_Click" />

        <br />
        <asp:Button ID="BtnPanelCarga" runat="server" Text="Panel Carga" OnClick="BtnPanelCarga_Click" />

        <br />
        <asp:Button ID="BtnDataList" runat="server" Text="Ejercicios" OnClick="BtnDataList_Click" />

    </div>
    </form>
</body>
</html>
