using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using Datos;

namespace FrontEnd
{
    public partial class ActivacionCorreo : System.Web.UI.Page
    {

        registroDeUsuarios rDU = new registroDeUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Usuario = Request.QueryString["ID_Nombre"]; // captura la llamada del mail            
            rDU.datosUsuarioActivacionCorreo(Usuario, 2);
        }

        protected void ActivacionUsuario_Click(object sender, EventArgs e)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com");
            Mio.To.Add("ActivacionOK@outlook.com");
            Mio.Subject = "Activacion OK";
            Mio.Body = "Se Activo el usuario: " + (Request.QueryString["ID_Nombre"]).ToString() + "por correo correctamente";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;


            try
            {
                smtp.Send(Mio);
                Response.Redirect("Logueo.aspx");

            }
            catch (Exception)
            {
                Response.Redirect("Logueo.aspx");

            }
        }

    

        
    }
}