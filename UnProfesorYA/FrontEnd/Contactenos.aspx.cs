using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;

namespace FrontEnd
{
    public partial class Contactenos : System.Web.UI.Page
    {
        logicaMensajeCliente lMC = new logicaMensajeCliente();
        envioMensajeCliente eMC = new envioMensajeCliente();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnvioComentario_Click(object sender, EventArgs e)
        {
            int error = lMC.erroresEnvioMensaje(TxtUsuario.Text, TxtBoxCOrreo.Text, TxtBoxRepetirCorreo.Text, TxtBoxComentario.Text);
            switch (error)
            { 
                case 1:
                    //cartel todo vacio
                    break;

                case 2:
                    // cartel no coiciden los correos
                    break;

                case 3:
                    // cartel comentario muy corto
                    break;
            
            }

            string Mensaje = lMC.armadoComentario(DropDownListPais.SelectedValue, TxtBoxArea.Text, TxtBoxCelular.Text, TxtBoxComentario.Text);

            int? Error = eMC.comentarioMensajeCliente(TxtUsuario.Text, TxtBoxCOrreo.Text, TxtBoxRepetirCorreo.Text, Mensaje);

            if (Error == 1)
            { 
                // cartel de mensaje enviado
                lMC.avisoDeMensajeAlCorreo(TxtUsuario.Text, TxtBoxCOrreo.Text);
            }



        }
    }
}