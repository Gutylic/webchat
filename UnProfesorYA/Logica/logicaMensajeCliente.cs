using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Logica
{
    public class logicaMensajeCliente
    {
        
        public int erroresEnvioMensaje(string usuario, string correo, string repetirCorreo, string comentario)
        {
            if (usuario == string.Empty || correo == string.Empty || repetirCorreo == string.Empty || comentario == string.Empty)
            {
                return 1;
            }
            if (correo != repetirCorreo)
            {
                return 2;
            }
            if (comentario.Length < 8)
            {
                return 3;
            }
            return 4;
        }

        public string armadoComentario(string pais, string area, string telefono, string comentario) 
        { 
            return "El teléfono corresponde al: " + pais + " (" + area + ") " + telefono + " Comentario: " + comentario;
        }

        public void avisoDeMensajeAlCorreo(string usuario, string correo)
        {
            MailMessage Mio = new MailMessage();

            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com");
            Mio.Subject = "Registro por correo en aprobación";
            Mio.Body = "Se envio una consulta del cliente: " + usuario + " ,cuyo correo es " + correo;
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }


    }
}
