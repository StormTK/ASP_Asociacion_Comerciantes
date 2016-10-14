using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Asociacion_Comerciantes.asocomer.com
{
    public partial class register : System.Web.UI.Page
    {
        codigo.Usuario RegistrarUsuario = new codigo.Usuario();
        codigo.Historial EventoRegistro = new codigo.Historial();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Enviar_Click(object sender, EventArgs e)
        {
            String Email = txt_correo.Text.ToUpper();
            String Password = txt_contraseña.Text;
            String Nombre = txt_nombre.Text;
            String Apellido = txt_apellido.Text;
            String Sexo = OpcionSexo.SelectedValue;

            if (Email.Equals("") || Email.Equals("@") || Password.Equals("") || Nombre.Equals("") || Apellido.Equals("") || Sexo.Equals(""))
            {
                Response.Redirect("register.aspx?error=1",false);
            }
            else
            {
                if (RegistrarUsuario.VerificarEmail(Email) == false)
                {
                    if (Password.Length >= 8)
                    {
                        if (VerificarContraseña(Password) == true)
                        {
                            Nombre = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower());
                            Apellido = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Apellido.ToLower());
                            Boolean blnSexo = Convert.ToBoolean(OpcionSexo.SelectedValue);
                            if (RegistrarUsuario.RegistrarUsuario(Email, Password, Nombre, Apellido, blnSexo) == true)
                            {
                                int idUsuario = RegistrarUsuario.BuscaridUsuario(Email);
                                if (idUsuario >= 1)
                                {
                                    if (EventoRegistro.RegistrarHistorial(1, idUsuario, "Se Registro en la Aplicacion Web.") == true)
                                    {
                                        Response.Redirect("login.aspx?msg=2",false);
                                    }
                                }
                                else
                                {
                                    Response.Redirect("register.aspx?error=6",false);
                                }
                            }
                            else
                            {
                                Response.Redirect("register.aspx?error=5",false);
                            }
                        }
                        else
                        {
                            Response.Redirect("register.aspx?error=4",false);
                        }

                    }
                    else
                    {
                        Response.Redirect("register.aspx?error=3",false);
                    }
                }
                else
                {
                    Response.Redirect("register.aspx?error=2",false);
                }
            }
        }

        public Boolean VerificarContraseña(String Contraseña)
        {
            bool mayusculas = Contraseña.Any(c => char.IsUpper(c));
            bool minusculas = Contraseña.Any(c => char.IsLower(c));
            bool numeros = Contraseña.Any(c => char.IsDigit(c));
            if (minusculas == true && mayusculas == true && numeros == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}