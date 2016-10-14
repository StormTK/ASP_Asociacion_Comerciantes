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
        String[] DatosUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        public void setNombreUsurio()
        {
            DatosUsuario = (String[])Session["Usuario"];
        }

        public String getNombreUsuario()
        {
            return DatosUsuario[2];
        }
    }
}