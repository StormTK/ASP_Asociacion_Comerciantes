using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com.usuario
{
    public partial class usuario : System.Web.UI.MasterPage
    {
        codigo.Usuario MostrarUsuario = new codigo.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        public String getPerfil(int idUsuario)
        {
            return MostrarUsuario.MostrarPerfil(idUsuario);
        }
    }
}