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
        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");

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

        public int BuscarUsuarioEmail(String Email)
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
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = Apellido;
                cmd.Parameters.Add("@Sexo", SqlDbType.Bit).Value = Sexo;
                cmd.ExecuteNonQuery();
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