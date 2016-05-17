using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;


namespace FrontEnd
{
    public partial class PanelControl : System.Web.UI.Page
    {

        panelDeUsuarios pDU = new panelDeUsuarios();
        logicaPanelUsuario lPU = new logicaPanelUsuario();
        int errorResultado;


        protected void Page_Load(object sender, EventArgs e)
        {       
            List<consultaPanelControlResult> Datos = pDU.mostrarConsultaPanelControl(Convert.ToInt32(Session["Variable_ID_Usuario"]));
            TxtCorreo.Text = Datos[0].correo;
            TxtPassword.Text = Datos[0].password;
            TxtTelefono.Text = Datos[0].telefono; 
            TxtSkype.Text = Datos[0].skype; 
            TxtModelo.Text = Datos[0].modeloTelefono;
            DropDownListPais.SelectedValue = (Datos[0].pais).ToString();
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            string auxiliarCorreo = TxtCorreo.Text;
            string auxiliarTelefono = TxtTelefono.Text;

            errorResultado = lPU.erroresPassword(TxtPassword.Text);

            if (errorResultado == -1)
            {
                // error de cantidad de caracteres
                return;
            }

            if ((TxtCorreo.Text == auxiliarCorreo && TxtTelefono.Text == auxiliarTelefono) || (TxtCorreo.Text != auxiliarCorreo && TxtTelefono.Text != auxiliarTelefono))
            { 
                pDU.mostrarCambioTelefonoCorreo( Convert.ToInt32(Session["Variable_ID_Usuario"]),TxtPassword.Text,TxtCorreo.Text,TxtTelefono.Text,TxtModelo.Text,TxtSkype.Text,2,int.Parse(DropDownListPais.SelectedValue));
                // cartelito cambio realizado
                return;
            }
            if (TxtCorreo.Text != auxiliarCorreo)
            {
                pDU.mostrarCambioCorreo(Convert.ToInt32(Session["Variable_ID_Usuario"]), TxtPassword.Text, TxtCorreo.Text, TxtTelefono.Text, TxtModelo.Text, TxtSkype.Text, 2, int.Parse(DropDownListPais.SelectedValue));
                // cartelito cambio realizado
                return;            
            }
            if (TxtTelefono.Text != auxiliarTelefono)
            {
                pDU.mostrarCambioTelefono(Convert.ToInt32(Session["Variable_ID_Usuario"]), TxtPassword.Text, TxtCorreo.Text, TxtTelefono.Text, TxtModelo.Text, TxtSkype.Text, 2, int.Parse(DropDownListPais.SelectedValue));
                // cartielito de cambio realizado
                return;
            }
            
//            Caduco_Session(); // metodo para verificar si caduco la session                  

        }
    }
}