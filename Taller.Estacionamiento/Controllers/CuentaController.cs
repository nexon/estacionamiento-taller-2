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
        [HttpPost]
        public ActionResult Ingresar(Usuario user)
        {
            string contraseña = user.Contraseña;
            if (ModelState.IsValid)
            {
                if (user.IniciarSesion(user.Email, contraseña))
                {
                    SessionManager.ModificarUsuarioAutenticado(user);
                    //redirect to another view
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "PublicHome");
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
