using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                using (SqlCommand comando = new SqlCommand("RegistrarServicio", conexion))
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
        public List<Servicio> ListaServiciosT1()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT1", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);


                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }
        public Servicio LlenarEntidad(IDataReader reader)
        {
            Servicio servicio = new Servicio();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdServicio'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdServicio"]))
                    servicio.IdServicio = Convert.ToInt32(reader["IdServicio"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreE"]))
                    servicio.NEstudiante = Convert.ToString(reader["NombreE"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApellidoE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ApellidoE"]))
                    servicio.AEstudiante = Convert.ToString(reader["ApellidoE"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DNIE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["DNIE"]))
                    servicio.dniEst = Convert.ToInt32(reader["DNIE"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodigoE"]))
                    servicio.CodEst = Convert.ToString(reader["CodigoE"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["RazonE"]))
                {
                    servicio.RazonI = Convert.ToString(reader["RazonE"]);
                }
                // usuario.ClaveE  = reader["ClaveE"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaInicio'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["FechaInicio"]))
                    servicio.FechaInicio = Convert.ToDateTime(reader["FechaInicio"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCierre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["FechaCierre"]))
                    servicio.FechaCierre = Convert.ToDateTime(reader["FechaCierre"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdTipoServicio'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdTipoServicio"]))
                    servicio.IdTipSer = Convert.ToInt32(reader["IdTipoServicio"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoS'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["TipoS"]))
                    servicio.TipoS = Convert.ToString(reader["TipoS"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEstadoServicio'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdEstadoServicio"]))
                    servicio.IdEstSer = Convert.ToInt32(reader["IdEstadoServicio"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoS'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["EstadoS"]))
                    servicio.EstadoS = Convert.ToString(reader["EstadoS"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEstudiante'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdEstudiante"]))
                    servicio.IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]);
            }

            return servicio;

        }
    }
}
