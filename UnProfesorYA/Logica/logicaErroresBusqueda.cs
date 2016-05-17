using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicaErroresBusqueda
    {

        public int busquedaDatosVacios(string profesor, string ano, string tema, string colegio, string materia)
        {
            if (profesor == string.Empty && ano == string.Empty && tema == string.Empty && colegio == string.Empty && materia == string.Empty)
            {
                return -1;
            }
            return 1;
        }

        public string corregirEtiquetas(string dato)
        {
            dato = dato.ToLower();
            dato = dato.Replace(" ", "").Replace("\"", "").Replace(",", "").Replace("+", "").Replace("'", "").Replace("ñ", "n");
            dato = dato.Trim();
            Byte[] tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(dato);// quitar acentos dieresis y palabras de otro idioma simbolos raros
            dato = Encoding.UTF8.GetString(tempBytes);            
            return dato;
        }





    }
}
