using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panelSaldoDeUsuario
    {
        DataClassesDataContext db = new DataClassesDataContext();
        decimal? resultadoCredito;

        public List<consultaPanelMovimientoResult> mostrarMovimientosDelUsuario (int id_Usuario)
        {
            return db.consultaPanelMovimiento(id_Usuario).ToList();
        }

        public decimal? mostrarCreditoUsuario(int id_Usuario)
        {
            db.consultaCreditoUsuario(id_Usuario, ref resultadoCredito);
            return resultadoCredito;

        }



    }
}
