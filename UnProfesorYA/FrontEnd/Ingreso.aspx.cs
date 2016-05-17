using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            Label1.Text = Session["Name_Usuario"].ToString();
        }

        
        protected void CerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            HttpCookie VariableCookie = new HttpCookie("Usuario_Recordado");
            VariableCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(VariableCookie);
            Response.Redirect("Logueo.aspx");
        }

        protected void BtnPanelControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelControl.aspx");
        }

        protected void BtnPanelSaldo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelSaldo.aspx");
        }

        protected void BtnPanelCarga_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaCredito.aspx");
        }

        protected void BtnDataList_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEnunciados.aspx");
        }
    }
}