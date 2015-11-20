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
        [HttpGet]
        public ActionResult Perfil()
        {
            Usuario user = SessionManager.UsuarioAutenticado();
            SessionManager.ModificarUsuarioAutenticado(user);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
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
