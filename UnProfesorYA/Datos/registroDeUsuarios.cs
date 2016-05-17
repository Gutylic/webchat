using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class registroDeUsuarios
    {

        DataClassesDataContext db = new DataClassesDataContext();

        int? respuestaRegistroUsuarioNumerico;
        string respuestaRegistoUsuarioAlfanumerico;
        bool? respuestaRegistroUsuarioBool;

        public int? datosUsuarioExiste(string correo, int empresa, string telefono, string facebook)
        { // Busca la existencia del usuario y evita su reregistro
            db.usuarioExiste(correo, empresa, telefono, facebook, ref respuestaRegistroUsuarioNumerico);
            return respuestaRegistroUsuarioNumerico;
        }

        public int? datosUsuarioRegistrado(string password, string correo, string telefono,int empresa, string ipAddress, int codigo, string id_Facebook, string nameFacebook, int pais)
        { // registra un usuario
            db.usuarioRegistrado(password, correo, telefono, empresa, ipAddress, codigo, id_Facebook, nameFacebook,pais, ref respuestaRegistroUsuarioNumerico);
            return respuestaRegistroUsuarioNumerico;
        }

        public class Logueado
        {
            public int? ID { get; set; }
            public string Name { get; set; }
        }


        public Logueado datosUsuarioLogueado(string correo, string password, string telefono, string id_Facebook, string nameFacebook)
        { // loguea a un usuario
            Logueado Dato = new Logueado();
            db.usuarioLogueado(correo, password, telefono, id_Facebook, nameFacebook, ref respuestaRegistroUsuarioNumerico, ref respuestaRegistoUsuarioAlfanumerico);
            Dato.ID = respuestaRegistroUsuarioNumerico;
            Dato.Name = respuestaRegistoUsuarioAlfanumerico;
            return Dato;
        }

        public string datosUsuarioContrasenaCorreo(string correo, int empresa)
        { // recuperar la contraseña la respuesta es alfanumerica
            db.usuarioContrasenaCorreo(correo, empresa, ref respuestaRegistoUsuarioAlfanumerico);
            return respuestaRegistoUsuarioAlfanumerico;
        }

        public string datosUsuarioContrasenaCelular(string telefono, int empresa)
        { // recuperar la contraseña la respuesta es alfanumerica
            db.usuarioContrasenaCelular(telefono, empresa, ref respuestaRegistoUsuarioAlfanumerico);
            return respuestaRegistoUsuarioAlfanumerico;
        }

        public int? datosUsuarioActivacionTelefono(string telefono,int empresa, int activacion)
        { // activacion telefonica del usuario 
            db.usuarioActivacionTelefono(telefono,empresa, activacion, ref respuestaRegistroUsuarioNumerico);
            return respuestaRegistroUsuarioNumerico;
        }
               
        public int? datosUsuarioActivacionCorreo(string correo, int empresa)
        { // activacion por correo del usuario 
            db.usuarioActivacionCorreo(correo,empresa, ref respuestaRegistroUsuarioNumerico);
            return respuestaRegistroUsuarioNumerico;
        }

        public bool? datosOfertaRegistro(int id_Usuario, int empresa)
        { // cargar la oferta por registro de usuario y el movimiento
            db.ofertaRegistro(id_Usuario, empresa, ref respuestaRegistroUsuarioBool);
            return respuestaRegistroUsuarioBool;      
        }




    }
}
