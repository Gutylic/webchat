using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class RespuestaMisExplicaciones : System.Web.UI.Page
    {
        obtenerRespuestaVisible oRV = new obtenerRespuestaVisible();

        protected void Page_Load(object sender, EventArgs e)
        {
            string respuestaExplicacion = oRV.recuperarUbicacionExplicacion(Convert.ToInt16(Session["Identificador"]));// obtengo la explicacion de donde esta ubicado el video y lo muestra
            resultadoVideo.Src = "http://www.youtube.com/embed/" + respuestaExplicacion + "?rel=0&showinfo=0";
           

        }
    }
}