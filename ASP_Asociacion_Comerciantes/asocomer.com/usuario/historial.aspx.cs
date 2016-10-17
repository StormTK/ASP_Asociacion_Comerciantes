using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com.usuario
{
    public partial class historial : System.Web.UI.Page
    {
        codigo.Historial HistorialUsuario = new codigo.Historial();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String MostrarHTMLHistorial(int idUsuario)
        {
            return HistorialUsuario.VerHistorial(idUsuario);
        }
    }
}