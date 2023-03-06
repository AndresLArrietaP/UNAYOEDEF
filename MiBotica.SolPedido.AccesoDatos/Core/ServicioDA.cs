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
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpleado'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdEmpleado"]))
                    servicio.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombre"]))
                    servicio.NEmpleado = Convert.ToString(reader["Nombre"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdCita'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdCita"]))
                    servicio.IdCita = Convert.ToInt32(reader["IdCita"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Preescripcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Preescripcion"]))
                    servicio.PreescripcionC = Convert.ToString(reader["Preescripcion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recomendacion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Recomendacion"]))
                    servicio.Recomendacion = Convert.ToString(reader["Recomendacion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaC'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["FechaC"]))
                    servicio.FechaCita = Convert.ToDateTime(reader["FechaC"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoC'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["TipoC"]))
                    servicio.TipoC = Convert.ToString(reader["TipoC"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ResultadoS'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ResultadoS"]))
                    servicio.Resultado = Convert.ToString(reader["ResultadoS"]);
            }

            return servicio;

        }
        public Cita LlenarEntidadC(IDataReader reader)
        {
            Cita cita = new Cita();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdCita'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdCita"]))
                    cita.IdCita = Convert.ToInt32(reader["IdCita"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Preescripcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Preescripcion"]))
                    cita.Preescripcion= Convert.ToString(reader["Preescripcion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recomendacion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Recomendacion"]))
                    cita.Recomendaciones = Convert.ToString(reader["Recomendacion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaC'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["FechaC"]))
                    cita.FechaCita = Convert.ToDateTime(reader["FechaC"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoE'";
            

            return cita;
        }
            public Usuario LlenarEntidadU(IDataReader reader)
        {
            Usuario usuario = new Usuario();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdPersona"]))
                    usuario.IdPersona = Convert.ToInt32(reader["IdPersona"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombre"]))
                    usuario.Nombre = Convert.ToString(reader["Nombre"]);
            }
            return usuario;
        }
        public Servicio BuscarServicio(int id)
        {
            Servicio sentidad = new Servicio();
            Servicio entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("BuscarServicio", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        sentidad = entidad;
                    }
                    //comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            return sentidad;
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
        public void PasarT2(Servicio servicio, int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT2", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    comando.Parameters.AddWithValue("@IdEstadoS", servicio.IdEstSer);
                    //comando.Parameters.AddWithValue("@HoraI", usuario.HoraI);
                    //comando.Parameters.AddWithValue("@HoraS", usuario.HoraS);
                    //comando.Parameters.AddWithValue("@Especialidad", usuario.Especialidad);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        public List<Servicio> ListaServiciosT2()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT2", conexion))

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

        public void PasarT3(Servicio servicio, int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT3", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    comando.Parameters.AddWithValue("@IdTipoS", servicio.IdTipSer);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public List<Servicio> ListaServiciosT3()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT3", conexion))

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
        public List<Usuario> ListaPsicologos()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("ExtraerPsicologos", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidadU(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        public void Programar(Servicio servicio, int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paProgramar", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    comando.Parameters.AddWithValue("@IdEmpleado", servicio.IdEmpleado);
                    comando.Parameters.AddWithValue("@FechaCita", servicio.FechaCita);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public void PasarT4(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT4", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public List<Servicio> ListaServiciosT4PSI(int id)
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT4PSI", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdEmpleado", id);
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

        public List<Servicio> ListaServiciosT4SOCI(int id)
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT4SOCI", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdEmpleado", id);
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

        public void Atender(Servicio servicio, int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paAtender", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    comando.Parameters.AddWithValue("@Preescripcion", servicio.PreescripcionC);
                    comando.Parameters.AddWithValue("@Recomendacion", servicio.Recomendacion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        public void PasarT5(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT5", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        public List<Servicio> ListaServiciosT5()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT5", conexion))

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
        public void PasarT6(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT6", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        public List<Servicio> ListaServiciosT6()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioT6", conexion))

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
        public void PasarT7(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paPasarT7", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdServicio", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        public List<Servicio> ListaServicioALL()
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServicioALL", conexion))

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
        public List<Servicio> ListaCitasU(int id)
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaCitasU", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
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
        public List<Servicio> ListaServsU(int id)
        {
            List<Servicio> listaEntidad = new List<Servicio>();
            Servicio entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListaServsU", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
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


    }
}
