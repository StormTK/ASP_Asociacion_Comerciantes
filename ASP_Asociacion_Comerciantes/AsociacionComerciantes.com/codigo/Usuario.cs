using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.codigo
{
    public class Usuario
    {
        //SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");
        SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=ASOCOMER;Integrated Security=True");

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

        public Boolean AutenticarUsuario(String Email, String Contraseña)
        {
            String stg_sql = "Select COUNT(*)FROM Usuario WHERE correo = @Email AND contraseña = @Password";
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
            }return false;
        }

        public Boolean VerificarExistenciaEmail(String Email)
        {
            String stg_sql = "Select COUNT(*)FROM Usuario WHERE correo = @Email";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Email", Email); //enviamos los parametros
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

        public int BuscaridUsuario_Email(String Email)
        {
            String stg_sql = "Select idUsuario from Usuario WHERE correo = @Email";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Email;
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                int id = Convert.ToInt32(resultado["idUsuario"].ToString());
                Conexion.Close();
                return id;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return 0;
        }

        public Boolean RegistrarUsuario(String Email, String Password, String Nombre, String Apellido, Boolean Sexo)
        {
            String stg_sql = "INSERT INTO Usuario(correo, contraseña, nombre, apellido, sexo, rol, estado) VALUES (@Email, @Password, @Name, @Apellido, @Sexo, 6 , 1)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Name", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Sexo", Sexo);
                cmd.ExecuteNonQuery();
                Conexion.Close();
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