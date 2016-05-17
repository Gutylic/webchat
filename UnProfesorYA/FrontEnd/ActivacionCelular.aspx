<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivacionCelular.aspx.cs" Inherits="FrontEnd.ActivacionCelular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TxtActivacion" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnActivarCelular" runat="server" Text="Activar Usuario" OnClick="BtnActivarCelular_Click" />
    
    </div>
    </form>
</body>
</html>
