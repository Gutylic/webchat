using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class ActivacionCelular : System.Web.UI.Page
    {

        registroDeUsuarios rDU = new registroDeUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnActivarCelular_Click(object sender, EventArgs e)
        {

            rDU.datosUsuarioActivacionTelefono((string)Session["ID_Usuario"], 2, int.Parse(TxtActivacion.Text));
            Response.Redirect("Logueo.aspx");

        }
    }
}