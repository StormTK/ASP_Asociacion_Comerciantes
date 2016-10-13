using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.usuario
{
    public partial class userhistorial : System.Web.UI.Page
    {
        codigo.Usuario MostrarUsuario = new codigo.Usuario();
        codigo.Historial MostrarHistorial = new codigo.Historial();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String MostrarHistorialHTML(int iduser)
        {
            return MostrarUsuario.PortadaUsuario(iduser);
        }
    }
}