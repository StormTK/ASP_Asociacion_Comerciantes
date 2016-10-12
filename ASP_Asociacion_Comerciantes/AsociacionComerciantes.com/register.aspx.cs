using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com
{
    public partial class register : System.Web.UI.Page
    {
        codigo.Usuario registrar = new codigo.Usuario();
        codigo.Historial registrarEvento = new codigo.Historial();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btn_Enviar_Click(object sender, EventArgs e)
        {
            String Email = txt_correo.Text;
            String Password = txt_contraseña.Text;
            String Nombre = txt_nombre.Text;
            String Apellido = txt_apellido.Text;
            //bool Sexo = Convert.ToBoolean(OpcionSexo.Text);
                
            //registrar.RegistrarUsuario(Email, Password, Nombre, Apellido, Sexo);
            //int idUsuario = registrar.BuscarUsuarioEmail(Email);
            //registrarEvento.RegistrarHistorial(idUsuario);
        }

    }
}