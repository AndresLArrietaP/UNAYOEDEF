using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class ServicioDA
    {
        public void RegistrarServicio(Servicio servicio)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("dbo.RegistrarServicio", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", servicio.NEstudiante);
                    comando.Parameters.AddWithValue("@Apellido", servicio.AEstudiante);
                    comando.Parameters.AddWithValue("@DNI", servicio.dniEst);
                    comando.Parameters.AddWithValue("@Razon", servicio.RazonI);
                    comando.Parameters.AddWithValue("@Codigo", servicio.CodEst);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }

        }
    }
}
