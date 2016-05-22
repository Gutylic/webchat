using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class compraImpresionDataList
    {
        DataClassesDataContext db = new DataClassesDataContext();
        bool? respuestaLogico;
        string respuestaAlfanumerica;
        int? respuestaNumerica;
        decimal? respuestaPrecio;

        public int? activacionOfertas(int empresa)
        {
            db.ofertaActivada(empresa, ref respuestaNumerica);
            return respuestaNumerica;
        }

        public string oferta2x1(int id_Usuario, int empresa)
        {
            db.ofertaDosXUno2(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2x1Impresion(int id_Usuario, int empresa)
        {
            db.ofertaDosXUnoIgualProductoImpresion3(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaGratis(int id_Usuario)
        {
            db.ofertaGratis4(id_Usuario, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2DescuentoImpresion(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoSegundoProductoImpresion5(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public int? ofertaHabitue(int id_Usuario, int empresa)
        {
            db.ofertaBonificacionHabitue6(id_Usuario, empresa, ref respuestaNumerica);
            return respuestaNumerica;
        }

        public int? ofertaAumentoCompra(int id_Usuario, int empresa)
        {
            db.ofertaAumentoDias7(id_Usuario, empresa, ref respuestaNumerica);
            return respuestaNumerica;
        }

        public int? ofertaAumentoCompras(int id_Usuario, int empresa)
        {
            db.ofertaAumentoDiasTodasCompras8(id_Usuario, empresa, ref respuestaNumerica);
            return respuestaNumerica;
        }

        public string ofertaDescuentoImpresion(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoCompraImpresion9(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaImpresionGratis(int id_Usuario, int empresa)
        {
            db.ofertaCompraImpresionGratis10(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;

        }

        public bool? permitirComprarImpresion(int id_Usuario, int empresa, decimal costoEjercicio)
        {
            db.sinCreditoImpresion(id_Usuario, empresa, costoEjercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public bool? compraImpresionesDataList(int id_Usuario, int id_Ejercicio, decimal precioCompra, int empresa, int tipoMovimiento, int diasExtras)
        {
            db.compraImpresionDataList(id_Usuario, id_Ejercicio, precioCompra, empresa, tipoMovimiento, ref respuestaLogico);
            return respuestaLogico;
        }

        public decimal? compraSinOferta(int empresa)
        {
            db.sinOferta(empresa, ref respuestaPrecio);
            return respuestaPrecio;
        }

        public string ubicarArchivoImpresion(int id_Ejercicio)
        {
            db.mostrarEnunciadoImprimible(id_Ejercicio, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;        
        }
    }
}
