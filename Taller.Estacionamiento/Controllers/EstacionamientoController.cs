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
        public ActionResult Administrar(Taller.Estacionamiento.Models.Estacionamiento estacionamiento)
        {
            //Para la prueba de que ingresa en el estacionamiento.
            estacionamiento.ID = 1;
            return View("Administrar", estacionamiento);
        }

        public ActionResult AgregarSlot()
        {
            return View("AgregarSlot");
        }

        [HttpPost]
        public ActionResult AgregarSlot(Models.Espacio espacio, Models.Estacionamiento estacionamiento)
        {

            estacionamiento.AgregarEspacio(espacio);
            return RedirectToAction("Administrar", new { ID = estacionamiento.ID });
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
