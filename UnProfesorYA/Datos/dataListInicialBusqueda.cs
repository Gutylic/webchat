using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dataListInicialBusqueda
    {

        DataClassesDataContext db = new DataClassesDataContext();
        string Etiqueta_Armada;      

        public string Metodo_Buscar_Profesor(string Dato) // vamos a formar la etiqueta de consulta para el profesor
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio 
            {
                return "\"p*\"";  // devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_Profesor> Etiqueta_Tabla_Profesor = (db.buscarEnTablaProfesores(Dato).ToList());  // busca en la tabla profesores y me devuelve una lista              
            try
            {
                foreach (Tabla_Profesor s in Etiqueta_Tabla_Profesor) // paso la lista a una variable string
                {
                    Etiqueta_Armada = Etiqueta_Armada + "p" + s.etiquetaProfesor + " or "; //separo cada componente de la lista con un or especial para la busqueda constains
                }

                Etiqueta_Armada = Etiqueta_Armada + "p0";

                return Etiqueta_Armada; // agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "p0";
            }
        }

        public string Metodo_Buscar_Materia(string Dato) // vamos a formar la etiqueta de consulta para el materia
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"m*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_Materia> Etiqueta_Tabla_Materia = (db.buscarEnTablaMaterias(Dato).ToList());// busca en la tabla materias y me devuelve una lista    
            try
            {
                foreach (Tabla_Materia s in Etiqueta_Tabla_Materia) // paso la lista a una variable string
                {
                    Etiqueta_Armada = Etiqueta_Armada + "m" + s.etiquetaMateria + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }

                Etiqueta_Armada = Etiqueta_Armada + "m0";

                return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto        
            }
            catch
            {
                return "m0";
            }

        }

        public string Metodo_Buscar_Tema(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"t*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_Tema> Etiqueta_Tabla_Tema = (db.buscarEnTablaTemas(Dato).ToList());// busca en la tabla temas y me devuelve una lista                 
            try
            {
                foreach (Tabla_Tema s in Etiqueta_Tabla_Tema)  // paso la lista a una variable string 
                {
                    Etiqueta_Armada = Etiqueta_Armada + "t" + s.etiquetaTema + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }

                Etiqueta_Armada = Etiqueta_Armada + "t0";

                return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "t0";
            }

        }

        public string Metodo_Buscar_Ano(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"a*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_Ano> Etiqueta_Tabla_Ano = (db.buscarEnTablaAnos(Dato).ToList());// busca en la tabla Años y me devuelve una lista  
            try
            {
                foreach (Tabla_Ano s in Etiqueta_Tabla_Ano) // paso la lista a una variable string  
                {
                    Etiqueta_Armada = Etiqueta_Armada + "a" + s.etiquetaAno + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                Etiqueta_Armada = Etiqueta_Armada + "a0";

                return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "a0";
            }
        }

        public string Metodo_Buscar_Colegio(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"c*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_Colegio> Etiqueta_Tabla_Colegio = (db.buscarEnTablaColegios(Dato).ToList());// busca en la tabla Colegio y me devuelve una lista  
            try
            {
                foreach (Tabla_Colegio s in Etiqueta_Tabla_Colegio) // paso la lista a una variable string 
                {
                    Etiqueta_Armada = Etiqueta_Armada + "c" + s.etiquetaColegio + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                Etiqueta_Armada = Etiqueta_Armada + "c0";

                return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "c0";
            }
            
        }

    }

}
