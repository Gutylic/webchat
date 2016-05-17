<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="FrontEnd.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


<title></title>
    
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <table>
            <tr>
                <td>Correo</td>
                <td>facebook</td>
                <td>telefono</td>
            </tr>
            <tr>
                <td>

                    <asp:LinkButton ID="LinkBtnReenvio" runat="server" OnClick="LinkBtnReenvio_Click">Reenviar la activacion</asp:LinkButton>
                </td>
                <td>
                    
                   
                    
                    
                    <asp:Button ID="BtnFacebook" runat="server" Text="Registrar con Facebook" OnClick="BtnFacebook_Click" />
                    
                   
                    
                    
                  </td> 

                <td>
                    pais<asp:DropDownList ID="DropDownListPais" AutoPostBack="true" runat="server"> 
<asp:ListItem Value="1" Text="Argentina" Selected="True"></asp:ListItem> 
<asp:ListItem Value="2" Text=""></asp:ListItem> 
<asp:ListItem Value="3" Text=""></asp:ListItem> 
<asp:ListItem Value="4" Text=""></asp:ListItem> 
</asp:DropDownList> 
&nbsp; area<asp:TextBox ID="TxtArea" runat="server"></asp:TextBox>
&nbsp;celular<asp:TextBox ID="TxtBoxCelular" runat="server"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    correo<asp:TextBox ID="TxtBoxCorreo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    contraseña<asp:TextBox ID="TxtBoxContrasenaCelular" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    comprobar correo
                    <asp:TextBox ID="TxtBoxComprobarCorreo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    comprobar contraseña
                    <asp:TextBox ID="TxtBoxComprobarContrasenaCelular" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    contraseña
                    <asp:TextBox ID="TxtBoxContrasenaCorreo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style3">
                    <asp:CheckBox ID="ChckBoxCondicionesCelular" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    comprobar contraseña
                    <asp:TextBox ID="TxtBoxComprobarContrasenaCorreo" runat="server" Width="118px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="BtnEnviarCelular" runat="server" Text="Registrate por celular" OnClick="BtnEnviarCelular_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Image ID="ImagenCaptcha" runat="server"/>  


                </td>
                <td >&nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    Imagen
                    <asp:TextBox ID="TxtBoxCaptcha" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:CheckBox ID="ChckBoxCondicionesCorreo" runat="server" /><asp:LinkButton ID="LinkButton1" runat="server">Terminos y condiciones</asp:LinkButton>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnEnviarCorreo" runat="server" Text="Registrar por correo" OnClick="BtnEnviarCorreo_Click" />
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
