using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com
{
    public partial class login : System.Web.UI.Page
    {
        codigo.Usuario usuario_login = new codigo.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btn_Login_Click(object sender, EventArgs e)
        {
            String Email = txt_correo.Text;
            String Password = txt_contraseña.Text;
            if(usuario_login.AutenticarUsuario(Email,Password) == true)
            {
                if(Session["Usuario"] == null)
                {
                    Session["Usuario"] = Email;
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx?Error=1");
            }
        }
    }
}