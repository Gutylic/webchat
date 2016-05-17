using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class creditosUsuarios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        decimal? resultadoPrestamo;
        decimal? valorTarjeta;
        bool? bloqueoSOS;
        int? resultado;
       
        public decimal? prestamoSOSPedido(int id_Usuario, int empresa)
        {             
            db.pedidoPrestamoSOS(id_Usuario,empresa, ref resultadoPrestamo);
            return resultadoPrestamo;        
        }

        public void cargaSOSPedido(int id_Usuario, int empresa, decimal prestamoSOS)
        {
            db.cargarPrestamoSOS(id_Usuario, empresa, prestamoSOS);          
        }



        public decimal? cargaCreditoTarjetaPrepaga(int codigo, int empresa)  // buscar el credito de la tarjeta prepaga
        {
            db.cargaTarjetaPrepaga(codigo, empresa, ref valorTarjeta);
            return valorTarjeta;
        }

        public decimal? cargarOfertaProximaVez (int id_Usuario, int empresa, decimal cargaCredito) // analiza si hay oferta de recarga
        {
            db.cargadorOfertasProximaCarga(id_Usuario,empresa, cargaCredito, ref valorTarjeta);
            return valorTarjeta;
        }
     
        public decimal? cargarOfertaAumento (int id_Usuario, int empresa, decimal cargaCredito) // analiza si hay oferta de aumento en la carga
        {
            db.cargadorOfertasAumentoCarga(id_Usuario, empresa, cargaCredito, ref valorTarjeta);
            return valorTarjeta;
        }

        public decimal? cargarOfertaRegalo (int id_Usuario, int empresa, decimal cargaCredito) // analiza si hay oferta de regalo en el credito
        {
            db.cargadorOfertasAumentoCarga(id_Usuario, empresa, cargaCredito, ref valorTarjeta);
            return valorTarjeta;
        }

        public bool? prestamoSOSRealizado (int id_Usuario) // analiza si pidio un prestamo sos
        {
            db.ofertaPrestamoSOSRealizado(id_Usuario, ref bloqueoSOS);
            return bloqueoSOS;
        }

        public void cargaCreditoPagoParcial(int id_Usuario, decimal cargaCredito, int empresa)  // analiza si devolvio parte del prestamo sos
        { 
            db.cargarCreditoTarjetaPagoParcialSOS(id_Usuario,cargaCredito, empresa);
                    
        }

        public void cargaCreditoPagoTotal(int id_Usuario, decimal cargaCredito, int empresa)  // analiza si devolvio todo el prestamo sos
        {
            db.cargarCreditoTarjetaPagoTotalSOS(id_Usuario, cargaCredito, empresa);

        }

        public int? recargarProximaOferta(int empresa, int id_Usuario)   // crea la oferta la proxima vez que carga
        {
            db.ofertaProximaCarga(empresa, id_Usuario,ref resultado);
            return resultado;
        }

    }
}
