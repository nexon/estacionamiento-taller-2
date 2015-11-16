using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult SeleccionarEstacionamiento()
        {
            return View();
        }

    }
}
