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
            String Email = txt_correo.Text.ToUpper();
            String Password = txt_contraseña.Text;
            String Nombre = txt_nombre.Text;
            String Apellido = txt_apellido.Text;
            String Sexo = OpcionSexo.SelectedValue;
            
            if (Email.Equals("") || Email.Equals("@") || Password.Equals("") || Nombre.Equals("") || Apellido.Equals("") || Sexo.Equals(""))
            {
                Response.Redirect("register.aspx?Error=1");
            }
            else
            {
                if (registrar.VerificarExistenciaEmail(Email) == false)
                {
                    if (Password.Length >= 8)
                    {
                        if (registrar.VerificarContraseña(Password) == true)
                        {
                            Nombre = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower());
                            Apellido = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Apellido.ToLower());
                            Boolean blnSexo = Convert.ToBoolean(OpcionSexo.SelectedValue);
                            if (registrar.RegistrarUsuario(Email, Password, Nombre, Apellido, blnSexo) == true)
                            {
                                int idUsuario = registrar.BuscaridUsuario_Email(Email);
                                if (idUsuario >= 1)
                                {
                                    if(registrarEvento.RegistrarHistorial(1, idUsuario, "Se Registro en la Aplicacion Web.") == true)
                                    {
                                        Response.Redirect("login.aspx?msg=2");
                                    }
                                }
                                else
                                {
                                    Response.Redirect("register.aspx?Error=6");
                                }
                            }
                            else
                            {
                                Response.Redirect("register.aspx?Error=5");
                            }
                        }
                        else
                        {
                            Response.Redirect("register.aspx?Error=4");
                        }

                    }
                    else
                    {
                        Response.Redirect("register.aspx?Error=3");
                    }
                }
                else
                {
                    Response.Redirect("register.aspx?Error=2");
                }
            }

        }


    }
}