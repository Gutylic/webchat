using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class comprarExplicacionDataList
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

        public bool? evitarRecomprarExplicacion(int id_Usuario, int id_Ejercicio)
        {
            db.evitarRecompraExplicacion1(id_Usuario, id_Ejercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public string oferta2x1(int id_Usuario, int empresa)
        {
            db.ofertaDosXUno2(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2x1Explicacion(int id_Usuario, int empresa)
        {
            db.ofertaDosXUnoIgualProductoExplicacion3(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaGratis(int id_Usuario)
        {
            db.ofertaGratis4(id_Usuario, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2DescuentoExplicacion(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoSegundoProductoExplicacion5(id_Usuario, empresa, ref respuestaAlfanumerica);
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

        public string ofertaDescuentoExplicacion(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoCompraExplicacion9(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaExplicacionGratis(int id_Usuario, int empresa)
        {
            db.ofertaCompraExplicacionGratis10(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;

        }

        public bool? permitirComprarExplicacion(int id_Usuario, int empresa, decimal costoEjercicio)
        {
            db.sinCreditoExplicacion(id_Usuario, empresa, costoEjercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public bool? compraExplicacionDataList(int id_Usuario, int id_Ejercicio, decimal precioCompra, int empresa, int tipoMovimiento, int diasExtras)
        {
            db.compraExplicacionesDataListWeb(id_Usuario, id_Ejercicio, precioCompra, empresa, tipoMovimiento, diasExtras, ref respuestaLogico);
            return respuestaLogico;
        }

        public decimal? compraSinOferta(int empresa)
        {
            db.sinOferta(empresa, ref respuestaPrecio);
            return respuestaPrecio;

        }


    }
}
