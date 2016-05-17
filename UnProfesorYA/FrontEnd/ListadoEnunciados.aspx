<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoEnunciados.aspx.cs" Inherits="FrontEnd.ListadoEnunciados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 97px;
        }
        .auto-style2 {
            width: 646px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Explicaciones en vídeos y ejercicios</h3>

        <asp:DataList ID="DataList_De_Resultados" runat="server" OnItemDataBound="logosAsociados" OnItemCommand="Identificador">
            <ItemTemplate>
                <table>
                    <tr>
                        <td class="columna_1_datalist_inicial" >
                            <asp:Image ID="Imagen_Logos" CssClass="logo" runat="server" />
                        </td>
                        <td class="columna_2_datalist_inicial">
                            <asp:LinkButton runat="server" ToolTip="presione para mirar" CssClass="link_datalist" ID="Titulos_De_Productos" CommandName='<%# Eval ("id_Ejercicio") %>'> <%# Eval ("Titulo") %> </asp:LinkButton>
                        </td>
                    </tr> 
                </table>
            </ItemTemplate> 
        </asp:DataList>

        <div id="Centros_Paginados" runat="server" visible="false">   
            <asp:LinkButton ID="Anterior" runat="server" OnClick="Anterior_Click" ><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente" runat="server" OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton>
        </div> 
                          
        <div id="Extremos_Paginados" runat="server">
            <asp:LinkButton ID="Anterior_Ultimo" Visible="false" runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente_Primero" runat="server" OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
        </div>
                              
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">profesor</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtBoxProfesor" runat="server" Width="625px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">materia</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtBoxMateria" runat="server" Width="625px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">año</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtBoxAño" runat="server" Width="625px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">colegio</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtBoxColegio" runat="server" Width="625px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">tema</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtBoxTema" runat="server" Width="625px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="BtnBuqueda" runat="server" Text="Buscar" OnClick="BtnBuqueda_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
