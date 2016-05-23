<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RespuestasFichas.aspx.cs" Inherits="FrontEnd.RespuestasFichas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .datalist_resultado {
            margin-right: 899px;
        }
    </style>
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
                    <asp:Button ID="BtnIrEnunciado" runat="server" Text="ir a enunciado"/>
                </td>
            </tr>
            </table>
           
            <asp:DataList ID="Resultado_DataList_Ficha" CssClass="datalist_resultado" OnItemCommand="Identificador" runat="server" Width="890px" >
                <ItemTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td><asp:Image style="width:50%; margin-bottom:5px" ID="Imagen_Enunciado" ImageUrl='<%#"http://www.colegioeba.com/enunciado/Enunciado"+ Eval("ID_Ejercicio") + ".png"%>' runat="server" /></td>                            
                        </tr>
                        <tr>
                            <td><%--<asp:Image style="width:21.25%; margin-bottom:5px" ID="Imagen_Ficha" ImageUrl='<%#"http://www.colegioeba.com/ficha/Ficha"+ Eval("ID_Ejercicio") + ".png"%>' runat="server" />--%></td>                           
                        </tr>
                        <tr>
                            <td><asp:Button style="width:23%" ID="Boton_Comprar_Ejercicio" ToolTip="quiere el ejercicio resuelto" CommandArgument="1" runat="server" CommandName='<%# Eval ("ID_Ejercicio") %>' Text="Ejercicio" /></td>                            
                        </tr>
                        <tr>
                            <td><asp:Button style="width:23%" ID="Boton_Comprar_Explicacion" ToolTip="quiere el ejercicio explicado" CommandArgument="2" runat="server" CommandName='<%# Eval ("ID_Ejercicio") %>' Text="Explicación" /></td>
                        </tr>
                    </table>                                                                    
                </ItemTemplate>
            </asp:DataList>
            
            <div id="Centros_Paginados" class="paginado" runat="server" visible="false">
                <asp:LinkButton ID="Anterior" ForeColor="DimGray"  OnClick="Anterior_Click" runat="server"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente" ForeColor="DimGray" OnClick="Siguiente_Click" runat="server">&nbsp Siguiente >></asp:LinkButton>
            </div>                        
         
            <div id="Extremos_Paginados" runat="server">
                <asp:LinkButton ID="Anterior_Ultimo"  Visible="false" ForeColor="DimGray"  runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server"  OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
            </div>
    </div>
    </form>
</body>
</html>
