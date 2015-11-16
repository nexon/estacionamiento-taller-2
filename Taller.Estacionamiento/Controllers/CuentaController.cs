using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller.Estacionamiento.Models;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Controllers
{
    public class CuentaController : Controller
    {
        //
        // GET: /Cuenta/

        public ActionResult Ingresar()
        {
            return View();
        }

        public ActionResult Salir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SeleccionarEstacionamiento(int ID)
        {
            if (SessionManager.UsuarioAutenticado() != null)
            {
                var estacionamiento = new Estacionamiento.Models.Estacionamiento { ID = ID };
                SessionManager.ModificarEstacionamientoSeleccionado(estacionamiento);
            }           
            return RedirectToAction("Index", "Home");
        }

    }
}
