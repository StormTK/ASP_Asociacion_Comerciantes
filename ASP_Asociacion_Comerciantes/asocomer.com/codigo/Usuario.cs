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

        public int BuscaridUsuario(String Email)
        {
            String stg_sql = "SELECT idUsuario FROM Usuario WHERE correo = @Email";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Email", Email);
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

        public String MostrarPerfil(int idUsuario)
        {
            String stg_sql = "SELECT nombre, apellido, rol, sexo FROM Usuario WHERE idUsuario = @idUsuario";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                String nombre = resultado["nombre"].ToString();
                String apellido = resultado["apellido"].ToString();
                int rol = Convert.ToInt32(resultado["rol"].ToString());
                String sexo = resultado["sexo"].ToString();
                Conexion.Close();

                String HTML_Perfil = "";
                if (sexo.Equals("1") || sexo.Equals("true") || sexo.Equals("True"))
                {
                    HTML_Perfil += "<p class=\"icon-hombre\"></p>";
                }
                if (sexo.Equals("0") || sexo.Equals("false") || sexo.Equals("False"))
                {
                    HTML_Perfil += "<p class=\"icon-mujer\"></p>";
                }
                HTML_Perfil += " <h2 class=\"nombre\">" + nombre + " " + apellido + "</h2>";
                switch (rol)
                {
                    case 1:
                        HTML_Perfil += "<h3 class=\"nombre\">Administrador</h3>";
                        break;
                    case 2:
                        HTML_Perfil += "<h3 class=\"nombre\">Gerente</h3>";
                        break;
                    case 3:
                        HTML_Perfil += "<h3 class=\"nombre\">Responsable de Abastecimiento</h3>";
                        break;
                    case 4:
                        HTML_Perfil += "<h3 class=\"nombre\">Operario</h3>";
                        break;
                    case 5:
                        HTML_Perfil += "<h3 class=\"nombre\">Asociado</h3>";
                        break;
                    case 6:
                        HTML_Perfil += "<h3 class=\"nombre\">Socio</h3>";
                        break;
                }

                return HTML_Perfil;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return "Error 404 - No se encontro Perfil";
        }

        public String[] SesionUsuario(String Email)
        {
            String stg_sql = "SELECT * FROM Usuario WHERE correo = @Email";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Email", Email);
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                String id = resultado["idUsuario"].ToString();
                String correo = resultado["correo"].ToString();
                String nombre = resultado["nombre"].ToString();
                String apellido = resultado["apellido"].ToString();
                String rol = resultado["rol"].ToString();
                String estado = resultado["estado"].ToString();
                String[] DatosUsuario = { id, correo, nombre, apellido, rol, estado };
                Conexion.Close();
                return DatosUsuario;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return null;
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

        public Boolean VerificarEmail(String Email)
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

    }
}