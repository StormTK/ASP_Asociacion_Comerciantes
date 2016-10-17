using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Asociacion_Comerciantes.asocomer.com.codigo
{
    public class Historial
    {
        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCOMER;Integrated Security=True");
        //SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=ASOCOMER;Integrated Security=True");

        public Boolean RegistrarHistorial(int idhistorial, int idusuario, String Registro)
        {
            String stg_sql = "INSERT INTO Historial(idHistorial, idusuario, descrip) Values(@idHistorial, @idUsuario, @Descripcion)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@idHistorial", idhistorial);
                cmd.Parameters.AddWithValue("@idUsuario", idusuario);
                cmd.Parameters.AddWithValue("@Descripcion", Registro);
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

        public String VerHistorial(int idUsuario)
        {
            String stg_sql = "Select idHistorial,fecha,descrip from Historial WHERE idusuario = @idUsuario ORDER BY idHistorial ASC";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                SqlDataReader resultado = cmd.ExecuteReader();
                String HTML = "<table><tr><th>No.</th><th>Fecha</th><th>Descripcion</th></tr>";
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