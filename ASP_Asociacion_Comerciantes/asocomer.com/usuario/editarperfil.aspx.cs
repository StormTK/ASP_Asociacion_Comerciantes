using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com.usuario
{
    public partial class editarperfil : System.Web.UI.Page
    {
        codigo.Usuario DatosUsuario = new codigo.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Email(int Usuario)
        {
            return DatosUsuario.EmailUsuario(Usuario);
        }

        public String Password(int Usuario)
        {
            return DatosUsuario.ContraseñaUsuario(Usuario);
        }

        public String Nombre(int Usuario)
        {
            return DatosUsuario.NombreUsuario(Usuario);
        }

        public String Apellido(int Usuario)
        {
            return DatosUsuario.ApellidoUsuario(Usuario);
        }
    }
}