using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class ServicioLN
    {
        public void RegistrarServicio(Servicio servicio)
        {
            try
            {
                new ServicioDA().RegistrarServicio(servicio);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
