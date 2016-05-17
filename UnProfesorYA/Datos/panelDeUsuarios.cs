using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panelDeUsuarios
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<consultaPanelControlResult> mostrarConsultaPanelControl(int id_Usuario)
        {
            return db.consultaPanelControl(id_Usuario).ToList();        
        }

        public void mostrarCambioTelefono(int id_Usuario, string password,string correo, string telefono, string modelo, string skype,int empresa, int pais)
        {
            db.modificarPanelControlCambioTelefono(id_Usuario, password, correo, telefono, modelo, skype, empresa, pais);
        }

        public void mostrarCambioCorreo(int id_Usuario, string password, string correo, string telefono, string modelo, string skype,int empresa, int pais)
        {
            db.modificarPanelControlCambioCorreo(id_Usuario, password, correo, telefono, modelo, skype,empresa, pais);
        }

        public void mostrarCambioTelefonoCorreo(int id_Usuario, string password, string correo, string telefono, string modelo, string skype,int empresa, int pais)
        {
            db.modificarPanelControlCambioTelefono(id_Usuario, password, correo, telefono, modelo, skype,empresa, pais);
        }

    }
}
