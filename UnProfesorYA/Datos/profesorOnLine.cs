using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class profesorOnLine
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? numeroPedido;

        public void cargarTablaEjercicioVideosPedidos(int id_Usuario, string fichaEjercicioVideo,string enunciadoEjercicioVideoMath, string adjuntoEjercicioVideo)
        {
            db.cargarPedidoEjercicioVideo(id_Usuario, fichaEjercicioVideo, enunciadoEjercicioVideoMath, adjuntoEjercicioVideo);
        
        }

        public void cargarTablaEjercicioVideosPedidosEjercicios(int id_Usuario, string fichaEjercicioVideo, string enunciadoEjercicioVideoMath, string adjuntoEjercicioVideo)
        {
            db.cargarPedidoEjercicioVideoEjercicio(id_Usuario, fichaEjercicioVideo, enunciadoEjercicioVideoMath, adjuntoEjercicioVideo);

        }

        public int? obtenerPosicionPedido()
        {
            db.obtenerPedidoEjericicoVideo(ref numeroPedido);
            return numeroPedido + 1;
        }


    }
}
