using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Logica
{
    public class logicaProfesorOnLine
    {

        profesorOnLine pOL = new profesorOnLine();

        int tipoA;
        int tipoB;
        int tipoC;
              

        public int estadoProfesor(string enunciadoWiris, bool archivoAdjunto, string materia, string profesor, string tema, string ano, string colegio)
        {
            if (materia == string.Empty && tema == string.Empty && ano == string.Empty && profesor == string.Empty && colegio == string.Empty && enunciadoWiris == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>" && !archivoAdjunto)
            { 
                // todo vacio
                return 0;

            }


            if (materia == string.Empty && tema == string.Empty && ano == string.Empty && profesor == string.Empty && colegio == string.Empty)
            {
                tipoA = 1;            
            }
            else
            {
                tipoA = 2;
            }

            if (enunciadoWiris == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>")
            {
                tipoB = 3;           
            }
            else
            {
                tipoB = 4;
            }

            if (!archivoAdjunto)
            {
                tipoC = 5;
            }
            else
            {
                tipoC = 6;
            }
                      
            if (tipoA == 2 && tipoB == 4 && tipoC == 6)
            { 
                // enunciado y titulos llenos y adjunto
                return 3;
            }

            if (tipoA == 2 && tipoB == 3 && tipoC == 6)
            {
                // ficha llena y enunciado vacio y adjunto
                return 2;
            }

            if (tipoA == 1 && tipoB == 4 && tipoC == 6)
            {
                // ficha vacia y enunciado lleno y adjunto
                return 1;            
            }

            if (tipoA == 2 && tipoB == 4 && tipoC == 5)
            {
                // solo ficha y enunciado
                return 6; 
            }

            if (tipoA == 1 && tipoB == 4 && tipoC == 5)
            {
                // solo enunciado
                return 5;
            }

            if (tipoA == 2 && tipoB == 3 && tipoC == 5)
            {
                // solo ficha
                return 0;
            }

            return 4;
        
        }

        public string armadoNombreEnvioAdjunto(string usuario)
        {
            string pedido = Convert.ToString(pOL.obtenerPosicionPedido());
            return "C:\\archivo/" + usuario + "╝" + pedido + "_adj.";        
        }

        public string armadoNombreEnvioFicha(string usuario)
        {
            string pedido = Convert.ToString(pOL.obtenerPosicionPedido());
            return "C:\\archivo/" + usuario + "╝" + pedido + "_ficha.txt";
        }

        public string armadoNombreEnunciadoMATH(string usuario)
        {
            string pedido = Convert.ToString(pOL.obtenerPosicionPedido());
            return "C:\\archivo/" + usuario + "╝" + pedido + "_math.txt";        
        }

        public string armadoNombreEnunciadoClean(string usuario)
        {
            string pedido = Convert.ToString(pOL.obtenerPosicionPedido());
            return "C:\\archivo/" + usuario + "╝" + pedido + "_clean.txt";

        }

        public void avisoAdjuntoSoloEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para envioOK@outlook.com.ar
            Mio.Subject = "Se envió un ejercicio para ser resuelto";
            Mio.Body = "El usuario: " + usuario + " envió un archivo adjunto para ser resuelto";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);
            
        }

        public void avisoAdjuntoEnunciadoEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para envioOK@outlook.com.ar
            Mio.Subject = "Se envió un ejercicio para ser resuelto";
            Mio.Body = "El usuario: " + usuario + " envió un archivo adjunto y un enunciado para ser resuelto";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }

        public void avisoAdjuntoEnunciadoFichaEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para envioOK@outlook.com.ar
            Mio.Subject = "Se envió un ejercicio para ser resuelto";
            Mio.Body = "El usuario: " + usuario + " envió un archivo adjunto con su ficha y un enunciado para ser resuelto";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }

        public void avisoEnunciadoEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para envioOK@outlook.com.ar
            Mio.Subject = "Se envió un ejercicio para ser resuelto";
            Mio.Body = "El usuario: " + usuario + " envió un enunciado para ser resuelto, sin ficha ni adjunto";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }

        public void avisoEnunciadoFichaEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para envioOK@outlook.com.ar
            Mio.Subject = "Se envió un ejercicio para ser resuelto";
            Mio.Body = "El usuario: " + usuario + " envió un enunciado para ser resuelto, con su ficha sin adjunto";
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }
        
        public void archivoCrearEnunciado(string enunciado, string usuario) // carga dos archivos en c: correspondiente a los enunciados
        {            
            string enunciado_corregido = corregirEnunciadoProfesor(enunciado); // corrigiendo el enunciado
            StreamWriter editor_corregido = File.CreateText(armadoNombreEnunciadoClean(usuario)); // carga el archivo corregido del enunciado en c:

            string contenido = enunciado_corregido;
            editor_corregido.Write(contenido);
            editor_corregido.Flush();
            editor_corregido.Close(); // cierra archivo corregido

            StreamWriter editor = File.CreateText(armadoNombreEnunciadoMATH(usuario)); // carga el archivo natural del enunciado en c:
            contenido = enunciado.ToLower(); // pasa a todo el enunciado de wiris a minusculas y carga archivo Math
            editor.Write(contenido);
            editor.Flush();
            editor.Close(); // cierra archivo math

           // return Enunciado_Corregido; // devuelve el enunciado corregido para luego separarlo en cuatro percentiles del 25%
        }

        public string corregirEnunciadoProfesor(string Enunciado)
        {            
            // quitare todos los caracteres que genera wiris para que el codigo quede limpio y sin espacio
            string[] Terminos_Borrados = new string[] { "<msubsup>", "<mmultiscripts>", "<presubsup>", "</presubsup>", "<mprescripts/>", "<none/>", "</mmultiscripts>", "</msubsup>", "<mo largeop=\"true\">", "<mrow/>", "<munder>", "</munder>", "<munderover>", "</munderover>", "<mover>", "</mover>", "<menclose notation=\"updiagonalstrike\">", "<menclose notation=\"updiagonalstrike\"/>", "</menclose>", "<mfenced open=\"|\" close=\"|\">", "</mfenced>", "<mi mathvariant=\"normal\">", "<mfrac>", "</mfrac>", "<msup>", "</msup>", "<msub>", "</msub>", "<mrow>", "</mrow>", "<msqrt>", "</msqrt>", "<mroot>", "</mroot>", "<mi>", "</mi>", "<mn>", "</mn>", "<mo>", "</mo>", "&#8201;", "</math>","<msqrt/>", "<math xmlns=\"http://www.w3.org/1998/Math/MathML\">", "<maction actiontype=\"argument\">", "</maction>", "<mstyle displaystyle=\"true\">", "</mstyle>", "<mfenced open=\"||\" close=\"||\">", "<menclose notation=\"circle\">", "<menclose notation=\"actuarial\">", "<menclose notation=\"roundedbox\">", "<menclose notation=\"roundedbox\"/>", "<menclose notation=\"top\">", "<menclose notation=\"left\">", "<menclose notation=\"box\"/>", "<menclose notation=\"right\">", "<menclose notation=\"bottom\"/>", "<mfenced open=\"&#8970;\" close=\"&#8971;\">", "<mfenced open=\"&lt;\" close=\"&#62;\" separators=\"|\">", "<mfenced open=\"&#8968;\" close=\"&#8969;\">", "<menclose notation=\"top\"/>", "<menclose notation=\"left\"/>", "<menclose notation=\"right\"/>", "<menclose notation=\"circle\"/>", "<menclose notation=\"actuarial\"/>", "<menclose notation=\"bottom\">", "<menclose notation=\"box\">", "<menclose notation=\"downdiagonalstrike\">", "<menclose notation=\"downdiagonalstrike updiagonalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"verticalstrike\">", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\">", 
                "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"downdiagonalstrike\"/>", "<menclose notation=\"downdiagonalstrike updiagonalstrike\"/>", "<menclose notation=\"verticalstrike\"/>", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\"/>", "<menclose/>", "<mtable>", "<mtr>", "<mtd/>", "</mtr>", "</mtable>", "<mtd>", "</mtd>", "<mfenced open=\"[\" close=\"]\">", "<mfenced>", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"{\" close=\"\">", "<mtable columnalign=\"left\">", "<mfenced open=\"\" close=\"}\">", "&#172;","&#175;","&#176;","&#177;","&#183;","&#960;","&#729;","&#168;","&#945;","&#946;","&#947;","&#948;","&#949;","&#950;","&#951;","&#952;","&#977;","&#953;","&#954;","&#955;","&#956;","&#957;","&#958;","&#959;","&#982;","&#961;","&#962;","&#963;","&#964;","&#965;","&#966;","&#981;","&#967;","&#968;","&#969;","&#913;","&#914;","&#915;","&#916;","&#917;","&#918;","&#919;","&#920;","&#921;","&#922;","&#923;","&#924;","&#925;","&#926;","&#927;","&#928;","&#929;","&#931;","&#932;","&#933;","&#934;","&#935;","&#936;","&#937;","&#8597;","&#8592;", "&#8593;","&#8595;","&#8596;","&#8594;","&#8598;", "&#8599;","&#8600;","&#8601;","&#8618;","&#8629;","&#8657;","&#8645;","&#8659;","&#8617;","&#8661;","&#8636;","&#8637;","&#8646;","&#8651;","&#8652;","&#8640;","&#8644;","&#8641;","&#8656;","&#8658;","&#8660;","&#8612;","&#8614;","&#8704;","&#8706;", "&#8707;" ,"&#8708;","&#8709;","&#8710;","&#8711;", "&#8712;","&#8715;","&#8721;","&#8719;","&#8713;", "&#8716;","&#8728;", "&#8726;", "&#8723;","&#8729;","&#8733;","&#8734;","&#8736;","&#8737;","&#8738;","&#8741;","&#8742;","&#8743;", "&#8744;","&#8745;","&#8746;","&#8756;","&#8757;","&#8769;","&#8773;","&#8776;", "&#8747;","&#8750;","&#8748;","&#8751;","&#8749;","&#8752;","&#8801;", "&#8804;","&#8805;",
                "&#8810;", "&#8826;","&#8834;","&#8835;", "&#8838;", "&#8839;","&#8847;" ,"&#8848;", "&#8849;", "&#8850;","&#8851;","&#8852;","&#8853;","&#8855;","&#8857;", "&#8859;", "&#8861;","&#8869;","&#8882;", "&#8883;","&#8900;","&#9633;","&#9649;","&#9651;","&#9675;","&#9180;","&#9181;","&#9183;","&#9182;","&#10808;","&#10888;","&#10529;","&#10530;","&#10606;","&#10602;","&#10607;","&#10605;","&#x000B1;","&#x0222A;","&#x003C0;","&#x0221E;","&#x02208;","&#x02282;","&#x02229;","&#x02265;","&#x02264;","&#x02205;","&#x003bd","<mi mathvariant=\"fraktur\">","<mi mathvariant=\"script\">", "&#x000B7;","&#x02218;","&#x02216;","&#x02213;","&#x02207;","&#x02206;","&#x02202;","&#x02035;","&#x02261;","&#x02243;","&#x02248;","&#x02245;","&#x02260;","&#x02262;","&#x02241;","&#x02249;","&#x02A87;","&#x0226B;","&#x0227B;","&#x02A88;","&#x0221D;","&#x022B2;","&#x0226A;","&#x0227A;","&#x022B3;","&#x0220B;","&#x02283;","&#x02209;","&#x0220C;","&#x02286;","&#x02287;","&#x0228F;","&#x02290;","&#x02291;","&#x02292;","&#x02293;","&#x02294;","&#x02203;","&#x000AC;","&#x02227;","&#x02228;","&#x02200;","&#x02204;","&#x02234;","&#x02235;","&#x02220;","&#x02225;","&#x022A5;","&#x02226;","&#x02221;","&#x02222;","&#x022C4;","&#x025A1;","&#x025B3;","&#x025CB;","&#x025AD;","&#x025B1;","&#x02295;","&#x02297;","&#x02299;","&#x0229D;","&#x0229B;","&#x02219;","&#x02A38;","&#x000B0;","&#x02190;","&#x02192;","&#x02194;","&#x021D0;","&#x021D2;","&#x021D4;","&#x021A4;","&#x021A6;","&#x02197;","&#x02198;","&#x02196;","&#x02199;","&#x02921;","&#x02922;","&#x021A9;","&#x021AA;","&#x021BC;","&#x021C0;","&#x02191;","&#x02193;","&#x021D1;","&#x021D3;","&#x0296A;","<mtable columnalign=\"right\">","&#x0296D;","&#x021CB;","&#x021CC;","&#x021BD;","&#x021C1;","&#x021C6;","&#x021C4;","&#x021C5;","&#x021F5;","&#x0296E;","&#x0296F;","&#x02195;","&#x021D5;","&#x021B5;","&#x022EE;",
                "&#x02026;","&#x022F1;","&#x022EF;","&#x02192;","&#x02192;","&#x02192;","&#x02190;","&#x02190;","&#x000AF;","&#x02194;","&#x021C0;","&#x02192;","&#x022F0;","&#x003B1;","&#x003B3;","&#x003B2;","&#x003B4;","&#x003B5;","&#x003B6;","&#x003B7;","&#x003B8;","&#x003D1;","&#x003B9;","&#x003C2;","&#x003C1;","&#x003D6;","&#x003BF;","&#x003BE;","&#x003BC;","&#x003BB;","&#x003BA;","&#x003C3;","&#x003C4;","&#x003C5;","&#x003C6;","&#x003D5;","&#x003C7;","&#x003C8;","&#x003C9;","&#x00392;","&#x00393;","&#x00394;","&#x00395;","&#x00396;","&#x00397;","&#x00398;","&#x003A0;","&#x003A9;","&#x0039F;","&#x003A8;","&#x00396;","&#x0039E;","&#x003A7;","&#x003A6;","&#x0039D;","&#x00394;","&#x00393;","&#x0039B;","&#x003A4;","&#x003A3;","&#x0039A;","&#x00399;","&#x003A1;","&#x003BD;","&#x00391;","&#x0039C;","&#x003A5;","<mi mathvariant=\"double-struck\">","&#x02119;","&#x02124;","&#x02102;","&#x0210D;","&#x1D540;","&#x02115;","&#x0211D;","&#x02115;","&#x0211A;","&#x02124;","&#x0222B;","&#x0222B;","&#x0222B;","&#x0222B;","&#x000D7;","&#x0222B;","&#x0222C;","&#x0222F;","&#x0222E;","&#x0222D;","&#x02230;","&#x02211;","&#x0220F;","<mfenced open=\"&#x0230A;\" close=\"&#x0230B;\">","<mfenced open=\"&lt;\" close=\"&gt;\" separators=\"|\">","<mfenced open=\"&#x02308;\" close=\"&#x02309;\">","&#x023DE;","&#x023DC;","&#x023DD;","&#x023DF;","&#x000A8;","&#x002D9;","<menclose notation=\"horizontalstrike\"/>","<mstack charalign=\"center\" stackalign=\"right\">","<msrow>","</msrow>","<msrow/>","<msline/>","</mstack>","<mlongdiv charalign=\"center\" charspacing=\"0px\" stackalign=\"left\">","<msgroup>","</msgroup>","</mlongdiv>"};

            string[] Enunciado_Limpio = Enunciado.Split(Terminos_Borrados, StringSplitOptions.RemoveEmptyEntries); // remover los caracteres extraños que usan otros idiomas
            
            string Linea = "";
            
            foreach (string Caracter in Enunciado_Limpio) // genero una variable nueva ya corregida si los caracteres raros de wiris
            {
                Linea = Linea + Caracter;
            }
            
            // pongo todos los terminos en minusculas y saco los acentos
            Linea = Linea.ToLower();
            Linea = Linea.Replace("<mspace linebreak=\"newline\"/>", " ");
            Linea = Linea.Replace("'", "´");
            Linea = Linea.Replace("&#x000a0;", " ");
            Linea = Linea.Replace("<mo></mo>", "");
            Linea = Linea.Replace("&#225;", "a");
            Linea = Linea.Replace("&#233;", "e");
            Linea = Linea.Replace("&#237;", "i");
            Linea = Linea.Replace("&#243;", "o");
            Linea = Linea.Replace("&#250;", "u");
            Linea = Linea.Replace("&#160;", " ");
            Linea = Linea.Replace("&#193;", "a");
            Linea = Linea.Replace("&#201;", "e");
            Linea = Linea.Replace("&#205;", "i");
            Linea = Linea.Replace("&#211;", "o");
            Linea = Linea.Replace("&#218;", "u");
            Linea = Linea.Replace("&#209;", "n");
            Linea = Linea.Replace("Á;", "a");
            Linea = Linea.Replace("É", "e");
            Linea = Linea.Replace("Í", "i");
            Linea = Linea.Replace("Ó", "o");
            Linea = Linea.Replace("Ú", "u");
            Linea = Linea.Replace("ñ", "n");
            Linea = Linea.Replace("Ñ", "n");
            Linea = Linea.Replace("º", "");
            Linea = Linea.Replace("&#x000e1;", "a");
            Linea = Linea.Replace("&#x000e9;", "e");
            Linea = Linea.Replace("&#x000ed;", "i");
            Linea = Linea.Replace("&#x000f3;", "o");
            Linea = Linea.Replace("&#x000fa;", "u");
            Linea = Linea.Replace("&#x000f1;", "n");
            Linea = Linea.Replace("&#x000d1;", "n");
            Linea = Linea.Replace("&#x000c1;", "a");
            Linea = Linea.Replace("&#x000c9;", "e");
            Linea = Linea.Replace("&#x000cd;", "i");
            Linea = Linea.Replace("&#x000d3;", "o");
            Linea = Linea.Replace("&#x000dc;", "u");
            Linea = Linea.Replace("&#x000da;", "u");
            Linea = Linea.Replace("&#x000fc;", "u");
            Linea = Linea.Replace("&#x000bf;", "¿");
            Linea = Linea.Replace("&#x000a1;", "¡");
            Linea = Linea.Replace("&quot;", "´´");
            Linea = Linea.Replace("&#x000b4;", "´");
            Linea = Linea.Replace("&amp;", "&");
            Linea = Linea.Replace("&#x000ba;", "º");
            Linea = Linea.Replace("&#x02009;", "");
            Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
            return Linea; // variable final limpia de wiris

        }

        public void archivoCrearFicha(string tema, string materia, string profesor, string colegio, string ano, string usuario) // crea la ficha
        {                      
            tema = tema.ToLower();
            materia = materia.ToLower();
            profesor = profesor.ToLower();
            colegio = colegio.ToLower();
            ano = ano.ToLower();// genera un archivo ficha con los datos separados por el chirimbolo
            StreamWriter Ficha = File.CreateText(armadoNombreEnvioFicha(usuario));// escribe dentri del archivo
            Ficha.Write("Tema: ╝");
            Ficha.Write(tema + " ╝// ");
            Ficha.Write("Materia: ╝");
            Ficha.Write(materia + " ╝// ");
            Ficha.Write("Profesor: ╝");
            Ficha.Write(profesor + " ╝// ");
            Ficha.Write("Colegio: ╝");
            Ficha.Write(colegio + " ╝// ");
            Ficha.Write("Ano: ╝");
            Ficha.Write(ano);
            Ficha.Flush();
            Ficha.Close();
        }

        public void avisoAdjuntoFichaEnviado(string usuario)
        {
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com"); // aviso por mail
            Mio.To.Add("RegistroOK@outlook.com"); // cambiar el correo para fichaOK@outlook.com.ar
            Mio.Subject = "Se envió la ficha de un ejercicio";
            Mio.Body = "EL usuario: " + usuario + " envió la ficha de un ejercicio para ser resuelto";
            Mio.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            smtp.Send(Mio);

        }

        public class dosDatosStringParaBuscarPorEnunciado // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public string Valor_1 { get; set; }
            public string Valor_2 { get; set; }
        }

        public dosDatosStringParaBuscarPorEnunciado logicaEnunciadosAl25(string Enunciado)
        {
            dosDatosStringParaBuscarPorEnunciado Datos = new dosDatosStringParaBuscarPorEnunciado();
           
            string[] Palabras = Enunciado.Split(' '); // separa por palabras
            int Cantidad_De_Palabras = Palabras.Length; // cuento cuantas palabras tiene el enunciado
            int Porcentaje = Cantidad_De_Palabras / 4; // divido al enunciado en 4 partes con la misma cantidad de palagras 
            int Resto = Cantidad_De_Palabras % 4; // caso especial de no ser divisible por 4 la cantidad de palabras del enunciado
            int Palabras_Exactas;
            int Palabras_Erroneas;

            if (Cantidad_De_Palabras == 1) // el caso especial de una sola palabra
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[0].Trim() + "\"";  // Variable 2          
                return Datos;
            }
            if (Cantidad_De_Palabras == 2) // el caso especial de dos palabras
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[1].Trim() + "\"";  // Variable 2          
                return Datos;
            }
            if (Cantidad_De_Palabras == 3) // el caso especial de tres palabras
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[2].Trim() + "\"";  // Variable 2          
                return Datos;
            }


            if (Resto != 0) // le suma una palabra si no puedo dividir exactamente el enunciado en 4
            {
                Palabras_Exactas = Porcentaje + 1;

            }
            else // enunciado divisible por 4
            {
                Palabras_Exactas = Porcentaje;
            }

            if (Resto == 1 || Resto == 2) 
            {
                Palabras_Erroneas = Porcentaje;
            }
            else
            {
                Palabras_Erroneas = Porcentaje + 1;
            }

            string[] Palabras_Armadas = new string[Palabras_Exactas];
            string[] Palabra = new string[2];

            for (int i = 0; i < Palabras_Exactas; i++)
            {
                Palabra[0] = Palabra[0] + " " + Palabras[i];

            }

            for (int i = (Palabras_Exactas + Palabras_Erroneas); i < (2 * Palabras_Exactas + Palabras_Erroneas); i++)
            {
                Palabra[1] = Palabra[1] + " " + Palabras[i];

            }

            Datos.Valor_1 = "\"" + Palabra[0].Trim() + "\"";  // Variable 1
            Datos.Valor_2 = "\"" + Palabra[1].Trim() + "\"";  // Variable 2          
            return Datos;
        }

    }
}
