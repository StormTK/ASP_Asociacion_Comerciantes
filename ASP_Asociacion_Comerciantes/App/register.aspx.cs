using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASP_Asociacion_Comerciantes.App
{
    public partial class register : System.Web.UI.Page
    {
        //SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");
        SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Enviar_Click(object sender, EventArgs e){
            String email = txt_correo.Text;
            String pass = txt_contraseña.Text;
            String nombre = txt_nombre.Text;
            String apellido = txt_apellido.Text;

            if ( email.Equals("@")){//Verifica que el correo cumpla con las normas
                Response.Redirect("register.aspx?Error=1");
            }else if(email.Equals("") || pass.Equals("") || nombre.Equals("") || apellido.Equals("")){//Verifica que todos los campos estan llenos
                Response.Redirect("register.aspx?Error=2");
            }else if (pass.Length < 8){//Verifica si la contraseña es demasiado corta
                Response.Redirect("register.aspx?Error=3");
            }else if(Verificador_Contraseña(pass) == false){//Verifica si la contrasena cumple con las reglas
                Response.Redirect("register.aspx?Error=4");
            }else {
                RegistrarUsuario(email,pass,nombre,apellido);
            }
            
        }

        public Boolean Verificador_Contraseña(String Contraseña){
            bool mayusculas = Contraseña.Any(c => char.IsUpper(c));
            bool minusculas = Contraseña.Any(c => char.IsLower(c));
            bool numeros = Contraseña.Any(c => char.IsDigit(c));
            if (minusculas == true && mayusculas == true && numeros == true){
                return true;
            }else{
                return false;
            }
        }

        public void RegistrarUsuario(String email, String pass, String nombre, String apellido){
            String stg_sql = "INSERT INTO Usuario(correo, contraseña, nombre, apellido, Rol) VALUES (@Email, @Password, @Name, @Apellido, 6)";
            try
            {
                Conexion.Open();
                SqlCommand com = new SqlCommand(stg_sql, Conexion);
                com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                com.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = nombre;
                com.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = apellido;
                com.ExecuteNonQuery();
                Response.Redirect("login.aspx?conf=si");
            }
            catch (Exception ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }
    }
}