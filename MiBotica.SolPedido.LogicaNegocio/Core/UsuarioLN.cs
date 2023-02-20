using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().InsertarUsuario(usuario);
            }
            catch   ( Exception) 
            {
                throw;
            }
        }


        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return new UsuarioDA().ListaUsuarios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModificarUsuario(Usuario usuario, int id)
        {
            try
            {
                new UsuarioDA().ModificarUsuario(usuario, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarUsuario(int id)
        {
            try
            {
                return new UsuarioDA().BuscarUsuario(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        public Usuario BuscarUsuarioOpcion(Usuario Usuario)
        {
            try
            {
                return new UsuarioDA().BuscarUsuarioOpcion(Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }


        public void EliminarUsuario(int id)
        {
            try
            {
                new UsuarioDA().EliminarUsuario(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
