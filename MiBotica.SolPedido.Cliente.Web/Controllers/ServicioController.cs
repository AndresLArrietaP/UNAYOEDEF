using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;
using System.Web.Security;
using MiBotica.SolPedido.Entidades;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ServicioController : BaseLN
    {
        // REGISTRO INICIAL
        // GET: RegIni
        [HttpGet]
        public ActionResult NuevoSRI()
        {   
            Servicio nuevo = new Servicio();
            return View(nuevo);
        }
        // POST: RegIni
        [HttpPost]
        public ActionResult NuevoSRI(FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio nuevo = new Servicio();
            nuevo.NEstudiante = collection["NEstudiante"];
            nuevo.AEstudiante = collection["AEstudiante"];
            nuevo.dniEst = Convert.ToInt32(collection["dniEst"]);
            nuevo.RazonI = collection["RazonI"];
            nuevo.CodEst = collection["CodEst"];

            try
            {
                // TODO: Add insert logic here                
                /*usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);*/
                new ServicioLN().RegistrarServicio(nuevo);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        // VER SERVICIO T1
        // GET: Ver solis
        [HttpGet]
        public ActionResult VerSoli()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> servicios = new List<Servicio>();
            servicios = new ServicioLN().ListaServiciosT1();
            return View(servicios);
        }

        // GET: Servicio/Valida/..
        [HttpGet]
        public ActionResult Validar(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio validacion = new Servicio();
            validacion = new ServicioLN().BuscarServicio(id);
            //usuario.Clave = EncriptacionHelper.DecriptarString(usuario.ClaveE);
            return View(validacion);
        }
        // POST: Servicio/Valida/..
        [HttpPost]
        public ActionResult Validar(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio validacion = new Servicio();
            validacion.IdEstSer = Convert.ToInt32(collection["IdEstSer"]);
            try
            {
                // TODO: Add update logic here
                //usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);
                new ServicioLN().PasarT2(validacion, id);
                return RedirectToAction("VerSoli");
            }
            catch
            {
                return View();
            }
        }
        // VER SERVICIO T2
        // GET: Ver solis
        [HttpGet]
        public ActionResult VerDeri()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> serviciosd = new List<Servicio>();
            serviciosd = new ServicioLN().ListaServiciosT2();
            return View(serviciosd);
        }

        // GET: Servicio/Deriva/..
        [HttpGet]
        public ActionResult Derivar(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio derivacion = new Servicio();
            derivacion = new ServicioLN().BuscarServicio(id);
            return View(derivacion);
        }
        [HttpPost]
        public ActionResult Derivar(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio derivacion = new Servicio();
            derivacion.IdTipSer = Convert.ToInt32(collection["IdTipSer"]);
            try
            {
                // TODO: Add update logic here
                //usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);
                new ServicioLN().PasarT3(derivacion, id);
                return RedirectToAction("VerDeri");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult VerACita()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> serviciosacit = new List<Servicio>();
            serviciosacit = new ServicioLN().ListaServiciosT3();
            return View(serviciosacit);
        }

        [HttpGet]
        public ActionResult Programar(int id)
        {   //Listapsicologos
            //List<Usuario> psicologos = new List<Usuario>();
            //psicologos = new ServicioLN().ListaPsicologos();
            //ViewBag.psicologos = new SelectList(psicologos, "IdPersona", "Nombre");
            //Envia datos
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio programacion = new Servicio();
            programacion = new ServicioLN().BuscarServicio(id);
            return View(programacion);
        }
        [HttpPost]
        public ActionResult Programar(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio programado = new Servicio();
            programado.IdEmpleado = Convert.ToInt32(collection["IdEmpleado"]);
            programado.FechaCita = Convert.ToDateTime(collection["FechaCita"]);
            try
            {
                new ServicioLN().Programar(programado, id);
                return RedirectToAction("VerACita");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Citar(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio citar = new Servicio();
            citar = new ServicioLN().BuscarServicio(id);
            return View(citar);
        }

        [HttpPost]
        public ActionResult Citar(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                new ServicioLN().PasarT4(id);
                return RedirectToAction("VerACita");
            }
            catch
            {
                return View();
            }
        }
        //ATENCION POST CITA CON REGISTRO DE DIAGNOSTICO Y RECOMENDACIONES
        [HttpGet]
        public ActionResult AtenderPsi()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            int id = VariablesWeb.gUsuario.IdPersona;
            List<Servicio> atenderpsi = new List<Servicio>();
            atenderpsi = new ServicioLN().ListaServiciosT4PSI(id);
            return View(atenderpsi);
        }
        [HttpGet]
        public ActionResult AtenderSoci()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            int id = VariablesWeb.gUsuario.IdPersona;
            List<Servicio> atendersoci = new List<Servicio>();
            atendersoci = new ServicioLN().ListaServiciosT4SOCI(id);
            return View(atendersoci);
        }

        [HttpGet]
        public ActionResult RegistrarPsi(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio atencion = new Servicio();
            atencion = new ServicioLN().BuscarServicio(id);
            return View(atencion);
        }
        [HttpPost]
        public ActionResult RegistrarPsi(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio atencion = new Servicio();
            atencion.PreescripcionC = Convert.ToString(collection["PreescripcionC"]);
            atencion.Recomendacion = Convert.ToString(collection["Recomendacion"]);
            try
            {
                new ServicioLN().Atender(atencion, id);
                return RedirectToAction("AtenderPsi");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult RegistrarSoci(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio atencion = new Servicio();
            atencion = new ServicioLN().BuscarServicio(id);
            return View(atencion);
        }
        [HttpPost]
        public ActionResult RegistrarSoci(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio atencion = new Servicio();
            atencion.PreescripcionC = Convert.ToString(collection["PreescripcionC"]);
            atencion.Recomendacion = Convert.ToString(collection["Recomendacion"]);
            try
            {
                new ServicioLN().Atender(atencion, id);
                return RedirectToAction("AtenderSoci");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EnviarREPSI(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio resultado = new Servicio();
            resultado = new ServicioLN().BuscarServicio(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult EnviarREPSI(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                new ServicioLN().PasarT5(id);
                return RedirectToAction("AtenderPsi");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EnviarRESOCI(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio resultado = new Servicio();
            resultado = new ServicioLN().BuscarServicio(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult EnviarRESOCI(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                new ServicioLN().PasarT5(id);
                return RedirectToAction("AtenderSoci");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult VerResultados()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> serviciosaguar = new List<Servicio>();
            serviciosaguar = new ServicioLN().ListaServiciosT5();
            return View(serviciosaguar);
        }
        [HttpGet]
        public ActionResult GuardarR(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio guardado = new Servicio();
            guardado = new ServicioLN().BuscarServicio(id);
            return View(guardado);
        }
        [HttpPost]
        public ActionResult GuardarR(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                new ServicioLN().PasarT6(id);
                return RedirectToAction("VerResultados");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult VerCerrar()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> serviciosacerr = new List<Servicio>();
            serviciosacerr = new ServicioLN().ListaServiciosT6();
            return View(serviciosacerr);
        }
        [HttpGet]
        public ActionResult CerrarS(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Servicio cerrado = new Servicio();
            cerrado = new ServicioLN().BuscarServicio(id);
            return View(cerrado);
        }
        [HttpPost]
        public ActionResult CerrarS(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                new ServicioLN().PasarT7(id);
                return RedirectToAction("VerCerrar");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult VerServAll()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Servicio> serviciover = new List<Servicio>();
            serviciover = new ServicioLN().ListaServicioALL();
            return View(serviciover);
        }

        [HttpGet]
        public ActionResult VerCitaU()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            int id = VariablesWeb.gUsuario.IdPersona;
            List<Servicio> citasuser = new List<Servicio>();
            citasuser = new ServicioLN().ListaCitasU(id);
            return View(citasuser);
        }
        [HttpGet]
        public ActionResult VerServicioU()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            int id = VariablesWeb.gUsuario.IdPersona;
            List<Servicio> servuser = new List<Servicio>();
            servuser = new ServicioLN().ListaServsU(id);
            return View(servuser);
        }
        public ActionResult IndexAdmin()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            return View();
        }
        public ActionResult IndexEUNAYOE()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            return View();
        }
        public ActionResult IndexEUB()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            return View();
        }
        public ActionResult IndexSUB()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            return View();
        }
        public ActionResult IndexPsicologo()
        {
            return View();
        }
        public ActionResult IndexEstudiante()
        {
            return View();
        }
    }
}