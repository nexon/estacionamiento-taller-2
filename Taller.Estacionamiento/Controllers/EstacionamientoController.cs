using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taller.Estacionamiento.Controllers
{
    public class EstacionamientoController : Controller
    {
        //
        // GET: /Estacionamiento/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Informacion()
        {
            return View("Informacion");
        }
        public ActionResult Ocupados()
        {
            return View("Ocupados");
        }
        public ActionResult Reservados()
        {
            return View("Reservados");
        }
        public ActionResult Libres()
        {
            return View("Libres");
        }
        public ActionResult Administrar()
        {
            return View("Administrar");
        }

        public ActionResult Tarifas()
        {
            return View("Tarifas");
        }

        public ActionResult Promociones()
        {
            return View("Promociones");
        }
        public ActionResult Personal()
        {
            return View("Personal");
        }


    }
}
