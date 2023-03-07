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
        public Servicio BuscarServicio(int id)
        {
            try
            {
                return new ServicioDA().BuscarServicio(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DSistema BuscarDatos()
        {
            try
            {
                return new ServicioDA().BuscarDatos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Servicio> ListaServiciosT1()
        {
            try
            {
                return new ServicioDA().ListaServiciosT1();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PasarT2(Servicio servicio, int id)
        {
            try
            {
                new ServicioDA().PasarT2(servicio, id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Servicio> ListaServiciosT2()
        {
            try
            {
                return new ServicioDA().ListaServiciosT2();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void PasarT3(Servicio servicio, int id)
        {
            try
            {
                new ServicioDA().PasarT3(servicio, id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Servicio> ListaServiciosT3()
        {
            try
            {
                return new ServicioDA().ListaServiciosT3();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Usuario> ListaPsicologos()
        {
            try
            {
                return new ServicioDA().ListaPsicologos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Programar(Servicio servicio, int id)
        {
            try
            {
                new ServicioDA().Programar(servicio, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PasarT4(int id)
        {
            try
            {
                new ServicioDA().PasarT4(id);
            }
            catch (Exception)
            {
                throw;


            }
        }

        public List<Servicio> ListaServiciosT4PSI(int id)
        {
            try
            {
                return new ServicioDA().ListaServiciosT4PSI(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Servicio> ListaServiciosT4SOCI(int id)
        {
            try
            {
                return new ServicioDA().ListaServiciosT4SOCI(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atender(Servicio servicio, int id)
        {
            try
            {
                new ServicioDA().Atender(servicio, id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void PasarT5(int id)
        {
            try
            {
                new ServicioDA().PasarT5(id);
            }
            catch (Exception)
            {
                throw;


            }
        }
        public List<Servicio> ListaServiciosT5()
        {
            try
            {
                return new ServicioDA().ListaServiciosT5();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void PasarT6(int id)
        {
            try
            {
                new ServicioDA().PasarT6(id);
            }
            catch (Exception)
            {
                throw;


            }
        }
        public List<Servicio> ListaServiciosT6()
        {
            try
            {
                return new ServicioDA().ListaServiciosT6();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void PasarT7(int id)
        {
            try
            {
                new ServicioDA().PasarT7(id);
            }
            catch (Exception)
            {
                throw;


            }
        }
        public List<Servicio> ListaServicioALL()
        {
            try
            {
                return new ServicioDA().ListaServicioALL();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Servicio> ListaCitasU(int id)
        {
            try
            {
                return new ServicioDA().ListaCitasU(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Servicio> ListaServsU(int id)
        {
            try
            {
                return new ServicioDA().ListaServsU(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
