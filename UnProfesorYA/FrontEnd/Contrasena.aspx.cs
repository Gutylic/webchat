using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace FrontEnd
{
    public partial class Contrasena : System.Web.UI.Page
    {
        logicaRegistroUsuarios lRU = new logicaRegistroUsuarios();
        int respuesta;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnContrasena_Click(object sender, EventArgs e)
        {
            respuesta = lRU.recuperarContrasenaCorreo(TxtBoxContrasena.Text, 2);
            if (respuesta == 1) 
            { 
                // cartelito de contraseña enviada
                return;
            }
            // cartelito de contraseña no enviada

        }

        protected void BtnContrasenaTelefono_Click(object sender, EventArgs e)
        {
            int celularCorregido = lRU.correccionTelefono(int.Parse(DropDownListPais.SelectedValue), TxtArea.Text, TxtBoxCelular.Text);
            respuesta = lRU.recuperarContrasenaCelular(celularCorregido.ToString(), 2);
            if (respuesta == 1)
            {
                // cartelito de contraseña enviada
                return;
            }
            // cartelito de contraseña no enviada
        
        
        
        }

       



       
    }
}