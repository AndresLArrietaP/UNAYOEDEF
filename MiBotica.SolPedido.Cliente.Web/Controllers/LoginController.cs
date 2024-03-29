﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.Utiles.Helpers;
using System.Web.Security;
using MiBotica.SolPedido.Entidades;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Entidades.Base;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class LoginController : BaseLN
    {
        // GET: Login
        public ActionResult Index()
        {
            Usuario u = new Usuario();
            return View(u);
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrEmpty(usuario.Clave))
            {
                //Log.Info("Llego usuario: " + usuario.CodUsuario);
                ModelState.AddModelError("*", "Debe llenar el usuario o clave");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    usuario.ClaveE = EncriptacionHelper.EncriptarByte(usuario.Clave);

                    Usuario res = new UsuarioLN().BuscarUsuarioOpcion(usuario);
                    DSistema DSistema = new ServicioLN().BuscarDatos();

                    if (res != null && res.IdPersona > 0)  //las credenciales son correctas
                    {
                        //Llenar una cookie
                        FormsAuthentication.SetAuthCookie(res.Correo, true);
                        //llenar una sesion
                        List<Opcion> lista = new OpcionLN().ListaOpciones();
                        //para separar los controles de las acciones en la tabla de Opciones.
                        ParsearAcciones(lista);
                        VariablesWeb.gOpciones = lista;
                        Log.Info("Llego las opciones. " + VariablesWeb.gOpciones.Count().ToString());
                        VariablesWeb.gUsuario = res;
                        VariablesWeb.gDatosS = DSistema;
                        switch (res.IdTipPer)
                        {
                            case 1:
                                return RedirectToAction("IndexAdmin", "Servicio");
                                
                            case 2:
                                return RedirectToAction("IndexEUNAYOE", "Servicio");
                                
                            case 3:
                                return RedirectToAction("IndexEUB", "Servicio");
                            case 4:
                                return RedirectToAction("IndexSUB", "Servicio");
                            case 5:
                                return RedirectToAction("Index", "Home");
                            case 6:
                                return RedirectToAction("Index", "Home");
                        }                       
                    }
                    else
                    {
                        ModelState.AddModelError("*", "Usuario / Clave no validos");
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("*", ex.Message);
                }
            }


            return View(usuario);
        }
            [NonAction]
            private void ParsearAcciones(List<Opcion> lista)
            {

                int cantidad = 0;
                foreach (Opcion item in lista)
                {
                    if (!string.IsNullOrEmpty(item.UrlOpcion))
                    {
                        cantidad = item.UrlOpcion.Split('/').Count();
                        switch (cantidad)
                        {
                            case 3:
                                item.Area = item.UrlOpcion.Split('/')[0];
                                item.Controladora = item.UrlOpcion.Split('/')[1];
                                item.Accion = item.UrlOpcion.Split('/')[2];
                                break;
                            case 2:
                                item.Controladora = item.UrlOpcion.Split('/')[0];
                                item.Accion = item.UrlOpcion.Split('/')[1];
                                break;
                            case 1:
                                item.Controladora = item.UrlOpcion.Split('/')[0];
                                item.Accion = "Index";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}