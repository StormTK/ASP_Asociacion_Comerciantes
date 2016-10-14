using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Asociacion_Comerciantes.asocomer.com.codigo
{
    public class Usuario
    {
        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
        //SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=ASOCOMER;Integrated Security=True");

        public Boolean AutenticarUsuario(String Email, String Contraseña)
        {
            String stg_sql = "SELECT COUNT(*)FROM Usuario WHERE correo = @Email AND contraseña = @Password";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Email", Email); //enviamos los parametros
                cmd.Parameters.AddWithValue("@Password", Contraseña);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada
                Conexion.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return false;
        }

    }
}