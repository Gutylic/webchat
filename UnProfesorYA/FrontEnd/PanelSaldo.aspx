<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelSaldo.aspx.cs" Culture="en-US" UICulture="de" Inherits="FrontEnd.PanelSaldo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LblNombreUsuario" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="LblCreditoSaldo" runat="server" Text="Label"></asp:Label>
    </div>

        <asp:DataList ID="DataList_Mis_Movimientos" Width="100%" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="col-xs-2 fecha_de_movimiento"><%# Eval ("fechaMovimiento","{0:dd/MM/yyyy}") %></div>
                    <div class="col-xs-6 descripcion"><%# Eval ("tipoMovimiento") %></div>
                    <div class="col-xs-2 plata_debe"><%# Eval ("debe","{0:c2}") %></div>
                    <div class="col-xs-2 plata_haber"><%# Eval ("haber","{0:c2}") %></div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>
