using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class compraEjerciciosDataList
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

        public bool? evitarRecomprarEjercicio(int id_Usuario, int id_Ejercicio)
        {
            db.evitarRecompraEjercicio1(id_Usuario, id_Ejercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public string oferta2x1(int id_Usuario, int empresa)
        {
            db.ofertaDosXUno2(id_Usuario,empresa,ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2x1Ejercicio(int id_Usuario, int empresa)
        {
            db.ofertaDosXUnoIgualProductoEjercicio3(id_Usuario, empresa,ref respuestaAlfanumerica);
            return respuestaAlfanumerica;        
        }

        public string ofertaGratis(int id_Usuario)
        {
            db.ofertaGratis4(id_Usuario, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string oferta2DescuentoEjercicio(int id_Usuario,int empresa)
        {
            db.ofertaDescuentoSegundoProductoEjercicio5(id_Usuario, empresa, ref respuestaAlfanumerica);
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

        public string ofertaDescuentoEjercicio(int id_Usuario, int empresa)
        {
            db.ofertaDescuentoCompraEjercicio9(id_Usuario, empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        }

        public string ofertaEjerciciosGratis(int id_Usuario, int empresa)
        { 
            db.ofertaCompraEjercicioGratis10(id_Usuario,empresa, ref respuestaAlfanumerica);
            return respuestaAlfanumerica;
        
        }

        public bool? permitirComprarEjercicio(int id_Usuario, int empresa, decimal costoEjercicio)
        {
            db.sinCreditoEjercicio(id_Usuario, empresa,costoEjercicio, ref respuestaLogico);
            return respuestaLogico;
        }

        public bool? compraEjercicioDataList(int id_Usuario, int id_Ejercicio, decimal precioCompra, int empresa, int tipoMovimiento, int diasExtras)
        {
            db.compraEjerciciosDataListWeb(id_Usuario, id_Ejercicio, precioCompra, empresa, tipoMovimiento, diasExtras, ref respuestaLogico);
            return respuestaLogico;        
        }

        public decimal? compraSinOferta(int empresa)
        {
            db.sinOferta(empresa, ref respuestaPrecio);
            return respuestaPrecio;
        
        }
       

    }
}
