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
        [HttpGet]
        public ActionResult Tarifas(int ID)
        {
            var estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(ID);

            return View(estacionamiento);
        }
        [HttpPost]
        public ActionResult Tarifas(Models.Estacionamiento estacionamiento)
        {
            var dbEstacionamiento = new Models.Estacionamiento();
            dbEstacionamiento.Seleccionar(estacionamiento.ID);
            dbEstacionamiento.TarifaMinuto = estacionamiento.TarifaMinuto;
            dbEstacionamiento.TiempoMinimo = estacionamiento.TiempoMinimo;
            dbEstacionamiento.Modificar();

            return RedirectToAction("Index", "Home");
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
