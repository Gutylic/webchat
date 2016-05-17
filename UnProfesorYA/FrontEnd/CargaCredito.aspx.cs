using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class CargaCredito : System.Web.UI.Page
    {

        creditosUsuarios cU = new creditosUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSOS_Click(object sender, EventArgs e)
        {
            decimal? prestamo = cU.prestamoSOSPedido(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
            if (prestamo == -1)
            {
                // cartelito que ya pediste credito sos
                return;
            }
            if (prestamo == 0)
            {
                // cartelito que te dice que esta ferta no esta disponible
                return;
            
            }

            cU.cargaSOSPedido(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2,Convert.ToDecimal(prestamo));
            // cartelito de pedido de prestamo
            return;

        }

        protected void BtnTarjeta_Click(object sender, EventArgs e)
        {
           
            decimal? valorCarga = cU.cargaCreditoTarjetaPrepaga(int.Parse(TxtTarjeta.Text), 2);

            if (valorCarga == 0)
            { 
                // cartelito que avisa que no sirve el codigo de la tarjeta
                return;
            }

            valorCarga = cU.cargarOfertaProximaVez(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(valorCarga));

            valorCarga = cU.cargarOfertaAumento(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(valorCarga));

            valorCarga = cU.cargarOfertaRegalo(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(valorCarga));

            bool? prestamoPedido = cU.prestamoSOSRealizado(Convert.ToInt32(Session["Variable_ID_Usuario"]));

            if (prestamoPedido == true)
            {
                cU.cargaCreditoPagoParcial(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToDecimal(valorCarga), 2);

                cU.cargaCreditoPagoTotal(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToDecimal(valorCarga), 2);
            }

            int? validacionOferta = cU.recargarProximaOferta(2, Convert.ToInt32(Session["Variable_ID_Usuario"]));

            if (validacionOferta == 1)
            { 
                // cartelito de que la proxima vez tendra premio
                return;
            }

            // cartelito de cargado
            return;

        }
    }
}