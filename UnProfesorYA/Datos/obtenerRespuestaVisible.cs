using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class obtenerRespuestaVisible
    {
        DataClassesDataContext db = new DataClassesDataContext();
        string respuestaEjercicio;

        public string recuperarUbicacionEjercicio(int id_Ejercicio)
        {
            db.mostrarEnunciadoVisible(id_Ejercicio, ref respuestaEjercicio);
            return respuestaEjercicio;
        }

        public string recuperarUbicacionExplicacion(int id_Ejercicio)
        {
            db.mostrarRespuestaVideo(id_Ejercicio, ref respuestaEjercicio);
            return respuestaEjercicio;
        
        }
    }
}
