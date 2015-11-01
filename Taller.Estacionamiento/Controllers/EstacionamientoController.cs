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
        public ActionResult Informacion(int estacionamientoId)
        {
            var est = new Models.Estacionamiento();
            est.Seleccionar(estacionamientoId);
            return View(est);
        }
        public ActionResult EditarInformacion()
        {
            return View("EditarInformacion");
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
        public ActionResult AgregarSlot()
        {
            return View("AgregarSlot");
        }
        public ActionResult EditarSlot()
        {
            return View("EditarSlot");
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
        public ActionResult Tarjetero()
        {
            return View("Tarjetero");
        }


    }
}
