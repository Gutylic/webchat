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
    public partial class RespuestasFichas : System.Web.UI.Page
    {

        diseñoPaginaFicha dPF = new diseñoPaginaFicha();
        dataListInicialBusqueda dLIB = new dataListInicialBusqueda();
        datosMisEjercicios dME = new datosMisEjercicios();
        compraEjerciciosDataList cEDL = new compraEjerciciosDataList();
        comprarExplicacionDataList cEVDL = new comprarExplicacionDataList();
        logicaAvisoExplicacion lAE = new logicaAvisoExplicacion();
        logicaProfesorOnLine lPOL = new logicaProfesorOnLine();
        profesorOnLine pOL = new profesorOnLine();

        string valorAlfanumerico;

        public void Cargar_Variables_De_URL(string Maestro, string Ano, string Tema, string Colegio, string Materia, string Enunciado1, string Enunciado2, bool Boton_Enunciado, bool Boton_Ficha, int Caso, bool Boton_MiEjercicio, bool Boton_MiExplicacion)
        {   
            ViewState["Etiqueta_Maestro"] = dLIB.Metodo_Buscar_Profesor(Maestro); // recupera desde el URL el Maestro y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Ano"] = dLIB.Metodo_Buscar_Ano(Ano); // recupera desde el URL el Ano y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Tema"] = dLIB.Metodo_Buscar_Tema(Tema); // recupera desde el URL el Tema y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Colegio"] = dLIB.Metodo_Buscar_Colegio(Colegio); // recupera desde el URL el Colegio y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Materia"] = dLIB.Metodo_Buscar_Materia(Materia); // recupera desde el URL el Materia y lo convierto en etiqueta de busqueda para ficha
            ViewState["Boton_Enunciado"] = Boton_Enunciado;
            ViewState["Boton_Ficha"] = Boton_Ficha;
            ViewState["Enunciado1"] = Enunciado1;
            ViewState["Enunciado2"] = Enunciado2;
            ViewState["Caso"] = Caso;

            if (Boton_MiEjercicio == false)
            {
                BtnMiEjercicio.Enabled = false;
            }
            else
            {
                BtnMiEjercicio.Enabled = true;
            }

            if (Boton_MiExplicacion == false)
            {
                BtnMiExplicacion.Enabled = false;
            }
            else
            {
                BtnMiExplicacion.Enabled = true;
            }

        }



        protected void Page_Load(object sender, EventArgs e)
        {

            Cargar_Variables_De_URL(Request.QueryString["Maestro"], Request.QueryString["Ano"], Request.QueryString["Tema"], Request.QueryString["Colegio"], Request.QueryString["Materia"], Request.QueryString["Enunciado1"], Request.QueryString["Enunciado2"], Convert.ToBoolean(Request.QueryString["Boton_Enunciado"]), Convert.ToBoolean(Request.QueryString["Boton_Ficha"]), Convert.ToInt16(Request.QueryString["Caso"]), Convert.ToBoolean(Request.QueryString["Boton_MiEjercicio"]), Convert.ToBoolean(Request.QueryString["Boton_MiExplicacion"])); // carga las variables de la URL   

            Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], 0);// Llama al datalist de enunciados parecidos, desde la pagina cero
            Condiciones_Paginacion(); // datos para armado de la paginacion del datalist
                       
            if ((bool)ViewState["Boton_Enunciado"]) // bloquea el boton ver enunciados
            {
                BtnIrEnunciado.Enabled = true;
            }
            else
            {
                BtnIrEnunciado.Enabled = false;
            }
                        
        }

        protected void BtnMiEjercicio_Click(object sender, EventArgs e)
        {
            BtnMiEjercicio.Enabled = false; // presionado boton quedo anulado
            ViewState["BtnMiEj"] = false;
            int? respuesta = cEDL.activacionOfertas(2); // el 2 es la empresa

            switch (respuesta)
            {
                case 0:
                    valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?0";
                    break;
                case 1:
                    valorAlfanumerico = cEDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 2:
                    valorAlfanumerico = cEDL.oferta2x1Ejercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 3:
                    valorAlfanumerico = cEDL.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                    break;
                case 4:
                    valorAlfanumerico = cEDL.oferta2DescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 6:
                    valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                    break;
                case 7:
                    valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?35";
                    break;
                case 8:
                    valorAlfanumerico = cEDL.ofertaDescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;
                case 11:
                    valorAlfanumerico = cEDL.ofertaEjerciciosGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                    break;

            }

            if (respuesta == 5)
            {
                cEDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            string[] dato = new string[2];
            dato = valorAlfanumerico.Split('?');
            bool? error = cEDL.permitirComprarEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
            if (error == false)
            {
                // cartelito no tenes plata
                return;
            }

            error = cEDL.compraEjercicioDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt32(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt32(dato[1]), Convert.ToInt32(dato[2]));

            if (respuesta == 7)
            {
                cEDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            }
            if (error == true)
            {
                // cartelito ejercicio comprado

                if (Convert.ToInt16(ViewState["Caso"]) == 3) // envio Adjunto Ficha Enunciado
                {
                    pOL.cargarTablaEjercicioVideosPedidosEjercicios(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11), Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
                    lPOL.avisoAdjuntoEnunciadoFichaEnviado(Convert.ToString(Session["Name_Usuario"])); 
                }
                if (Convert.ToInt16(ViewState["Caso"]) == 2) // envio Adjunto Ficha
                {
                    pOL.cargarTablaEjercicioVideosPedidosEjercicios(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11),null, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
                    lPOL.avisoAdjuntoSoloEnviado(Convert.ToString(Session["Name_Usuario"])); 
                }
                if (Convert.ToInt16(ViewState["Caso"]) == 6) // envio Enunciado Ficha
                {
                    pOL.cargarTablaEjercicioVideosPedidosEjercicios(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11), Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), null);
                    lPOL.avisoEnunciadoFichaEnviado(Convert.ToString(Session["Name_Usuario"]));
                }       
                return;
            }
            return;
 
        }

        protected void BtnMiExplicacion_Click(object sender, EventArgs e)
        {
            BtnMiExplicacion.Enabled = false; // presionado boton quedo anulado            
            ViewState["BtnMiExp"] = false;
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
            bool? error = cEVDL.permitirComprarExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
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
                // cartelito ejercicio comprado

                if (Convert.ToInt16(ViewState["Caso"]) == 3) // envio Adjunto Ficha Enunciado
                {
                    pOL.cargarTablaEjercicioVideosPedidos(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11), Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
                    lPOL.avisoAdjuntoEnunciadoFichaEnviado(Convert.ToString(Session["Name_Usuario"]));
                }
                if (Convert.ToInt16(ViewState["Caso"]) == 2) // envio Adjunto Ficha
                {
                    pOL.cargarTablaEjercicioVideosPedidos(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11), null, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
                    lPOL.avisoAdjuntoSoloEnviado(Convert.ToString(Session["Name_Usuario"]));
                }
                if (Convert.ToInt16(ViewState["Caso"]) == 6) // envio Enunciado Ficha
                {
                    pOL.cargarTablaEjercicioVideosPedidos(Convert.ToUInt16(Session["Variable_ID_Usuario"]), Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Ficha"]).Length - 11), Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), null);
                    lPOL.avisoEnunciadoFichaEnviado(Convert.ToString(Session["Name_Usuario"]));
                }
                return;
            }
            return;
                    
        }

        protected void BtnirEnunciado_Click(object sender, EventArgs e)
        {
            string pagina = "RespuestasEnunciado.aspx?Boton_Enunciado=true&Boton_Ficha=true&Boton_MiEjercicio=" + Convert.ToBoolean(ViewState["BtnMiEj"]) + "&Boton_MiExplicacion=" + Convert.ToBoolean(ViewState["BtnMiExp"]) + "&Enunciado1=" + Convert.ToString(ViewState["Enunciado1"]) + "&Enunciado2=" + Convert.ToString(ViewState["Enunciado2"]) + "&Caso=" + Convert.ToUInt16(ViewState["Caso"]) + "&Tema=" + Convert.ToString(Request.QueryString["Maestro"]) + "&Materia=" + Convert.ToString(Request.QueryString["Materia"]) + "&Colegio=" + Convert.ToString(Request.QueryString["Colegio"]) + "&Ano=" + Convert.ToString(Request.QueryString["Ano"]) + "&Maestro=" + Convert.ToString(Request.QueryString["Maestro"]); // busca por ficha y bloquea el boton de buscar por enunciado
            Response.Redirect(pagina);
        }

        public void Listado_De_Parecidos(string Maestro, string Ano, string Colegio, string Materia, string Tema, int Pagina)
        {
            Resultado_DataList_Ficha.DataSource = dPF.DataListFicha(Maestro, Ano, Colegio, Materia, Tema).Skip(Pagina * 5).Take(5); //datalist que contiene las fichas
            Resultado_DataList_Ficha.DataBind();

        }

        public void Identificador(object sender, DataListCommandEventArgs e)
        {
            Session["Identificador"] = int.Parse(e.CommandName); // identifica el ID correspondiente al ejercicio
            int Boton_Presionado = int.Parse(e.CommandArgument.ToString()); // identifica si presione el boton de resolver el ejercicio o el de explicar
            switch (Boton_Presionado)
            {
                case 1: // boton de ejercicios
                    bool? Valor_Ejercicio = dME.analizarSiComproElEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["Identificador"])); //resultado para saber si compro el ejercicio o lo tengo que mostrar
                    if (Valor_Ejercicio == false) 
                    {
                        //ya fue comprado el ejercicio
                        return;
                    }

                    if (Valor_Ejercicio == true) // muestra el ejercicio aun no comprado y lo compra desde mis ejercicios
                    {
                        int? respuesta = cEDL.activacionOfertas(2); // el 2 es la empresa

                        switch (respuesta)
                        {
                            case 0:
                                valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?0";
                                break;
                            case 1:
                                valorAlfanumerico = cEDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 2:
                                valorAlfanumerico = cEDL.oferta2x1Ejercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 3:
                                valorAlfanumerico = cEDL.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                                break;
                            case 4:
                                valorAlfanumerico = cEDL.oferta2DescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 6:
                                valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                                break;
                            case 7:
                                valorAlfanumerico = cEDL.compraSinOferta(2).ToString() + "?7?35";
                                break;
                            case 8:
                                valorAlfanumerico = cEDL.ofertaDescuentoEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 11:
                                valorAlfanumerico = cEDL.ofertaEjerciciosGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;

                        }

                        if (respuesta == 5)
                        {
                            cEDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        string[] dato = new string[2];
                        dato = valorAlfanumerico.Split('?');
                        bool? error = cEDL.permitirComprarEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
                        if (error == false)
                        {
                            // cartelito no tenes plata
                            return;
                        }

                        error = cEDL.compraEjercicioDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt32(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt32(dato[1]), Convert.ToInt32(dato[2]));

                        if (respuesta == 7)
                        {
                            cEDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        if (error == true)
                        {
                            // cartelito ejercicio comprado
                            return;
                        }
                        return;
                    }
                    break;

                case 2: // compro la explicacion del ejercicio                   
                   
                    bool? Valor_Explicacion = dME.analizarSiComproLaExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["Identificador"])); //resultado para saber si compro la explicacion o la tiene que mostrar
                    if (Valor_Explicacion == false) // muestra que la explicacion ya fue comprada solo necesita mostrarla 
                    {
                        Response.Redirect("RespuestaMisExplicaciones.aspx");
                        return;
                    }
                    if (Valor_Explicacion == true) // muesta la explicacion no comprada y pregunta si quiere comprarla 
                    {

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
                            case 12:
                                valorAlfanumerico = cEVDL.ofertaExplicacionGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;

                        }

                        if (respuesta == 5)
                        {
                            cEVDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        string[] dato = new string[2];
                        dato = valorAlfanumerico.Split('?');
                        bool? error = cEVDL.permitirComprarExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
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

                        return;
                    }

                    break;
                    
            }
        }

        

        #region Paginacion_Del_DataList
        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Ficha"] = 0; // arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Ficha"] = dPF.paginadoDataListFicha((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"]); //cantidad de datos al buscar por enunciados
            ViewState["Cantidad_De_Paginas_Ficha"] = (int)ViewState["Cantidad_De_Datos_Ficha"] / 5;//cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Ficha"] = (int)ViewState["Cantidad_De_Datos_Ficha"] % 5;// cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Ficha"] == 0)// si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Ficha"] = (int)ViewState["Cantidad_De_Paginas_Ficha"] - 1;// resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Ficha"] <= 5)// si cuento con menos de 10 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Ficha"] = (int)ViewState["Pagina_Ficha"] + 1;// se suma una hoja
            if ((int)ViewState["Pagina_Ficha"] == (int)ViewState["Cantidad_De_Paginas_Ficha"])// se fija si estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]);// llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]);//llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Ficha"] = (int)ViewState["Pagina_Ficha"] - 1; // se resta una hoja
            if ((int)ViewState["Pagina_Ficha"] == 0) // estoy en la primera hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]); // llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la primera pagina
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion
    }
}