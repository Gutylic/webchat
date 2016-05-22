using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class RespuestaMisEjercicios : System.Web.UI.Page
    {
        obtenerRespuestaVisible oRV = new obtenerRespuestaVisible();

        protected void Page_Load(object sender, EventArgs e)
        {
            string respuestaVisible = oRV.recuperarUbicacionEjercicio(Convert.ToInt16(Session["Identificador"]));
            respuestaEjercicios.ImageUrl = "http://www.colegioeba.com/respuesta/" + respuestaVisible + ".png"; // reescribe la url de la imagen/ carga el enunciado
        }
    }
}