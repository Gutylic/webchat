using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class diseñoPaginaFicha
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? resultadoEjercicios;

        public int? paginadoDataListFicha(string profesor, string ano, string colegio, string materia, string tema)
        {
            db.resultadoDataListFichaPaginado(profesor, ano, colegio, materia, tema, ref resultadoEjercicios);
            return resultadoEjercicios;
        }

        public List<Tabla_Ejercicios> DataListFicha(string profesor, string ano, string colegio, string materia, string tema)
        {
            return db.resultadoDataListFicha(profesor, ano, colegio, materia, tema).ToList();
        }
    }
}
