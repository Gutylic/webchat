using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class diseñoPaginaEnunciado
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? resultadoEjercicios;

        public int? paginadoDataListEnunciado(string enunciado1, string enunciado2)
        {
            db.resultadoDatalistTitulosEjercicioEjerciciosPaginado(enunciado1, enunciado2, ref resultadoEjercicios);
            return resultadoEjercicios;
        }

        public List<Tabla_EnunciadoEjercicios> DataListEnunciado(string enunciado1, string enunciado2)
        {
            return db.resultadoDatalistTitulosEjercicioEjercicios(enunciado1, enunciado2).ToList();
        }


    }
}
