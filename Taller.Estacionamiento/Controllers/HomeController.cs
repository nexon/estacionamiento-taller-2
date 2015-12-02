using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (SessionManager.UsuarioAutenticado() != null)
            {
                return View();
            }
            return RedirectToAction("Index", "PublicHome");
        }

    }
}
