<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="FrontEnd.Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <script   src="https://code.jquery.com/jquery-2.2.3.min.js"   integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo="   crossorigin="anonymous"></script>
  
    <script>
        $(document).ready(function () {
            function session_expirada() {
                $.ajax({
                    type: "POST",
                    url: "Logueo.aspx/AbandonarSession",
                    data: {},
                    contenType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                });
            }
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>logueo</td>
                <td>
                    <asp:Button ID="BtnFaceBookLogin" runat="server" Text="Facebook" OnClick="BtnFacebookLogin_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">usuario:&nbsp;
                    <asp:TextBox ID="TxtBoxUsuario" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Password: 
                    <asp:TextBox ID="TxtBoxPassword" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnLogueo" runat="server" Text="Loguearse" OnClick="BtnLogueo_Click"  />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="CheckBoxMantenerSession" runat="server" /> Mantener Session
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
