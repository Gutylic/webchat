using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;

namespace FrontEnd
{
    public partial class ProfesorOnLine : System.Web.UI.Page
    {
        logicaProfesorOnLine lPOL = new logicaProfesorOnLine();
        profesorOnLine pOL = new profesorOnLine();
        comprarExplicacionDataList cEVDL = new comprarExplicacionDataList();
        compraEjerciciosDataList cEDL = new compraEjerciciosDataList();
        
        string valorAlfanumerico;
        string pagina;
        string enunciado;
        string enunciado_1;
        string enunciado_2;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviarEjercicio_Click(object sender, EventArgs e)
        {
            int envios = lPOL.estadoProfesor(Contenido_Wiris.Value, Subir_Adjunto.HasFiles, TxtMateria.Text, TxtProfesor.Text, TxtTema.Text, TxtAno.Text, TxtColegio.Text);

            switch (envios)
            { 
                case 0:
                    // todo esta vacio no hay ficha enunciado ni adjunto
                    return;

                case 1:
                    // solo enunciado + adjunto

                    // ofertas de valor de compra del ejercicio enviado

                    Session["Nombre_Adjunto_Adjunto"] = lPOL.armadoNombreEnvioAdjunto(Convert.ToString(Session["Variable_ID_Usuario"])) + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs(Convert.ToString(Session["Nombre_Adjunto_Adjunto"]));

                    Session["Nombre_Enunciado_Math"] = lPOL.armadoNombreEnunciadoMATH(Convert.ToString(Session["Variable_ID_Usuario"]));
                    Session["Nombre_Enunciado_Clean"] = lPOL.armadoNombreEnunciadoClean(Convert.ToString(Session["Variable_ID_Usuario"]));
                    lPOL.archivoCrearEnunciado(Contenido_Wiris.Value, Convert.ToString(Session["Variable_ID_Usuario"]));

                    enunciado = lPOL.corregirEnunciadoProfesor(Contenido_Wiris.Value); // corregir el enunciado

                    enunciado_1 = lPOL.logicaEnunciadosAl25(enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    enunciado_2 = lPOL.logicaEnunciadosAl25(enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                                        
                    pagina = "RespuestasEnunciado.aspx?Boton_Enunciado=false&Boton_Ficha=false&Enunciado1=" + enunciado_1 + "&Enunciado2=" + enunciado_2 + "&Caso=1"; // busca por ficha y bloquea el boton de buscar por enunciado
                    Response.Redirect(pagina);  

                    //esto va e la pagina enunciado
             //       pOL.cargarTablaEjercicioVideosPedidos(Convert.ToUInt16(Session["Variable_ID_Usuario"]), null, Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
             //       lPOL.avisoAdjuntoEnunciadoEnviado(Convert.ToString(Session["Name_Usuario"]));  

                    return;

                case 2:
                    // solo ficha + adjunto

                    // ofertas de valor de compra del ejercicio enviado
                                    
                    Session["Nombre_Adjunto_Adjunto"] = lPOL.armadoNombreEnvioAdjunto(Convert.ToString(Session["Variable_ID_Usuario"])) + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs(Convert.ToString(Session["Nombre_Adjunto_Adjunto"]));
                    
                    lPOL.archivoCrearFicha(TxtTema.Text, TxtMateria.Text, TxtProfesor.Text, TxtColegio.Text, TxtAno.Text, Convert.ToString(Session["Variable_ID_Usuario"]));                    
                    Session["Nombre_Adjunto_Ficha"] = lPOL.armadoNombreEnvioFicha(Convert.ToString(Session["Variable_ID_Usuario"]));

                    pagina = "RespuestasFichas.aspx?Tema=" + TxtTema.Text + "&Materia=" + TxtMateria.Text + "&Maestro=" + TxtProfesor.Text + "&Colegio=" + TxtColegio.Text + "&Ano=" + TxtAno.Text + "&Boton_Enunciado=false&Boton_Ficha=false&Caso=2"; // busca por ficha y bloquea el boton de buscar por enunciado
                    Response.Redirect(pagina);                
                
                    return;

                case 3:
                    // ficha + enunciado

                    // ofertas de valor de compra del ejercicio enviado

                    Session["Nombre_Adjunto_Adjunto"] = lPOL.armadoNombreEnvioAdjunto(Convert.ToString(Session["Variable_ID_Usuario"])) + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs(Convert.ToString(Session["Nombre_Adjunto_Adjunto"]));

                    Session["Nombre_Enunciado_Math"] = lPOL.armadoNombreEnunciadoMATH(Convert.ToString(Session["Variable_ID_Usuario"]));
                    Session["Nombre_Enunciado_Clean"] = lPOL.armadoNombreEnunciadoClean(Convert.ToString(Session["Variable_ID_Usuario"]));
                    lPOL.archivoCrearEnunciado(Contenido_Wiris.Value, Convert.ToString(Session["Variable_ID_Usuario"]));
                    enunciado = lPOL.corregirEnunciadoProfesor(Contenido_Wiris.Value); // corregir el enunciado

                    enunciado_1 = lPOL.logicaEnunciadosAl25(enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    enunciado_2 = lPOL.logicaEnunciadosAl25(enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                                        
                    lPOL.archivoCrearFicha(TxtTema.Text, TxtMateria.Text, TxtProfesor.Text, TxtColegio.Text, TxtAno.Text, Convert.ToString(Session["Variable_ID_Usuario"]));                    
                    Session["Nombre_Adjunto_Ficha"] = lPOL.armadoNombreEnvioFicha(Convert.ToString(Session["Variable_ID_Usuario"]));    
                    
                    pagina = "RespuestasFichas.aspx?Tema=" + TxtTema.Text + "&Materia=" + TxtMateria.Text + "&Maestro=" + TxtProfesor.Text + "&Colegio=" + TxtColegio.Text + "&Ano=" + TxtAno.Text + "&Boton_Enunciado=true&Boton_Ficha=true&Enunciado1=" + enunciado_1 + "&Enunciado2=" + enunciado_2 + "&Caso=3"; // busca por ficha y bloquea el boton de buscar por enunciado
                    Response.Redirect(pagina);  

                    return;

                case 4:
                    // solo envio adjunto

                    
                    int? respuesta = cEVDL.activacionOfertas(2);

                        switch (respuesta)
                        {
                            case 0:
                                valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?0";
                                break;
                            case 1:
                                valorAlfanumerico = cEVDL.oferta2x1(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 2:
                                valorAlfanumerico = cEVDL.oferta2x1Explicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 3:
                                valorAlfanumerico = cEVDL.ofertaGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]));
                                break;
                            case 4:
                                valorAlfanumerico = cEVDL.oferta2DescuentoExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 6:
                                valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?" + cEDL.ofertaAumentoCompra(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2).ToString();
                                break;
                            case 7:
                                valorAlfanumerico = cEVDL.compraSinOferta(2).ToString() + "?7?35";
                                break;
                            case 8:
                                valorAlfanumerico = cEVDL.ofertaDescuentoExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;
                            case 12:
                                valorAlfanumerico = cEVDL.ofertaExplicacionGratis(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                                break;

                        }

                        if (respuesta == 5)
                        {
                            cEVDL.ofertaHabitue(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        string[] dato = new string[2];
                        dato = valorAlfanumerico.Split('?');
                        bool? error = cEVDL.permitirComprarExplicacion(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Convert.ToDecimal(dato[0].Replace(".", ",")));
                        if (error == false)
                        {
                            // cartelito no tenes plata
                            return;
                        }
                        error = cEVDL.compraExplicacionDataList(Convert.ToInt32(Session["Variable_ID_Usuario"]), Convert.ToInt16(Session["ID_Ejercicio"]), Convert.ToDecimal(dato[0].Replace(".", ",")), 2, Convert.ToInt16(dato[1]), Convert.ToInt16(dato[2]));

                        if (respuesta == 7)
                        {
                            cEVDL.ofertaAumentoCompras(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2);
                        }
                        if (error == true) // carga en el disco c y en la tabla los adjuntos
                        {
                            Session["Nombre_Adjunto_Adjunto"] = lPOL.armadoNombreEnvioAdjunto(Convert.ToString(Session["Variable_ID_Usuario"])) + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                            Subir_Adjunto.PostedFile.SaveAs(Convert.ToString(Session["Nombre_Adjunto_Adjunto"]));
                            pOL.cargarTablaEjercicioVideosPedidos(Convert.ToUInt16(Session["Variable_ID_Usuario"]), null, null, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Substring(11, Convert.ToString(Session["Nombre_Adjunto_Adjunto"]).Length - 11));
                            lPOL.avisoAdjuntoSoloEnviado(Convert.ToString(Session["Name_Usuario"]));
                            // cartelito ejercicio comprado
                            return;
                        }

                        return;
                    
                case 5:
                    // enunciado

                    // ofertas de valor de compra del ejercicio enviado
                                        
                    Session["Nombre_Enunciado_Math"] = lPOL.armadoNombreEnunciadoMATH(Convert.ToString(Session["Variable_ID_Usuario"]));
                    Session["Nombre_Enunciado_Clean"] = lPOL.armadoNombreEnunciadoClean(Convert.ToString(Session["Variable_ID_Usuario"]));
                    lPOL.archivoCrearEnunciado(Contenido_Wiris.Value, Convert.ToString(Session["Variable_ID_Usuario"]));

                    enunciado = lPOL.corregirEnunciadoProfesor(Contenido_Wiris.Value); // corregir el enunciado

                    enunciado_1 = lPOL.logicaEnunciadosAl25(enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    enunciado_2 = lPOL.logicaEnunciadosAl25(enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                                        
                    pagina = "RespuestasEnunciado.aspx?Boton_Enunciado=false&Boton_Ficha=false&Enunciado1=" + enunciado_1 + "&Enunciado2=" + enunciado_2 + "&Caso=5"; // busca por ficha y bloquea el boton de buscar por enunciado
                    Response.Redirect(pagina);  
                  
                    //esto va e la pagina enunciado
                   // pOL.cargarTablaEjercicioVideosPedidosEjercicio(Convert.ToUInt16(Session["Variable_ID_Usuario"]), null, Convert.ToString(Session["Nombre_Enunciado_Math"]).Substring(11, Convert.ToString(Session["Nombre_Enunciado_Math"]).Length - 11), null);
                   // lPOL.avisoEnunciadoEnviado(Convert.ToString(Session["Name_Usuario"]));
                    
                    return;

                case 6:
                    // ficha + enunciado solo

                    // ofertas de valor de compra del ejercicio enviado

                    Session["Nombre_Enunciado_Math"] = lPOL.armadoNombreEnunciadoMATH(Convert.ToString(Session["Variable_ID_Usuario"]));
                    Session["Nombre_Enunciado_Clean"] = lPOL.armadoNombreEnunciadoClean(Convert.ToString(Session["Variable_ID_Usuario"]));
                    lPOL.archivoCrearEnunciado(Contenido_Wiris.Value, Convert.ToString(Session["Variable_ID_Usuario"]));
                    enunciado = lPOL.corregirEnunciadoProfesor(Contenido_Wiris.Value); // corregir el enunciado

                    enunciado_1 = lPOL.logicaEnunciadosAl25(enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    enunciado_2 = lPOL.logicaEnunciadosAl25(enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                                        
                    lPOL.archivoCrearFicha(TxtTema.Text, TxtMateria.Text, TxtProfesor.Text, TxtColegio.Text, TxtAno.Text, Convert.ToString(Session["Variable_ID_Usuario"]));                    
                    Session["Nombre_Adjunto_Ficha"] = lPOL.armadoNombreEnvioFicha(Convert.ToString(Session["Variable_ID_Usuario"]));    
                    
                    pagina = "RespuestasFichas.aspx?Tema=" + TxtTema.Text + "&Materia=" + TxtMateria.Text + "&Maestro=" + TxtProfesor.Text + "&Colegio=" + TxtColegio.Text + "&Ano=" + TxtAno.Text + "&Boton_Enunciado=true&Boton_Ficha=true&Enunciado1=" + enunciado_1 + "&Enunciado2=" + enunciado_2 + "&Caso=6"; // busca por ficha y bloquea el boton de buscar por enunciado
                    Response.Redirect(pagina);  
                                       
                    return;
                       
            }
        
        
        
        }









    }
}