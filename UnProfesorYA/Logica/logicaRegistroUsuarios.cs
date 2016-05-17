using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Logica
{
    public class logicaRegistroUsuarios
    {
        registroDeUsuarios rDU = new registroDeUsuarios();         
        bool? resultadoExito;
        int? resultadoUsuario;
        string resultadoName;
        string contrasena;

        public class Logueado
        {
            public int? ID { get; set; }
            public string Name { get; set; }
        }



        public Logueado logueoUsuarioFacebookCorreoCelular(string correo, string password, string telefono, string id_facebook, string nameFacebook)
        {
            Logueado Dato = new Logueado(); 
            resultadoUsuario = rDU.datosUsuarioLogueado(correo, password, telefono, id_facebook, nameFacebook).ID;
            resultadoName = rDU.datosUsuarioLogueado(correo,password,telefono, id_facebook, nameFacebook).Name;
            return Dato;
        }

        public int errorDeComprobación(string valor1, string valor2)
        { 
            // captura los errores de correo diferentes, captcha, pasword
            if (valor1 != valor2)
            {
                return -1; // error en las comparaciones
            }
            return 1; // comparaciones correctas
        }

        public int? registroUsuarioFacebookCorreoCelular(string password, string correo, string telefono, int empresa, string ipAddress, int codigo, string id_Facebook, string nameFacebook, int pais)
        {
            resultadoUsuario = rDU.datosUsuarioRegistrado(password, correo, telefono, empresa, ipAddress, codigo, id_Facebook, nameFacebook,pais);
            return resultadoUsuario;
        }

        public bool? ofertaPorRegistro(int id_Usuario, int empresa)
        {
            resultadoExito = rDU.datosOfertaRegistro(id_Usuario, empresa);
            return resultadoExito;
        }

        public int? existenciaUsuarioRegistrado(string correo, int empresa, string telefono, string facebook)
        {
            resultadoUsuario = rDU.datosUsuarioExiste(correo, empresa, telefono, facebook);
            return resultadoUsuario;
        }

        public int errorReenvioFormularioRegistroCorreo(string correo)
        {
            if (correo == string.Empty)
            {
                return -1;
            }

            if (correo.IndexOf("@", 0) == -1 || correo.IndexOf(".", 0) == -1)
            {
                return -2;
            }

            return 1;
        }
        
        public int errorFormularioRegistroCorreo(string correo, string comprobacionCorreo, string password, string comprobacionPassword, string captcha, bool condiciones)
        {
            if (correo == string.Empty || comprobacionCorreo == string.Empty || password == string.Empty || comprobacionPassword == string.Empty || captcha == string.Empty)
            {
                return -1;
            }

            if (correo.IndexOf("@", 0) == -1 || correo.IndexOf(".", 0) == -1)
            {
                return -2;
            }

            if (password.Length <= 5 || password.Length > 10)
            {
                return -3;
            }

            if (condiciones == false)
            {
                return -4;
            }

            return 1;

        }

        public int envioCorreoActivacion (string correo, string password)
        {
            MailMessage Email = new MailMessage();
            Email.From = new MailAddress("Correodelosprofesores@gmail.com"); // otro cambio si modifico el correo
            Email.To.Add(correo);
            Email.Subject = "Activación de la cuenta";
            string Body = HttpContent("http://www.unprofesorya.com/Correo_Activacion.aspx"); // recordar que debo cambiarla
            string Body1 = Body.Replace("NICKUSUARIO", correo);
            string Body2 = Body1.Replace("CONTRASENA", password);
            Email.IsBodyHtml = true;                        
            MailMessage Mio = new MailMessage();

            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com");
            Mio.Subject = "Registro en Aprobacion";
            Mio.Body = "Se registro el usuario con el correo: " + correo + " pero aun no activo";
            Mio.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");                      
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(Mio);
                try
                {
                    smtp.Send(Email);
                    return 1; // todo OK                                
                }
                catch (Exception)
                {
                    return -6; // no conectado                            
                }
            }
            catch (Exception)
            {
                try
                {
                    smtp.Send(Email);
                    return 1; // todo OK                                
                }
                catch (Exception)
                {
                    return -6; // no conectado                            
                }
            }
    
        }

        public int envioCorreoReActivacion(string correo)
        {
            MailMessage Email = new MailMessage();
            Email.From = new MailAddress("Correodelosprofesores@gmail.com"); // otro cambio si modifico el correo
            Email.To.Add(correo);
            Email.Subject = "Activación de la cuenta";
            string Body = HttpContent("http://www.unprofesorya.com/Correo_Activacion.aspx"); // recordar que debo cambiarla
            string Body1 = Body.Replace("NICKUSUARIO", correo);
            string Body2 = Body1.Replace("CONTRASENA", "Ingreso123");
            Email.IsBodyHtml = true;
            MailMessage Mio = new MailMessage();

            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com");
            Mio.Subject = "Registro por correo en aprobación";
            Mio.Body = "Se registro el usuario con el correo: " + correo + " pero aun no activo";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(Mio);
                try
                {
                    smtp.Send(Email);
                    return 1; // todo OK                                
                }
                catch (Exception)
                {
                    return -6; // no conectado                            
                }
            }
            catch (Exception)
            {
                try
                {
                    smtp.Send(Email);
                    return 1; // todo OK                                
                }
                catch (Exception)
                {
                    return -6; // no conectado                            
                }
            }

        }

        public string HttpContent(string URL) // cargar toda la pagina web para enviar por mail
        {
            WebRequest objRequest = HttpWebRequest.Create(URL);
            StreamReader reader = new StreamReader(objRequest.GetResponse().GetResponseStream());
            string Result = reader.ReadToEnd();
            return Result;
        }

        public int errorFormularioRegistroCelular(string area, string celular, string password, string comprobacionPassword, bool condiciones)
        {
            if (area == string.Empty || celular == string.Empty || password == string.Empty || comprobacionPassword == string.Empty)
            {
                return -1;
            }

            if (password.Length <= 5 || password.Length > 10)
            {
                return -2;
            }

            if (condiciones == false)
            {
                return -3;
            }

            return 1;

        }

        public int correccionTelefono(int pais, string codigoArea, string celular)
        {
            if (pais == 1)
            {
                string celularCorregido = (celular.Replace(" ", ""));
                celularCorregido = codigoArea + celularCorregido.Replace("-", "");
                int cantidadNumeros = celularCorregido.Length;
                if (cantidadNumeros != 10)
                {
                    return -1;
                }
                
                return int.Parse(celularCorregido);

            }

            return -1;

        }

        public int recuperarContrasenaCorreo(string correo, int empresa)
        {
            string correoContrasena = rDU.datosUsuarioContrasenaCorreo(correo, empresa);
            

            MailMessage Email = new MailMessage();
            Email.From = new MailAddress("Correodelosprofesores@gmail.com"); // otro cambio si modifico el correo
            Email.To.Add(correo);
            Email.Subject = "Activación de la cuenta";
            string Body = HttpContent("http://www.unprofesorya.com/Correo_Activacion.aspx"); // recordar que debo cambiarla
            string Body1 = Body.Replace("NICKUSUARIO", correo);
            string Body2 = Body1.Replace("CONTRASENA", correoContrasena);
            Email.IsBodyHtml = true;            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(Email);
                return 1; // todo OK                                
            }
            catch (Exception)
            {
                return -6; // no conectado                            
            }
          

        }

        public int recuperarContrasenaCelular(string celular, int empresa)
        {
            string correoContrasena = rDU.datosUsuarioContrasenaCelular(celular, empresa);

            string url = "http://servicio.smsmasivos.com.ar/enviar_sms.asp?api=1&relogin=1&usuario=SMSDEMO70164&clave=SMSDEMO70164757&tos=" + celular + "&idinterno=&texto=su contrasena en unProfesorYa es: " + correoContrasena + " es tu código de verificación de UnProfesorYa";

            return 1; 
        }

        public int envioActivacionCelular(string celular, int codigo, string codigoArea, int pais)
        {
                            
            string url = "http://servicio.smsmasivos.com.ar/enviar_sms.asp?api=1&relogin=1&usuario=SMSDEMO70164&clave=SMSDEMO70164757&tos=" + celular + "&idinterno=&texto=P- " + codigo.ToString() + " es tu código de verificación de UnProfesorYa";
            
           
            
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com");
            Mio.Subject = "Registro por celular en aprobación";
            Mio.Body = "Se registro el usuario del pais: " + pais + " con el celular: (" + codigoArea + ") " + celular + " pero aun no activo";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);
            return 1;
                             
        }

        

    }
}
