using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class botonesListado
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? tipoEjercicio;

        public int? determinarCantidadDeBotones(int id_Ejercicio)
        {
            db.determinarEjercicioOVideo(id_Ejercicio, ref tipoEjercicio);            
            return tipoEjercicio;
        }


    }
}
