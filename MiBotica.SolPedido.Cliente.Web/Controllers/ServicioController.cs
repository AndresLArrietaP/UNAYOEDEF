using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ServicioController : BaseLN
    {
        // GET: RegIni
        public ActionResult NuevoSRI()
        {
            Servicio nuevo = new Servicio();
            return View(nuevo);
        }
        // POST: RegIni
        [HttpPost]
        public ActionResult NuevoSRI(FormCollection collection)
        {
            Servicio nuevo = new Servicio();
            nuevo.NEstudiante = collection["NEstudiante"];
            nuevo.AEstudiante = collection["AEstudiante"];
            nuevo.dniEst = Convert.ToInt32(collection["dniEst"]);
            nuevo.RazonI= collection["RazonI"];
            nuevo.CodEst = collection["CodEst"];

            try
            {
                // TODO: Add insert logic here                
                /*usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);*/
                new ServicioLN().RegistrarServicio(nuevo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ver solis
        public ActionResult VerSoli()
        {
            List<Servicio> servicios = new List<Servicio>();
            servicios = new ServicioDA().ListaServiciosT1();
            return View(servicios);
        }
    }
}