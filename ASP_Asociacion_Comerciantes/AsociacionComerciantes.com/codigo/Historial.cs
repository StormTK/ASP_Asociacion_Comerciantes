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
        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=ASOCIACIONCOMER;Integrated Security=True");
        public Boolean RegistrarHistorial(int idusuario)
        {
            String stg_sql = "INSERT INTO Historial(idHistorial, idusuario, descrip) Values(1, @idUsuario, 'Se Registro en la Aplicacion')";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idusuario;
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