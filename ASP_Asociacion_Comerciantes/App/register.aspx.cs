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
        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Enviar_Click(object sender, EventArgs e){
            String email = txt_correo.Text;
            String pass = txt_contraseña.Text;
            String nombre = txt_nombre.Text;
            String apellido = txt_apellido.Text;
            String stg_sql = "INSERT INTO Usuario(correo, contraseña, nombre, apellido, Rol) VALUES (@Email, @Password, @Name, @Apellido, 6)";
            try
            { 
                Conexion.Open();
                SqlCommand com = new SqlCommand(stg_sql,Conexion);
                com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                com.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = nombre;
                com.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = apellido;
                com.ExecuteNonQuery();
            }
            catch (Exception ex){
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }

        public void Verificador_Contraseña(){

        }
    }
}