using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using Logica;

namespace FrontEnd
{
    public partial class Registro : System.Web.UI.Page
    {
        logicaRegistroUsuarios lRU = new logicaRegistroUsuarios();
        int error;

        protected void Page_Load(object sender, EventArgs e)
        {
            generarRegistro(); // cargando el captcha en la pagina de registro
            FaceBookConnect.API_Key = "159457391122959";
            FaceBookConnect.API_Secret = "b4123743a8b0434c070b014af5b57a78";
            if (!IsPostBack)
            {
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
                    // ver si el usuario de facebook ya esta registrado
                    if (lRU.existenciaUsuarioRegistrado(null, 2, null, faceBookUser.Id) != -1) // el numero 2 es la empresa
                    {
                        // usuario existe
                        return;
                    }    
                        
                    int? id_Usuario = lRU.registroUsuarioFacebookCorreoCelular(string.Empty, string.Empty, string.Empty, 2, Request.UserHostAddress.ToString(), 0, faceBookUser.Id.ToString(), faceBookUser.Name.ToString(), 0); // el numero 2 es la empresa
                                           
                    if (id_Usuario != -6)
                    { 
                        // ver si tiene oferta por registrarse
                        bool? oferta = lRU.ofertaPorRegistro(Convert.ToInt16(id_Usuario), 2); // el numero 2 es la empresa

                        if (oferta == true)
                        { 
                            // cartelito que avisa que se registro y le regalo plata                        
                        }
                        
                            // cartelito de mensaje de registro exitoso
                        BtnFacebook.Enabled = false;
                        return;
                    }
                    

                    // mensaje de registro erroneo
                }
            }
        }

        public class FaceBookUser
        { 
            // clase creada para facebook
            public string Id { get; set; }
            public string Name { get; set; }
        }


        protected void BtnFacebook_Click(object sender, EventArgs e)
        {
            // boton de facebook
            FaceBookConnect.Authorize("public_profile,email", Request.Url.AbsoluteUri.Split('?')[0]);
        }

        public class CaptchaRegistro
        {
            // clase creada para la generacion del captcha
            public int imagenCaptcha { get; set; }
            public string valorCaptcha { get; set; }
        }

        public CaptchaRegistro generarRegistro()
        {
            CaptchaRegistro datosCaptcha = new CaptchaRegistro();
            Random r = new Random(); 
            string[] valorImagen = new string[6] { "2M8I", "H37C", "P56H", "9JH2", "KN9Y", "559P" }; // imagenes del captcha
            datosCaptcha.imagenCaptcha = r.Next(1, 7); // elegir una de las imagenes
            ViewState["imagenCaptcha"] = datosCaptcha.imagenCaptcha; 
            datosCaptcha.valorCaptcha = valorImagen[datosCaptcha.imagenCaptcha - 1]; // elegir el contenido del capcha 
            ViewState["valorCaptcha"] = datosCaptcha.valorCaptcha;
            ImagenCaptcha.ImageUrl = "captcha/" + ViewState["imagenCaptcha"].ToString() + ".png"; // cargar la imagen del captcha en la pagina
            return datosCaptcha;        
        }
        
        protected void BtnEnviarCorreo_Click(object sender, EventArgs e)
        {
            // captura del error correo diferente
            error = lRU.errorDeComprobación(TxtBoxCorreo.Text, TxtBoxComprobarCorreo.Text);
            
            // captura del error de contraseña diferente
            error = lRU.errorDeComprobación(TxtBoxContrasenaCorreo.Text, TxtBoxComprobarContrasenaCorreo.Text);

            // captura del error del captcha diferente
            error = lRU.errorDeComprobación(TxtBoxCaptcha.Text.ToUpper(), (string)ViewState["valorCaptcha"]);

            // ver si el usuario de facebook ya esta registrado
            if (lRU.existenciaUsuarioRegistrado(TxtBoxCorreo.Text, 2, null, null) != -1) // el numero 2 es la empresa
            {
                // cartel que dice que no puedo registrarme
                return;
            }

            error = lRU.errorFormularioRegistroCorreo(TxtBoxCorreo.Text, TxtBoxComprobarCorreo.Text, TxtBoxContrasenaCorreo.Text, TxtBoxComprobarContrasenaCorreo.Text, TxtBoxCaptcha.Text, ChckBoxCondicionesCorreo.Checked);
            switch (error)
            {
                case -1:
                    // poner cartelito vacio
                    break;
                case -2:
                    // poner cartelito formato correo erroneo
                    break;
                case -3:
                    // poner cartelito password excedido
                    break; 
                case -4:
                    // poner cartelito condiciones no aceptadas
                    break;
            }               

            int? id_Usuario = lRU.registroUsuarioFacebookCorreoCelular(TxtBoxContrasenaCorreo.Text, TxtBoxCorreo.Text, string.Empty, 2, Request.UserHostAddress.ToString(), 0, null, null,0); // el numero 2 es la empresa
            if (id_Usuario != -6)
            {
                // ver si tiene oferta por registrarse
                bool? oferta = lRU.ofertaPorRegistro(Convert.ToInt16(id_Usuario) + 1, 2); // el numero 2 es la empresa

                if (oferta == true)
                {
                    // cartelito que avisa que se registro y le regalo plata                        
                }

                error = lRU.envioCorreoActivacion(TxtBoxCorreo.Text, TxtBoxContrasenaCorreo.Text);
                if(error == 1)
                {
                     // cartelito de mensaje de registro exitoso con envio al mail
                }
               
                return;
            }
            // mensaje de registro erroneo


        }

        protected void BtnEnviarCelular_Click(object sender, EventArgs e)
        {

            // corregir el numero de celular
            int celularCorregido = lRU.correccionTelefono(int.Parse(DropDownListPais.SelectedValue), TxtArea.Text, TxtBoxCelular.Text);
            if (celularCorregido == -1)
            { 
                // error en la formacion del telefono
                return;
            }
            
            // captura del error de contraseña diferente
            error = lRU.errorDeComprobación(TxtBoxContrasenaCelular.Text, TxtBoxComprobarContrasenaCelular.Text);

            // ver si el usuario de facebook ya esta registrado
            if (lRU.existenciaUsuarioRegistrado(null, 2, celularCorregido.ToString(), null) != -1) // el numero 2 es la empresa
            {
                // cartel que dice que no puedo registrarme
                return;
            }

            error = lRU.errorFormularioRegistroCelular(TxtArea.Text, celularCorregido.ToString(),TxtBoxContrasenaCelular.Text, TxtBoxComprobarContrasenaCorreo.Text, ChckBoxCondicionesCorreo.Checked);
            switch (error)
            {
                case -1:
                    // poner cartelito vacio
                    break;                
                case -2:
                    // poner cartelito password excedido
                    break;
                case -3:
                    // poner cartelito condiciones no aceptadas
                    break;
            }       
            
            Random r = new Random();
            int codigoActivacion = r.Next(100000, 999999);
            
            int? id_Usuario = lRU.registroUsuarioFacebookCorreoCelular(TxtBoxContrasenaCelular.Text, string.Empty, celularCorregido.ToString(), 2, Request.UserHostAddress.ToString(), codigoActivacion, null, null,int.Parse(DropDownListPais.SelectedValue)); // el numero 2 es la empresa
            if (id_Usuario != -6)
            {
                // ver si tiene oferta por registrarse
                bool? oferta = lRU.ofertaPorRegistro(Convert.ToInt16(id_Usuario) + 1, 2); // el numero 2 es la empresa

                if (oferta == true)
                {
                    lRU.envioActivacionCelular(celularCorregido.ToString(), codigoActivacion, TxtArea.Text, int.Parse(DropDownListPais.SelectedValue));
                    Session["ID_Usuario"] = celularCorregido.ToString();

                }

                Response.Redirect("ActivacionCelular.aspx");


                return;
            }
            // mensaje de registro erroneo
        
        }

        protected void LinkBtnReenvio_Click(object sender, EventArgs e)
        {
            error = lRU.errorReenvioFormularioRegistroCorreo(TxtBoxCorreo.Text);
            switch (error)
            {
                case -1:
                    // poner cartelito vacio
                    break;
                case -2:
                    // poner cartelito formato correo erroneo
                    break;                
            }

            error = lRU.envioCorreoReActivacion(TxtBoxCorreo.Text);
            if(error == 1)
            {
                // cartelito de mensaje de registro exitoso con envio al mail
            }
         
        }
                
    }
}