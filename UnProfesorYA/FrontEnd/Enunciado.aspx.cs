using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

namespace FrontEnd
{
    public partial class Enunciado : System.Web.UI.Page
    {
        botonesListado bL = new botonesListado();
        compraEjerciciosDataList cEDL = new compraEjerciciosDataList();
        comprarExplicacionDataList cEVDL = new comprarExplicacionDataList();
        compraVideosDataList cVD = new compraVideosDataList();
        logicaAvisoExplicacion lAE = new logicaAvisoExplicacion();
       
        string valorAlfanumerico;
       

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

        protected void BtnEjercicio_Click(object sender, EventArgs e)
        {
            
            bool? error = cEDL.evitarRecomprarEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), (Convert.ToInt16(Session["ID_Ejercicio"])));

            if (error == false)
            {
                // cartelito de ejercicio ya comprado
                return;
            }

            int? respuesta = cEDL.activacionOfertas(2);
            
            switch(respuesta)
            {     
                case 0:
                    valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?0";
                    break;
                case 1:
                    valorAlfanumerico = cEDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]),2);                   
                    break;
                case 2:
                    valorAlfanumerico = cEDL.oferta2x1Ejercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 3:
                    valorAlfanumerico = cEDL.ofertaGratis (Convert.ToInt32(Session["Variable_ID_Usuario"]));
                    break;
                case 4:
                    valorAlfanumerico = cEDL.oferta2DescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]),2);
                    break;                   
                case 6:
                    valorAlfanumerico =  cEDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]),2).ToString();
                    break;
                case 7:
                    valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?35";
                    break; 
                case 8:
                    valorAlfanumerico = cEDL.ofertaDescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]),2);
                    break;
                case 11:
                    valorAlfanumerico = cEDL.ofertaEjerciciosGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]),2);
                    break;

            }

            if (respuesta == 5)
            { 
                cEDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }           
            string[] dato = new string[2];
            dato = valorAlfanumerico.Split('?');            
            error = cEDL.permitirComprarEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".",",")));
            if (error == false)
            {
                // cartelito no tenes plata
                return;
            }
            
            error = cEDL.compraEjercicioDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt32(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt32(dato[1]), Convert.ToInt32(dato[2]));
            
            if (respuesta == 7)
            { 
                cEDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]),2);
            }
            if (error == true)
            {
                // cartelito ejercicio comprado
                return;
            }
        }

        protected void BtnExplicacion_Click(object sender, EventArgs e)
        {
            bool? error = cEVDL.evitarRecomprarExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), (Convert.ToInt16(Session["ID_Ejercicio"])));

            if (error == false)
            {
                // cartelito de ejercicio ya comprado
                return;
            }

            int? respuesta = cEVDL.activacionOfertas(2);

            switch (respuesta)
            {
                case 0:
                    valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?0";
                    break;
                case 1:
                    valorAlfanumerico = cEVDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 2:
                    valorAlfanumerico = cEVDL.oferta2x1Explicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 3:
                    valorAlfanumerico = cEVDL.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                    break;
                case 4:
                    valorAlfanumerico = cEVDL.oferta2DescuentoExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 6:
                    valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                    break;
                case 7:
                    valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?35";
                    break;
                case 8:
                    valorAlfanumerico = cEVDL.ofertaDescuentoExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 11:
                    valorAlfanumerico = cEVDL.ofertaExplicacionGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;

            }

            if (respuesta == 5)
            {
                cEVDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            string[] dato = new string[2];
            dato = valorAlfanumerico.Split('?');
            error = cEVDL.permitirComprarExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
            if (error == false)
            {
                // cartelito no tenes plata
                return;
            }
            error = cEVDL.compraExplicacionDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt16(dato[1]), Convert.ToInt16(dato[2]));

            if (respuesta == 7)
            {
                cEVDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            if (error == true)
            {
                lAE.avisoDeMensajeAlCorreo(Convert.ToString(Session["Name_Usuario"]));
                // cartelito ejercicio comprado
                return;
            }
        }

        protected void BtnVideo_Click(object sender, EventArgs e)
        {
            bool? error = cVD.evitarRecomprarVideo(Convert.ToInt32(Session["Variable_ID_Usuario"]), (Convert.ToInt16(Session["ID_Ejercicio"])));

            if (error == false)
            {
                // cartelito de ejercicio ya comprado
                return;
            }

            int? respuesta = cVD.activacionOfertas(2);

            switch (respuesta)
            {
                case 0:
                    valorAlfanumerico = cVD.compraSinOferta(2).ToString() + "?7?0";
                    break;
                case 1:
                    valorAlfanumerico = cVD.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 2:
                    valorAlfanumerico = cVD.oferta2x1Video(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 3:
                    valorAlfanumerico = cVD.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                    break;
                case 4:
                    valorAlfanumerico = cVD.oferta2DescuentoVideo(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 6:
                    valorAlfanumerico = cVD.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                    break;
                case 7:
                    valorAlfanumerico = cVD.compraSinOferta(2).ToString() + "?7?35";
                    break;
                case 8:
                    valorAlfanumerico = cVD.ofertaDescuentoVideo(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 11:
                    valorAlfanumerico = cVD.ofertaVideosGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;

            }

            if (respuesta == 5)
            {
                cVD.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            string[] dato = new string[2];
            dato = valorAlfanumerico.Split('?');
            error = cVD.permitirComprarVideos(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
            if (error == false)
            {
                // cartelito no tenes plata
                return;
            }
            error = cVD.compraVideoDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt16(dato[1]), Convert.ToInt16(dato[2]));

            if (respuesta == 7)
            {
                cVD.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            if (error == true)
            {
                // cartelito ejercicio comprado
                return;
            }
        }
    }
}