using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.codigo
{
    public class Historial
    {
        //SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
        SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
        public Boolean RegistrarHistorial(int idhistorial, int idusuario, String Registro)
        {
            String stg_sql = "INSERT INTO Historial(idHistorial, idusuario, descrip) Values(@idHistorial, @idUsuario, @Descripcion)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idHistorial", SqlDbType.Int).Value = idhistorial;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idusuario;
                cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Registro;
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

        public int UltimaAccion(int idUsuario)
        {
            String stg_sql = "Select MAX(idHistorial) from Historial WHERE idusuario = @idusuario";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = idUsuario;
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

        public String verHistorial(int idUsuario)
        {
            String stg_sql = "Select idHistorial,fecha,descrip from Historial WHERE idusuario = @idUsuario ORDER BY idHistorial ASC";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = idUsuario;
                SqlDataReader resultado = cmd.ExecuteReader();
                String HTML = "<h3>Historial de Acciones del Usuario</h3><table><tr><th>No.</th><th>Fecha</th><th>Descripcion</th></tr>";
                while (resultado.Read())
                {
                    HTML += "<tr><td>" + resultado["idHistorial"].ToString() + "</td>";
                    HTML += "<td>" + resultado["fecha"].ToString() + "</td>";
                    HTML += "<td>" + resultado["descrip"].ToString() + "</td></tr>";
                }
                HTML += "</table></div>";
                Conexion.Close();
                return HTML;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return "<p class=\"invalido\">:c <br />Error 404<br />No se Mostrar el Historial de Usuario </p>";
        }
    }
}