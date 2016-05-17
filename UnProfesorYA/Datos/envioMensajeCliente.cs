using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class envioMensajeCliente
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? resultadoMensaje;


        public int? comentarioMensajeCliente(string cliente, string correo,string empresa, string pregunta)
        {
            db.mensajeCliente(cliente, correo, empresa, pregunta, ref resultadoMensaje);
            return resultadoMensaje;
        }


    }
}
