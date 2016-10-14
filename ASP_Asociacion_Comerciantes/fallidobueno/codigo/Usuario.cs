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
        //SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
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
            }
            return false;
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

        public String[] GuardarUsuario(String Email)
        {
            String stg_sql = "Select * from Usuario WHERE correo = @Email";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Email;
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

        public String PerfilUsuario(int idusuario, int idusuariovisitante)
        {
            String stg_sql = "Select * from Usuario WHERE idUsuario = @idUsuario";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idusuario;
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                String correo = (resultado["correo"].ToString());
                String nombre = (resultado["nombre"].ToString());
                String apellido = (resultado["apellido"].ToString());
                int rol = Convert.ToInt32(resultado["rol"].ToString());
                String sexo = resultado["sexo"].ToString();
                String telefono = (resultado["telefono"].ToString());

                String html = "<div class=\"cabecerausuario\"><div class=\"perfil\">";
                if (sexo.Equals("1") || sexo.Equals("true") || sexo.Equals("True"))
                {
                    html += "<p class=\"icon-hombre2\"></p>";
                }
                if (sexo.Equals("0") || sexo.Equals("false") || sexo.Equals("False"))
                {
                    html += "<p class=\"icon-mujer2\"></p>";
                }
                html += " <h2 class=\"nombre\">" + nombre + " " + apellido + "</h2>";
                switch (rol)
                {
                    case 1:
                        html += "<h3 class=\"nombre\">Administrador</h3>";
                        break;
                    case 2:
                        html += "<h3 class=\"nombre\">Gerente</h3>";
                        break;
                    case 3:
                        html += "<h3 class=\"nombre\">Responsable de Abastecimiento</h3>";
                        break;
                    case 4:
                        html += "<h3 class=\"nombre\">Operario</h3>";
                        break;
                    case 5:
                        html += "<h3 class=\"nombre\">Asociado</h3>";
                        break;
                    case 6:
                        html += "<h3 class=\"nombre\">Socio</h3>";
                        break;
                }
                html += "</div ><div class=\"informacionUsuario\">";

                if (idusuario == idusuariovisitante)
                {
                    html += "<div class=\"botonesPerfil\"><a href = \"perfil.aspx?id=" + idusuario + "\" class=\"BotonPerfil\"><span class=\"icon-male-user\"></span>Ver Perfil</a><a href = \"editarperfil.aspx\" class=\"BotonPerfil\"><span class=\"icon-pencil\"></span>Editar Perfil</a><a href = \"userhistorial.aspx\" class=\"BotonPerfil\"><span class=\"icon-book\"></span>Ver Historial</a></div>";
                }

                html += "<h3>Informacion del Usuario</h3><div class=\"dato\"><p class=\"pregunta\">Correo: </p><p class=\"respuesta\" > " + correo + "</p> </div>";
                html += "<div class=\"dato\"><p class=\"pregunta\">Telefono: </p><p class=\"respuesta\" > " + telefono + "</p> </div></div>";
                Conexion.Close();
                return html;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return "<p class=\"invalido\">:c <br />Error 404<br />Usuario No Encontrado</p>";
        }

        public String PortadaUsuario(int idusuario)
        {
            String stg_sql = "Select * from Usuario WHERE idUsuario = @idUsuario";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idusuario;
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                String correo = (resultado["correo"].ToString());
                String nombre = (resultado["nombre"].ToString());
                String apellido = (resultado["apellido"].ToString());
                int rol = Convert.ToInt32(resultado["rol"].ToString());
                String sexo = resultado["sexo"].ToString();
                String telefono = (resultado["telefono"].ToString());

                String html = "<div class=\"cabecerausuario\"><div class=\"perfil\">";
                if (sexo.Equals("1") || sexo.Equals("true") || sexo.Equals("True"))
                {
                    html += "<p class=\"icon-hombre2\"></p>";
                }
                if (sexo.Equals("0") || sexo.Equals("false") || sexo.Equals("False"))
                {
                    html += "<p class=\"icon-mujer2\"></p>";
                }
                html += " <h2 class=\"nombre\">" + nombre + " " + apellido + "</h2>";
                switch (rol)
                {
                    case 1:
                        html += "<h3 class=\"nombre\">Administrador</h3>";
                        break;
                    case 2:
                        html += "<h3 class=\"nombre\">Gerente</h3>";
                        break;
                    case 3:
                        html += "<h3 class=\"nombre\">Responsable de Abastecimiento</h3>";
                        break;
                    case 4:
                        html += "<h3 class=\"nombre\">Operario</h3>";
                        break;
                    case 5:
                        html += "<h3 class=\"nombre\">Asociado</h3>";
                        break;
                    case 6:
                        html += "<h3 class=\"nombre\">Socio</h3>";
                        break;
                }
                html += "</div ><div class=\"informacionUsuario\"><div class=\"botonesPerfil\"><a href = \"perfil.aspx?id=" + idusuario + "\" class=\"BotonPerfil\"><span class=\"icon-male-user\"></span>VerPerfil</a><a href = \"editarperfil.aspx\" class=\"BotonPerfil\"><span class=\"icon-pencil\"></span>Editar Perfil</a><a href = \"userhistorial.aspx\" class=\"BotonPerfil\"><span class=\"icon-book\"></span>Ver Historial</a></div>";
                Conexion.Close();
                return html;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return "<p class=\"invalido\">:c <br />Error 404<br />Usuario No Encontrado</p>";
        }
    }
}