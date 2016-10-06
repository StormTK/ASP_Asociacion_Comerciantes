using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.App.js
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){

        }

        protected void btn_Enviar(object sender,EventArgs e){
            String pass = txt_contraseña.Text;
            String email = txt_correo.Text; 
        }
    }