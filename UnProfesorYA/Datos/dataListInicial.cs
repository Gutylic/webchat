using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dataListInicial
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<Tabla_Ejercicios> cargaListadoInicialEjercicios()
        {
            return db.resultadoDatalistTitulosEjercicioCompleta().ToList();
        }

        public int? cargaListadoInicialEjerciciosPaginado()
        {
            db.resultadoDatalistTitulosEjercicioCompletaPaginado(ref cantidad);
            return cantidad;
        }

        public List<Tabla_Ejercicios> cargaListadoInicialEjerciciosBusquedas(string profesor, string colegio, string ano, string materia, string tema)
        {
            return db.resultadoDatalistTitulosEjercicioBusqueda(profesor, ano, colegio, materia, tema).ToList();
        }

        public int? cargaListadoInicialEjerciciosBusquedaPaginado(string profesor, string colegio, string ano, string materia, string tema)
        {
            db.resultadoDatalistTitulosEjercicioBusquedaPaginado(profesor, ano, colegio, materia, tema, ref cantidad);
            return cantidad;
        }


    }
}
