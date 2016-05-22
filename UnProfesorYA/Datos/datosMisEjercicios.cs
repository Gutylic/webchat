using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class datosMisEjercicios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;
        bool? respuestaCompra;

        public List<Vista_MostrarListadoMisEjercicios> resultadoDatosMisEjercicios(int id_Usuario)
        {
            return db.resultadoMisEjercicios(id_Usuario).ToList();
        }

        public int? resultadoDatosMisEjerciciosPaginados(int id_Usuario)
        {
            db.resultadoMisEjerciciosPaginado(id_Usuario, ref cantidad);
            return cantidad;
        }

        public bool? analizarSiComproElEjercicio(int id_Usuario, int id_Ejercicio)
        {
            db.evitarRecompraEjercicio1(id_Usuario, id_Ejercicio, ref respuestaCompra);
            return respuestaCompra;
        }

        public bool? analizarSiComproLaExplicacion(int id_Usuario, int id_Ejercicio)
        {
            db.evitarRecompraExplicacion1(id_Usuario, id_Ejercicio, ref respuestaCompra);
            return respuestaCompra;
        }

    }
}
