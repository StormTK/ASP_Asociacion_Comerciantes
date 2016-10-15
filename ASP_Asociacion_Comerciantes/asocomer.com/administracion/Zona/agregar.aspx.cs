using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ASP_Asociacion_Comerciantes.asocomer.com.administracion.Zona
{
    public partial class agregar : System.Web.UI.Page
    {
        codigo.Zona RegistrarZonas = new codigo.Zona();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarZona_Click(object sender, EventArgs e)
        {
            String Ruta = Server.MapPath("temp\\" + ArchivoZona.FileName);
            ArchivoZona.SaveAs(Ruta);
            int idzona_int = 0;
            int idzonas_int = 0;
            XmlDocument DocumentoZona = new XmlDocument();
            DocumentoZona.Load(Ruta);
            XmlNodeList categorias = DocumentoZona.GetElementsByTagName("ZONAS");
            XmlNodeList lista = ((XmlElement)categorias[0]).GetElementsByTagName("ZONA");
            
            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList idzona = nodo.GetElementsByTagName("no_zona");
                XmlNodeList nombre = nodo.GetElementsByTagName("nombre_zona");
                XmlNodeList zonasuperior = nodo.GetElementsByTagName("ZONA_no_zona_superior");
                try
                {
                    if (idzona != null)
                    {
                        idzona_int = Convert.ToInt32(idzona[i].InnerText);
                    }
                    if (nombre != null)
                    {
                        //idzona_int = Convert.ToInt32(idzona.ToString());
                    }
                    if (zonasuperior.Count > 0)
                    {
                        idzonas_int = Convert.ToInt32(zonasuperior[i].InnerText);
                        RegistrarZonas.RegistrarZona(idzona_int, nombre[i].InnerText, idzonas_int);
                    }
                    else
                    {
                        RegistrarZonas.RegistrarZona(idzona_int, nombre[i].InnerText);
                    }
                }catch(Exception error)
                {
                    Response.Write("Ocurrio un Error:" + error);
                }
                //aqui iria la insercion a la base de datos
                i++;
            }
            System.IO.File.Delete(@Ruta);
            Response.Write("Se Agregaron las Zonas Con Exito");
        }
        /*
        
        */


    }
}