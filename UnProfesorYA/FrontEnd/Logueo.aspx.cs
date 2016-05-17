using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using Logica;
using Datos;
using System.Web.Services;

namespace FrontEnd
{
    public partial class Logueo : System.Web.UI.Page
    {

        logicaRegistroUsuarios lRU = new logicaRegistroUsuarios();
        registroDeUsuarios rDU = new registroDeUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            FaceBookConnect.API_Key = "159457391122959";
            FaceBookConnect.API_Secret = "b4123743a8b0434c070b014af5b57a78";
            if (!IsPostBack)
            {
                iniciarSession(); 
                // registracion por medio del faceboook
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario con acceso denegado')", true);
                    return;
                }
                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);

                    if (lRU.existenciaUsuarioRegistrado(null, 2, null, faceBookUser.Id) == -1) // el numero 2 es la empresa lo registra desde el logueo solo con facebook pasa esto
                    {
                        int? id_Usuario = lRU.registroUsuarioFacebookCorreoCelular(string.Empty, string.Empty, string.Empty, 2, Request.UserHostAddress.ToString(), 0, faceBookUser.Id.ToString(), faceBookUser.Name.ToString(), 0); // el numero 2 es la empresa
                    }

                    Session["ID_Usuario"] = faceBookUser.Id;
                    Session["Name_Usuario"] = faceBookUser.Name;
                    Session["Variable_ID_Usuario"] = rDU.datosUsuarioLogueado(null, null, null, faceBookUser.Id, faceBookUser.Name).ID;
                    Response.Redirect("Ingreso.aspx");

                }

            }
            
        }
        
        public class FaceBookUser
        {
            // clase creada para facebook
            public string Id { get; set; }
            public string Name { get; set; }
        }

        protected void BtnFacebookLogin_Click(object sender, EventArgs e)
        {
            // boton de facebook
            FaceBookConnect.Authorize("public_profile,email", Request.Url.AbsoluteUri.Split('?')[0]);
        }
              

        public void iniciarSession()
        { 
            if (Request.Cookies["Usuario_Recordado"] != null) // cargar las coockies si es que existen y ya arranca logueado
            {
                
                Session["Name_Usuario"] = Request.Cookies["Usuario_Recordado"]["Usuario"]; // cargar la coockie como usuario   
                Session["ID_Usuario"] = Request.Cookies["Usuario_Recordado"]["Password"]; // cargar la coockie como password  
                
                try
                {
                
                   int UsuarioNumerico = Convert.ToInt32(Session["Name_Usuario"]); // analizar si es un numero o un correo
                    Session["Variable_ID_Usuario"] = rDU.datosUsuarioLogueado(null, Session["ID_Usuario"].ToString(), Session["Name_Usuario"].ToString(), null, null).ID;
                       
                }
                catch
                {

                    Session["Variable_ID_Usuario"] = rDU.datosUsuarioLogueado(Session["Name_Usuario"].ToString(),Session["ID_Usuario"].ToString(),null, null, null).ID;

                   
                }




                if (Convert.ToInt32(Session["Variable_ID_Usuario"]) != Convert.ToInt32(Request.Cookies["Usuario_Recordado"]["ID_Usuario"])) // error en la comprobacion de usuario y contraseña
                {
                    EliminarCookie(); // borra todo vestijio de cookie
                    Response.Redirect("Logueo.aspx"); // re arranca en el logueo
                }
                else
                {
                    
                    Response.Redirect("Ingreso.aspx"); // redirije la pantalla a ingreso                   
                }


               
            }
            else  // no hay cookie me trae a la pagina inicial
            {
                return;
            }
           
        }

 
        protected void BtnLogueo_Click(object sender, EventArgs e)
        {
            
            try
            {
                int UsuarioNumerico = int.Parse(TxtBoxUsuario.Text); // analizar si es un numero o un correo
                Session["Variable_ID_Usuario"] = rDU.datosUsuarioLogueado(null, TxtBoxPassword.Text, TxtBoxUsuario.Text, null, null).ID; // cargo el id del usuario registrado

                if (Convert.ToInt32(Session["Variable_ID_Usuario"]) == -1)
                {
                    // retorna sin loguearse
                    return;
                }

            }
            catch
            {

                Session["Variable_ID_Usuario"] = rDU.datosUsuarioLogueado(TxtBoxUsuario.Text, TxtBoxPassword.Text, null, null, null).ID;

                if (Convert.ToInt32(Session["Variable_ID_Usuario"]) == -1)
                {
                    // retorna sin loguearse
                    return;
                }
            }

            Session["ID_Usuario"] = TxtBoxPassword.Text;
            Session["Name_Usuario"] = TxtBoxUsuario.Text;


            if (CheckBoxMantenerSession.Checked)
            {
                GuardarCookie((string)Session["Name_Usuario"], (string)Session["ID_Usuario"], Convert.ToInt32(Session["Variable_ID_Usuario"]));

            }
            else
            {
                EliminarCookie();
            }

            Response.Redirect("Ingreso.aspx");
        }

        public void GuardarCookie(string Usuario, string Password, int ID)
        {

            HttpCookie VariableCookie = new HttpCookie("Usuario_Recordado");
            VariableCookie.Values.Add("Usuario", Usuario);
            VariableCookie.Values.Add("Password", Password);
            VariableCookie.Values.Add("ID_Usuario", ID.ToString());
            VariableCookie.Expires = DateTime.Now.AddDays(90);
            Response.Cookies.Add(VariableCookie);

        }

        public void EliminarCookie()
        {
            HttpCookie VariableCookie = new HttpCookie("Usuario_Recordado");
            VariableCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(VariableCookie);
        }

        [WebMethod()]
        public static void AbandonarSesion()
        {
            HttpContext.Current.Session.Remove("Variable_ID_Usuario");
            HttpContext.Current.Session.Remove("Usuario");
            HttpContext.Current.Session.Remove("Password");
        }



   }
}