using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class Enunciado : System.Web.UI.Page
    {
        botonesListado bL = new botonesListado();

        protected void Page_Load(object sender, EventArgs e)
        {
            enunciadosEjercicios.ImageUrl = "http://www.colegioeba.com/enunciado/Enunciado" +  Convert.ToInt16(Session["ID_Ejercicio"]) + ".png"; // carga el enunciado
                       
            // botones para comprar
            switch (bL.determinarCantidadDeBotones(Convert.ToInt16(Session["ID_Ejercicio"])))  // si se trata de un ejercicio o explicacion se necesitan dos botones, si se trata de un video o un pack solo un boton
            {
                case 1: // habilita el panel para mostrar dos botones
                    BtnEjercicio.Visible = true;
                    BtnExplicacion.Visible = true;
                    BtnVideo.Visible = false;
                    break;
                case 2: // habilita el panel para mostrar dos botones
                    BtnEjercicio.Visible = true;
                    BtnExplicacion.Visible = true;
                    BtnVideo.Visible = false;
                    break;
                case 3: // habilita el panel para mostrar un boton
                    BtnEjercicio.Visible = false;
                    BtnExplicacion.Visible = false;
                    BtnVideo.Visible = true;
                    break;
            }




        
        }
    }
}