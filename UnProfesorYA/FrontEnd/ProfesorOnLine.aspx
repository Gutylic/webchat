<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfesorOnLine.aspx.cs" Inherits="FrontEnd.ProfesorOnLine" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%-- <script src="edit.js"></script>--%>
    <script type="text/javascript" src="http://www.wiris.net/demo/editor/editor"></script>
 
    <script>

        var toolbart = '<toolbar ref="general" removeLinks="true"><tab ref="general"><removeItem ref="setFontSize"/><removeItem ref="parenthesis"/><removeItem ref="curlyBracket"/><removeItem ref="squareBracket"/><removeItem ref="setFontFamily"/><removeItem ref="forceLigature"/><removeItem ref="rtl"/><removeItem ref="mtext"/><removeItem ref="setColor"/><removeItem ref="autoItalic"/><removeItem ref="italic"/><removeItem ref="bold"/><removeItem ref="undo"/><removeItem ref="redo"/><removeItem ref="paste"/><removeItem ref="cut"/><removeItem ref="copy"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="symbols"><removeItem ref="&#10878;"/><removeItem ref="&#10877;"/><removeItem ref="*"/><removeItem ref="="/><removeItem ref="<"/><removeItem ref=">"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="greek"><removeItem ref="naturals"/><removeItem ref="rationals"/><removeItem ref="reals"/><removeItem ref="integers"/><removeItem ref="complexes"/><removeItem ref="primes"/><removeItem ref="&#8465;"/><removeItem ref="&#8476;"/><removeItem ref="ell"/><removeItem ref="&#8501;"/><removeItem ref="&#8472;"/><removeItem ref="&#8497;"/><removeItem ref="&#8466;"/><removeItem ref="zTransform"/><removeItem ref="arabicIndicNumbers"/><removeItem ref="easternArabicIndicNumbers"/></tab><tab ref="matrices"><removeItem ref="piecewiseFunction"/><removeItem ref="equationAlign"/></tab><tab ref="scriptsAndLayout"><removeItem ref="bigOpUnderover"/><removeItem ref="bigOpUnder"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/><removeItem ref="bevelledFraction"/><removeItem ref="smallBevelledFraction"/><removeItem ref="smallFraction"/><removeItem ref="digitSpace"/><removeItem ref="backSpace"/><removeItem ref="thinnerSpace"/><removeItem ref="thinSpace"/></tab><tab ref="bracketsAndAccents"><removeItem ref="parenthesis"/><removeItem ref="squareBracket"/><removeItem ref="angleBrackets"/><removeItem ref="curlyBracket"/><removeItem ref="openParenthesis"/><removeItem ref="closeParenthesis"/><removeItem ref="openSquareBracket"/><removeItem ref="closeSquareBracket"/><removeItem ref="openAngleBracket"/><removeItem ref="closeAngleBracket"/><removeItem ref="openCurlyBracket"/><removeItem ref="closeCurlyBracket"/></tab><tab ref="bigOps"><removeItem ref="sumSubsuperscript"/><removeItem ref="sumSubscript"/><removeItem ref="productSubsuperscript"/><removeItem ref="productSubscript"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/></tab><tab ref="calculus"><removeItem ref="sinus"/><removeItem ref="cosinus"/><removeItem ref="tangent"/><removeItem ref="log"/><removeItem ref="nlog"/><removeItem ref="naturalLog"/><removeItem ref="cosecant"/><removeItem ref="secant"/><removeItem ref="cotangent"/><removeItem ref="arcsinus"/><removeItem ref="arccosinus"/><removeItem ref="arctangent"/></tab>               <tab ref="contextual"><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/><removeItem ref="addFrame"/><removeItem ref="removeFrame"/><removeItem ref="matrixSolidLine"/><removeItem ref="matrixDashLine"/><removeItem ref="removeLineBelow"/><removeItem ref="removeLineRight"/><removeItem ref="alignRowsTop"/><removeItem ref="alignRowsCenter"/><removeItem ref="alignRowsBottom"/> <removeItem ref="alignRowsBottom"/><removeItem ref="alignRowsBaseline"/>  <removeItem ref="alignRowsAxis"/><removeItem ref="equalRowHeight"/><removeItem ref="equalColWidth"/><removeItem ref="setColumnSpacing"/><removeItem ref="setRowSpacing"/><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/></tab></toolbar>';
        var editor;

        window.onload = function () {

            editor = com.wiris.jsEditor.JsEditor.newInstance({
                'languaje': 'es', 'toolbar': toolbart
            });

            editor.insertInto(document.getElementById('editorContainer'));

        }

        function Cargar_Variable_CSharp() {

            document.getElementById("Contenido_Wiris").value = editor.getMathML();

        };

       

        

    </script>











</head>
<body>
    <form id="form1" runat="server">
    <div>
        
         <div class="editor" id="editorContainer"></div>
                                       
         <asp:HiddenField ID="Contenido_Wiris" runat="server" />
       
        <table>
            <tr>
                <td>&nbsp;</td>
                <td>
       
         <asp:FileUpload ID="Subir_Adjunto" runat="server" />
                                        
                </td>
            </tr>
            <tr>
                <td>Materia</td>
                <td>
                    <asp:TextBox ID="TxtMateria" runat="server" Width="355px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>colegio</td>
                <td>
                    <asp:TextBox ID="TxtColegio" runat="server" Width="355px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>tema</td>
                <td>
                    <asp:TextBox ID="TxtTema" runat="server" Width="355px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>profesor</td>
                <td>
                    <asp:TextBox ID="TxtProfesor" runat="server" Width="355px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>año</td>
                <td>
                    <asp:TextBox ID="TxtAno" runat="server" Width="355px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnEnviarEjercicio" runat="server" Text="Enviar Ejercicios" OnClientClick="Cargar_Variable_CSharp()" OnClick="BtnEnviarEjercicio_Click" />
                </td>
            </tr>
            
        </table>
         
        
        
        
                                       
    </div>
    </form>
</body>
</html>
