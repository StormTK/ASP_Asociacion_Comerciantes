using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.usuario
{
    public partial class perfil : System.Web.UI.Page
    {
        codigo.Usuario mostrarUsuario = new codigo.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public String MostrarPerfil(int id, int idvisitante)
        {
            return mostrarUsuario.PerfilUsuario(id, idvisitante);
        }
    }
}