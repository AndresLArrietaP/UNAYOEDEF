using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.Entidades.Core
{
    public class Servicio
    {
        //PK
        public int IdServicio { get; set; }
        //FK
        public int IdEstudiante = new Usuario().IdPersona;
        public int IdEmpleado = new Usuario().IdPersona;
        public int IdTipSer = new TipoServicio().IdTipoServicio;
        public int IdEstSer = new EstadoServicio().IdEstadoServicio;
        public int IdCita = new Cita().IdCita;
        //Usuario
        public string NEstudiante = new Usuario().Nombre;
        public string AEstudiante = new Usuario().Apellido;
        public int TEstudiante = new Usuario().IdTipPer;
        public string DEstudiante = new Usuario().Descripcion;
        public string NEmpleado = new Usuario().Nombre;
        public string AEmpleado = new Usuario().Apellido;
        public int TEmpleado = new Usuario().IdTipPer;
        public string DEmpleado = new Usuario().Descripcion;
        //TipoS
        public string TipoS = new TipoServicio().Descripcion;
        //EstadoS
        public string EstadoS = new EstadoServicio().Descripcion;
        //Cita
        public DateTime FechaCita = new Cita().FechaCita;
        //Extra
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public bool Estado { get; set; }
    }
}
