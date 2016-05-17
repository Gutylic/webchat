using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace FrontEnd
{
    public partial class PanelSaldo : System.Web.UI.Page
    {

        panelSaldoDeUsuario pSDU = new panelSaldoDeUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            LblNombreUsuario.Text = Session["Name_Usuario"].ToString();
            LblCreditoSaldo.Text = pSDU.mostrarCreditoUsuario(Convert.ToInt32(Session["Variable_ID_Usuario"])).ToString();
                      
            DataList_Mis_Movimientos.DataSource = pSDU.mostrarMovimientosDelUsuario(Convert.ToInt32(Session["Variable_ID_Usuario"])).Take(15); // carga en un datalist los ultimos 15 movimientos
            DataList_Mis_Movimientos.DataBind();
           
        }
    }
}