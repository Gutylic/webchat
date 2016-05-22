using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class compraVideosDataList
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

        public bool? evitarRecomprarVideo(int id_Usuario, int id_Ejercicio)
        {
            db.evitarRecompraEjercicio1(id_Usuario, id_Ejercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public string oferta2x1(int id_Usuario, int empresa)
        {
            db.ofertaDosXUno2(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2x1Video(int id_Usuario, int empresa)
        {
            db.ofertaDosXUnoIgualProductoEjercicio3(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaGratis(int id_Usuario)
        {
            db.ofertaGratis4(id_Usuario, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2DescuentoVideo(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoSegundoProductoVideo5(id_Usuario, empresa, ref respuestaAlfanumerica);
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

        public string ofertaDescuentoVideo(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoCompraVideo9(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaVideosGratis(int id_Usuario, int empresa)
        {
            db.ofertaCompraVideoGratis10(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;

        }

        public bool? permitirComprarVideos(int id_Usuario, int empresa, decimal costoEjercicio)
        {
            db.sinCreditoVideo(id_Usuario, empresa, costoEjercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public bool? compraVideoDataList(int id_Usuario, int id_Ejercicio, decimal precioCompra, int empresa, int tipoMovimiento, int diasExtras)
        {
            db.compraVideosDataListWeb(id_Usuario, id_Ejercicio, precioCompra, empresa, tipoMovimiento, diasExtras, ref respuestaLogico);
            return respuestaLogico;
        }

        public decimal? compraSinOferta(int empresa)
        {
            db.sinOferta(empresa, ref respuestaPrecio);
            return respuestaPrecio;

        }


    }
}
