using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.Entidades.Core
{
    public class Cita
    {
        public int IdCita { get; set; }
        public string Preescripcion { get; set; }
        public string Recomendaciones { get; set; }
        public DateTime FechaCita{ get; set; }
        
    }
}
