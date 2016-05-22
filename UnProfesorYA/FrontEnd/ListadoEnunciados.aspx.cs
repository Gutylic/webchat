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
    public partial class ListadoEnunciados : System.Web.UI.Page
    {

        dataListInicial dLI = new dataListInicial();
        logicaErroresBusqueda lEB = new logicaErroresBusqueda();
        dataListInicialBusqueda dLIB = new dataListInicialBusqueda();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                armadoDePaginacion(true);
                resultadoDataListInicial(0);                
            }
            
        }


        #region DataList

        public void resultadoDataListInicial(int Pagina) // DataList Inicial recibe como parametro la pagina
        {
            ViewState["Momento"] = true; // variable de estado para avisarme que estoy con el resultado del datalist de inicio
            DataList_De_Resultados.DataSource = dLI.cargaListadoInicialEjercicios().Skip(Pagina * 20).Take(20); // paginado cada 20 hojas
            DataList_De_Resultados.DataBind();
        }

        public void resultadoDataListInicialBusqueda(string ano, string profesor, string tema, string colegio, string materia, int pagina) //DataList de Busqueda recibe como parametros los datos de busqueda y la pagina
        {
            ViewState["Momento"] = false; // varuable de estado para avisarme que estoy con el resultado del datalist de busqueda
            DataList_De_Resultados.DataSource = dLI.cargaListadoInicialEjerciciosBusquedas(profesor, colegio, ano, materia, tema).Skip(pagina * 20).Take(20); // paginado cada 20 hojas
            DataList_De_Resultados.DataBind();
        }

        protected void logosAsociados(object sender, DataListItemEventArgs e) // posisiona los logitos al costado de las respuestas del datalist
        {
            Tabla_Ejercicios logoDataList = new Tabla_Ejercicios();           
            logoDataList = (Tabla_Ejercicios)e.Item.DataItem;            
            
            System.Web.UI.WebControls.Image Logo = new System.Web.UI.WebControls.Image(); // genero una variable del tipo imagen para cambiar al vuelo la misma
            Logo = (System.Web.UI.WebControls.Image)e.Item.FindControl("Imagen_Logos"); // la imagen se cambiara donde se encuentre el ID = Imagen_Logos

            switch (logoDataList.id_TipoEjercicio) // determino que de todos las columnas de la tabla de ejercicio solo me interesa ID_Tipo_De_Ejercicio
            {
                case 1: // ejercicio
                    Logo.ImageUrl = "imagen/logo_ejercicios.png";
                    Logo.ToolTip = "Vea el Ejercicio";
                    break;
                case 2: // explicacion
                    Logo.ImageUrl = "imagen/logo_ejercicios_filmados.png";
                    Logo.ToolTip = "Vea el Ejercicio Explicado";
                    break;
                case 3: // video
                    Logo.ImageUrl = "imagen/logo_videos.png";
                    Logo.ToolTip = "Vea el Videos";
                    break;
                case 4: // pack de videos
                    Logo.ImageUrl = "imagen/logo_pack_videos.png";
                    Logo.ToolTip = "Conjunto de Videos";
                    break;
            }

        }

        protected void Identificador(object sender, DataListCommandEventArgs e) // convierto al datalist en editable 
        {
            if (Session["Variable_ID_Usuario"] == null) // comportamiento del datalist si no estas logueado
            {
                // cartelito de error avisa que debe encontrarse logueado
                return;
            }
            Session["ID_Ejercicio"] = e.CommandName; // capturo en la variable de session el Identificador del ejercicio a mostrar al clickear encima del linkButton
            Response.Redirect("Enunciado.aspx");
        }

        #endregion

        #region Paginado_Del_DataList

        public void armadoDePaginacion(bool Momento) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centros_Paginados.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Ultimo.Visible = false; // anterior de la ultima pagina

            if (Momento) // cuenta cuantos datos hay en la busqueda segun el momento
            {
                ViewState["Cantidad_De_Datos"] = dLI.cargaListadoInicialEjerciciosPaginado(); //cantidad de datos en el momento inicial
            }
            else
            {
                ViewState["Cantidad_De_Datos"] = dLI.cargaListadoInicialEjerciciosBusquedaPaginado( (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"]); // momento buscado
            }

            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Primero.Visible = false;
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                if ((bool)ViewState["Momento"]) // esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    resultadoDataListInicial((int)ViewState["Pagina"]); // datalist inicial
                }
                else
                {
                    resultadoDataListInicialBusqueda((string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]); // datalist de busqueda
                }
                Centros_Paginados.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremos_Paginados.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    resultadoDataListInicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    resultadoDataListInicialBusqueda((string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"],(string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda
                }
                Centros_Paginados.Visible = true; // estoy en las paginas del centro
                Extremos_Paginados.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda                
                {
                    resultadoDataListInicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    resultadoDataListInicialBusqueda((string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"],(string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda

                }
                Centros_Paginados.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremos_Paginados.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    resultadoDataListInicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    resultadoDataListInicialBusqueda((string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"],(string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda

                }
                Centros_Paginados.Visible = true; // estoy en las paginas del centro
                Extremos_Paginados.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        protected void BtnBuqueda_Click(object sender, EventArgs e) // boton de busqueda de ejercicios
        {
            int error = lEB.busquedaDatosVacios(TxtBoxProfesor.Text,TxtBoxAño.Text,TxtBoxTema.Text,TxtBoxColegio.Text, TxtBoxMateria.Text); // error por cargar todos valores vacios
            
            if (error == -1) // no cargue nada en todos los textbox del panel de busqueda
            {
               // cartelito optativo diciendo usted no puso nada en la busqueda recibira mas de 155555 ejercicios posibles
               armadoDePaginacion(true); // lo trabaja como si fuera la primera vez que abro la pagina al datalist
               resultadoDataListInicial(0);
               return;
            }

            ViewState["Etiqueta_Profesor"] =dLIB.Metodo_Buscar_Profesor(lEB.corregirEtiquetas(TxtBoxProfesor.Text)); // cargo en una variable de usuario el profesor
            ViewState["Etiqueta_Ano"] = dLIB.Metodo_Buscar_Ano(lEB.corregirEtiquetas(TxtBoxAño.Text)); // cargo en una variable de usuario el año
            ViewState["Etiqueta_Tema"] = dLIB.Metodo_Buscar_Tema(lEB.corregirEtiquetas(TxtBoxTema.Text)); // cargo en una variable de usuario el tema
            ViewState["Etiqueta_Colegio"] = dLIB.Metodo_Buscar_Colegio(lEB.corregirEtiquetas(TxtBoxColegio.Text)); // cargo en una variable de usuario el colegio
            ViewState["Etiqueta_Materia"] = dLIB.Metodo_Buscar_Materia(lEB.corregirEtiquetas(TxtBoxMateria.Text)); // cargo en una variable de usuario la materia

            TxtBoxProfesor.Text = string.Empty; // vaciar la caja de busqueda luego de realizar
            TxtBoxAño.Text = string.Empty;
            TxtBoxColegio.Text = string.Empty;
            TxtBoxMateria.Text = string.Empty;
            TxtBoxTema.Text = string.Empty;
            
            // ejecuta el datalist con la busqueda de la ficha
            armadoDePaginacion(false); // condiciones para el paginado adaptado al momento de la busqueda por eso es fales
            resultadoDataListInicialBusqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], 0); // muestra las respuestas en el datalist de busqueda desde la pagina cero        
        }        
    }
}