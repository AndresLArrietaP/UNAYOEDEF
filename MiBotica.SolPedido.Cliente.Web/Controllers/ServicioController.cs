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
        // GET: Servicio
        public ActionResult NuevoS()
        {
            Servicio nuevo = new Servicio();
            return View(nuevo);
        }
        // POST: Usuario/Create
        [HttpPost]
        public ActionResult NuevoS(FormCollection collection)
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
    }
}