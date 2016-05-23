<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RespuestasEnunciados.aspx.cs" Inherits="FrontEnd.RespuestasEnunciados" %>

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
                <td>
                    <asp:Button ID="BtnMiEjercicio" runat="server" Text="Mi ejercicio" OnClick="BtnMiEjercicio_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnMiExplicacion" runat="server" Text="Mi explicacion" OnClick="BtnMiExplicacion_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnIrFicha" runat="server" Text="ir a enunciado" OnClick="BtnirFicha_Click"/>
                </td>
            </tr>
            </table>


        <asp:DataList ID="Resultado_DataList_Enunciado" CssClass="datalist_resultado" runat="server" OnItemCommand="Identificador">
            <ItemTemplate>
                <table style="width: 100%;">
                        <tr>
                            <td><asp:Image style="width:50%; margin-bottom:5px" ID="Imagen_Enunciado" ImageUrl='<%#"http://www.colegioeba.com/enunciado/Enunciado"+ Eval("id_Ejercicio") + ".png"%>' runat="server" /></td>
                        </tr>
                        <tr>
                            <td><%--<asp:Image style="width:21.25%; margin-bottom:5px" ID="Imagen_Ficha" ImageUrl='<%#"http://www.colegioeba.com/ficha/Ficha"+ Eval("id_Ejercicio") + ".png"%>' runat="server" />--%></td>
                        </tr>
                        <tr>
                            <td><asp:Button style="width:23%" ID="Boton_Comprar_Ejercicio" ToolTip="quiere el ejercicio resuelto" CommandArgument="1" runat="server" CommandName='<%# Eval ("id_Ejercicio") %>' Text="Ejercicio" /></td>
                        </tr>    
                        <tr>
                            <td><asp:Button style="width:23%" ID="Boton_Comprar_Explicacion"  ToolTip="quiere el ejercicio explicado" CommandArgument="2" runat="server" CommandName='<%# Eval ("id_Ejercicio") %>' Text="Explicación" /></td>
                        </tr>                 
            </ItemTemplate>
        </asp:DataList>

        <div id="Centros_Paginados" class="paginado" runat="server" visible="false">
            <asp:LinkButton ID="Anterior" ForeColor="DimGray" style="text-decoration:none;" OnClick="Anterior_Click" runat="server"><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente" ForeColor="DimGray" OnClick="Siguiente_Click" style="text-decoration:none;" runat="server">&nbsp Siguiente >></asp:LinkButton>
        </div>                        
        <div id="Extremos_Paginados" runat="server">
            <asp:LinkButton ID="Anterior_Ultimo"  Visible="false" ForeColor="DimGray" style="text-decoration:none;"  runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server" style="text-decoration:none;" OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
        </div>
        


    </div>
    </form>
</body>
</html>
