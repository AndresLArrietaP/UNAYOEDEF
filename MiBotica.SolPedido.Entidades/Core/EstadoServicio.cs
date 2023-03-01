using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.Entidades.Core
{
    public class EstadoServicio
    {
        public int IdEstadoServicio { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
