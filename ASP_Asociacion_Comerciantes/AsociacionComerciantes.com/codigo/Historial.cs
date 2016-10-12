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
        //SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");
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
    }
}