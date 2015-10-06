using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taller.Estacionamiento.Controllers
{
    public class PublicHomeController : Controller
    {
        //
        // GET: /PublicHome/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Servicios()
        {
            return View("Servicios");
        }

        public ActionResult Empresa()
        {
            return View("Empresa");
        }

        public ActionResult Contacto()
        {
            return View("Contacto");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

    }
}
