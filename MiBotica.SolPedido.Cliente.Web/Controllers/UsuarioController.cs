using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : BaseLN
    {
        // GET: Usuario
        public ActionResult Index()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios();
            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: Usuario/Create
        public ActionResult Create()
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            List<TipoUsuario> listarDescripcion = new List<TipoUsuario>();
            UsuarioDA usuarioDA = new UsuarioDA();
            listarDescripcion = usuarioDA.ListarDescripcion();

            ViewBag.ListarDescripcion = listarDescripcion;

            Usuario usuario = new Usuario();

            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Usuario usuario = new Usuario();
            usuario.Nombre = collection["Nombre"];
            usuario.Apellido = collection["Apellido"];
            usuario.Correo = collection["Correo"];
            usuario.Clave = collection["Clave"];
            usuario.IdTipPer =Convert.ToInt32(collection["IdTipPer"]);
            usuario.ndni= Convert.ToInt32(collection["nDNI"]);
            try
            {
                // TODO: Add insert logic here                
                usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);
                new UsuarioLN().InsertarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Usuario usuario = new Usuario();
            usuario = new UsuarioLN().BuscarUsuario(id);
            usuario.Clave = EncriptacionHelper.DecriptarString(usuario.ClaveE);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Usuario usuario = new Usuario();
            usuario.Nombre = collection["Nombre"];
            usuario.Apellido = collection["Apellido"];
            usuario.Correo = collection["Correo"];
            usuario.Clave = collection["Clave"];
            usuario.IdTipPer = Convert.ToInt32(collection["IdTipPer"]);
            usuario.ndni = Convert.ToInt32(collection["nDNI"]);
            //if (usuario.IdTipPer == 2|| usuario.IdTipPer == 3|| usuario.IdTipPer == 4|| usuario.IdTipPer == 5) {
            //    usuario.HoraI = collection["HoraI"];
            //    usuario.HoraS = collection["HoraS"];
            //    usuario.Dias = collection["Dias"];
            //    if (usuario.IdTipPer == 5) {
            //        usuario.Especialidad = collection["Especialidad"];
            //    }
            //}
            try
            {
                // TODO: Add update logic here
                usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);
                new UsuarioLN().ModificarUsuario(usuario, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            Usuario usuario = new Usuario();
            usuario = new UsuarioLN().BuscarUsuario(id);
            usuario.Clave = EncriptacionHelper.DecriptarString(usuario.ClaveE);
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //dat
            DSistema DSistema = new ServicioLN().BuscarDatos();
            VariablesWeb.gDatosS = DSistema;
            //dat
            try
            {
                // TODO: Add delete logic here
                //Usuario usuario = new Usuario();
                //usuario = new UsuarioLN().BuscarUsuario(id);
                new UsuarioLN().EliminarUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
