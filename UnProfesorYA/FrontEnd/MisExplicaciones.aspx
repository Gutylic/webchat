<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisExplicaciones.aspx.cs" Inherits="FrontEnd.MisExplicaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList_Mis_Explicaciones" runat="server" OnItemCommand="Identificador">
            <ItemTemplate>
                   <table style="width: 100%;">
                    <tr>

                        <td><asp:Label ID="Etiqueta_Titulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label></td>
                              
                        <td><asp:Label ID="Etiqueta_Duracion" runat="server" Text='<%# string.Concat(Eval("vencimiento")," día(s)")%>'></asp:Label></td>                       
                    
                        <td><asp:LinkButton ID="Video" runat="server" CommandName='<%# Eval("id_Ejercicio")%>'>Vídeo</asp:LinkButton></td>                        
                                               
                    </tr>

                </table>         
            </ItemTemplate>
        </asp:DataList>
                            
        <div id="Centros_Paginados" runat="server" visible="false">

            <asp:LinkButton ID="Anterior" ForeColor="DimGray" style="text-decoration:none;" OnClick="Anterior_Click" runat="server"><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente" ForeColor="DimGray" OnClick="Siguiente_Click" style="text-decoration:none;" runat="server">&nbsp Siguiente >></asp:LinkButton>

        </div>
       
        <div id="Extremos_Paginados" runat="server">

            <asp:LinkButton ID="Anterior_Ultimo"  Visible="false" ForeColor="DimGray"  runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
            <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server"  OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
        
        </div>
    </div>                                   
    </form>
</body>
</html>
