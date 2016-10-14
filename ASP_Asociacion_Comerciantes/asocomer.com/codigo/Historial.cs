using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Asociacion_Comerciantes.asocomer.com.codigo
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
    }
}