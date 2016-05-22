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
    public partial class MisEjercicios : System.Web.UI.Page
    {
        datosMisEjercicios dME = new datosMisEjercicios();
        compraEjerciciosDataList cEDL = new compraEjerciciosDataList();
        comprarExplicacionDataList cEVDL = new comprarExplicacionDataList();
        compraImpresionDataList cIDL = new compraImpresionDataList();
        logicaAvisoExplicacion lAE = new logicaAvisoExplicacion();

        string valorAlfanumerico;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                Condiciones_Paginacion();
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), 0); // datalist para cargar con el ID_Usuario y desde la pagina cero

            }

            //if (Request.Params["__EVENTARGUMENT"] == "metodo1")
            //{
            //    metodo1();
            //}
            //if (Request.Params["__EVENTARGUMENT"] == "metodo2")
            //{
            //    metodo2();
            //}
            //if (Request.Params["__EVENTARGUMENT"] == "")
            //{
            //    return;
            //}
        }


        #region Metodo_Extra_Para_Cambiar_El_Texto_Del_Boton_Del_Datalist_Para_Ejercicio
        public string Etiqueta_Ejercicio(int Valor)
        { // boton ejercicio
            string Boton = "";
            switch (Valor)
            {
                case 1:
                    Boton = "Ver Ejercicio"; // escribir ver ejercicio
                    break;
                case 0:
                    Boton = "Comprar Ejercicio"; // escribir comprar el ejercicio
                    break;
            }
            return Boton;
        }

        #endregion


        #region Metodo_Extra_Para_Cambiar_El_Testo_Del_Boton_Del_DataList_Para_Explicacion
        public string Etiqueta_Explicacion(int Valor) //etiqueta explicacion del datalist
        {
            string Boton = "";
            switch (Valor)
            {
                case 1:
                    Boton = "Ver Explicación"; // cambiar la explicacion por ver explicacion
                    break;
                case 0:
                    Boton = "Comprar Explicion"; // cambiar la explicacion por comprar la explicacion
                    break;
            }
            return Boton;
        }

        #endregion


        #region DataList

        protected void Identificador(object sender, DataListCommandEventArgs e)
        {
            Session["Identificador"] = int.Parse(e.CommandName); // identificador para saber que linkbutton presione 
            int Boton_Presionado = int.Parse(e.CommandArgument.ToString()); // identificador para determinar que boton se presiono
            switch (Boton_Presionado)
            {
                case 1:// boton de ejercicio
                    bool? Valor_Ejercicio = dME.analizarSiComproElEjercicio(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["Identificador"])); //resultado para saber si compro el ejercicio o lo tengo que mostrar
                    if (Valor_Ejercicio == false) //muestra el ejercicio que ya fue comprado solo necesita mostrarlos pues lo compro en el datalist inicial
                    {
                        Response.Redirect("RespuestaMisEjercicios.aspx");
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

                case 2: //boton explicacionesComprar Explic.
                    Session["Identificador"] = int.Parse(e.CommandName); // identificador para saber que linkbutton presione 
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

                case 3: // boton para imprimir el ejercicio

                    Session["Identificador"] = int.Parse(e.CommandName); // identificador para saber que linkbutton presione 
                    int? respuestaImpresion = cIDL.activacionOfertas(2); // el 2 es la empresa

                        switch (respuestaImpresion)
                        {
                            case 0:
                                valorAlfanumerico = cIDL.compraSinOferta(2).ToString() + "?7?0";
                                break;
                            case 1:
                                valorAlfanumerico = cIDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 2:
                                valorAlfanumerico = cIDL.oferta2x1Impresion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 3:
                                valorAlfanumerico = cIDL.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                                break;
                            case 4:
                                valorAlfanumerico = cIDL.oferta2DescuentoImpresion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 6:
                                valorAlfanumerico = cIDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                                break;
                            case 7:
                                valorAlfanumerico = cIDL.compraSinOferta(2).ToString() + "?7?35";
                                break;
                            case 8:
                                valorAlfanumerico = cIDL.ofertaDescuentoImpresion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 9:
                                valorAlfanumerico = cIDL.ofertaImpresionGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                        }

                        if (respuestaImpresion == 5)
                        {
                            cIDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        string[] datos = new string[2];
                        datos = valorAlfanumerico.Split('?');
                        bool? errores = cIDL.permitirComprarImpresion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(datos[0].Replace(".", ",")));
                        if (errores == false)
                        {
                            // cartelito no tenes plata
                            return;
                        }

                        errores = cIDL.compraImpresionesDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt32(Session["ID_Ejercicio"]), Convert.ToDecimal(datos[0].Replace(".", ",")), 2, Convert.ToInt32(datos[1]), Convert.ToInt32(datos[2]));

                        if (respuestaImpresion == 7)
                        {
                            cIDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        if (errores == true)
                        {
                            // cartelito ejercicio comprado

                        Response.Clear();
                        Response.ContentType = "image/png";

                        Response.AppendHeader("Content-Disposition", "attachment; filename=Ejercicio" + DateTime.Now + ".png"); // con este nombre se descarga


                        Response.TransmitFile("C:\\impresion/" + cIDL.ubicarArchivoImpresion(Convert.ToInt16(Session["Identificador"])) + ".png");
                        Response.End();


                            return;
                        }
                        return;


//                      este codigo que esta abajo sirve para imprimir pero tiene el problema que no funciona en el servidor
//                      string txtFileName = "c:impresion/e.doc"; // ubicacion del archivo para imprimir
//                      ProcessStartInfo info = new ProcessStartInfo(txtFileName); // script para imprimir el archivo de resolucion del ejercicio
//                      info.Verb = "Print";
//                      info.CreateNoWindow = true;
//                      info.WindowStyle = ProcessWindowStyle.Hidden;
//                      Process.Start(info);
//                      return;
                    

                        break;
            }
        }
        
        public void Resultado_DataList_Mis_Ejercicios(int ID_Usuario, int Pagina)
        {
            DataList_Mis_Ejercicios.DataSource = (dME.resultadoDatosMisEjercicios(ID_Usuario)).Skip(Pagina * 8).Take(8); // muestra el datalist de mis ejercicios paginado de a 20 datos
            DataList_Mis_Ejercicios.DataBind();
        }
        #endregion


        #region Paginacion_Del_DataList

        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Mis_Ejercicios"] = 0;// arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Mis_Ejercicios"] = dME.resultadoDatosMisEjerciciosPaginados(Convert.ToInt32(Session["Variable_ID_Usuario"]));//cantidad de datos al buscar en mis ejercicios
            ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] / 8;//cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] % 8;// cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Mis_Ejercicios"] == 0)// si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] - 1;// resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] <= 8)// si cuento con menos de 20 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Ejercicios"] = (int)ViewState["Pagina_Mis_Ejercicios"] + 1;// se suma una hoja
            if ((int)ViewState["Pagina_Mis_Ejercicios"] == (int)ViewState["Cantidad_De_Paginas_Mis_Ejercicios"])// se fija si estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]);// llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]);// llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Ejercicios"] = (int)ViewState["Pagina_Mis_Ejercicios"] - 1;// se resta una hoja
            if ((int)ViewState["Pagina_Mis_Ejercicios"] == 0)// estoy en la primera hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]); // llama al datalist               
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la primera pagina
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion






    }
}