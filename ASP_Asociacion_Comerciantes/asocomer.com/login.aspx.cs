using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com
{
    public partial class login : System.Web.UI.Page
    {
        codigo.Usuario Login_Usuario = new codigo.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            String Email = txt_correo.Text.ToUpper();
            String Password = txt_contraseña.Text;

            if (Login_Usuario.AutenticarUsuario(Email, Password) == true)
            {
                if (Session["Usuario"] == null)
                {
                    Session["Usuario"] = Login_Usuario.SesionUsuario(Email);
                    Response.Redirect("index.aspx",false);
                }
                else
                {
                    Session.Abandon();
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    Session["Usuario"] = Login_Usuario.SesionUsuario(Email);
                    Response.Redirect("index.aspx",false);
                }
            }
            else
            {
                Response.Redirect("login.aspx?msg=1",false);
            }
        }
    }
}