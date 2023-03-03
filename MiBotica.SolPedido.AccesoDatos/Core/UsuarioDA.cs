using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class UsuarioDA
    {
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))

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
        public Usuario LlenarEntidad(IDataReader reader)
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
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Apellido'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Apellido"]))
                    usuario.Apellido = Convert.ToString(reader["Apellido"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Correo"]))
                    usuario.Correo = Convert.ToString(reader["Correo"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Clave"]))
                    usuario.Clave = Convert.ToString(reader["Clave"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ClaveE'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ClaveE"])) { 
                    usuario.ClaveE = (byte[])reader["ClaveE"]; 
                }
                   // usuario.ClaveE  = reader["ClaveE"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Descripcion"]))
                    usuario.Descripcion = Convert.ToString(reader["Descripcion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Codigo"]))
                    usuario.Codigo = Convert.ToString(reader["Codigo"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nDNI'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["nDNI"]))
                    usuario.ndni = Convert.ToInt32(reader["nDNI"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Estado"]))
                    usuario.Estado = Convert.ToBoolean(reader["Estado"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HoraI'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["HoraI"]))
                    usuario.HoraI = Convert.ToString(reader["HoraI"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HoraS'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["HoraS"]))
                    usuario.HoraS = Convert.ToString(reader["HoraS"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dias'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Dias"]))
                    usuario.Dias = Convert.ToString(reader["Dias"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Especialidad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Especialidad"]))
                    usuario.Especialidad = Convert.ToString(reader["Especialidad"]);
            }

            return usuario;

        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@Correo", usuario.Correo);
                    comando.Parameters.AddWithValue("@ClaveE", usuario.ClaveE);
                    comando.Parameters.AddWithValue("@IdTipoPersona", usuario.IdTipPer);
                    comando.Parameters.AddWithValue("@DNI", usuario.ndni);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }

        }

        public void ModificarUsuario(Usuario usuario, int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_ModificarUsuario", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", id);
                    comando.Parameters.AddWithValue("@Clave", usuario.ClaveE);
                    comando.Parameters.AddWithValue("@Correo", usuario.Correo);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoPersona", usuario.IdTipPer);
                    comando.Parameters.AddWithValue("@DNI", usuario.ndni);
                    //comando.Parameters.AddWithValue("@HoraI", usuario.HoraI);
                    //comando.Parameters.AddWithValue("@HoraS", usuario.HoraS);
                    //comando.Parameters.AddWithValue("@Especialidad", usuario.Especialidad);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public Usuario BuscarUsuario(int id)
        {
            Usuario uentidad = new Usuario();
            Usuario entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBuscarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", id);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        uentidad = entidad;
                    }
                    //comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            return uentidad;
        }

        public Usuario BuscarUsuarioOpcion(Usuario usuario)
        {
            Usuario SegSSOMUsuario = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {

                using (SqlCommand comando = new SqlCommand("paUsuario_BuscaCodUserClave", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Clave", usuario.ClaveE);
                    comando.Parameters.AddWithValue("@Correo", usuario.Correo);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        SegSSOMUsuario = LlenarEntidad(reader);

                    }

                    conexion.Close();
                }
            }
            return SegSSOMUsuario;
        }
        public void EliminarUsuario(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paEliminarUsuario", conexion))
                {
                    //usuario = BuscarUsuario(id);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public List<TipoUsuario> ListarDescripcion()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            List<TipoUsuario> listado = new List<TipoUsuario>();
            try
            {
                conexion.Open();
                cmd = new SqlCommand("sp_ListarDescripcion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.IdTipoPersona = Convert.ToInt32(dr["ID"]);
                    tipoUsuario.Descripcion = dr["Descripcion"].ToString();
                    tipoUsuario.Estado = Convert.ToBoolean(dr["Estado"]);
                    tipoUsuario.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    listado.Add(tipoUsuario);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listado;
        }

    }
}
