using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class datosMisExplicaciones
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<resultadoMisExplicaiconesResult> resultadoDatosMisExplicaciones(int id_Usuario)
        {
            return db.resultadoMisExplicaicones(id_Usuario).ToList();
        }

        public int? resultadoDatosMisExplicacionesPaginados(int id_Usuario)
        {
            db.resultadoMisExplicacionesPaginado(id_Usuario, ref cantidad);
            return cantidad;
        }
    }
}
