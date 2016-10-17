using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com.usuario
{
    public partial class perfil : System.Web.UI.Page
    {
        codigo.Usuario PerfilUsuario = new codigo.Usuario();
        public String getNombreUsuario(int idUsuario)
        {
            return PerfilUsuario.NombreUsuario(idUsuario);
        } 

        public String getEmail(int idUsuario)
        {
            return PerfilUsuario.EmailUsuario(idUsuario);
        }

        public String getSexoUsuario(int idUsuario)
        {
            return PerfilUsuario.SexoUsuario(idUsuario);
        }

        public String getTelefono(int idUsuario)
        {
            return PerfilUsuario.TelefonoUsuario(idUsuario);
        }
    }
}