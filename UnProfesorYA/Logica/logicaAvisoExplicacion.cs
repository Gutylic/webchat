using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Logica
{
    public class logicaAvisoExplicacion
    {
        public void avisoDeMensajeAlCorreo(string usuario)
        {
            MailMessage Mio = new MailMessage();

            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("PedidoOK@outlook.com"); // no recuerdo el mail donde llegan los pedidos
            Mio.Subject = "Un cliente necesita una explicacion de un ejercicio";
            Mio.Body = "El cliente: " + usuario + "¿pregunta como se resolvimos el ejercicio?";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }





    }
}
