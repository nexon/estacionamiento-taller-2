using System.Collections.Generic;
using System.Linq;
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
            string contraseña = Codificar.getHashSha256(user.Contraseña);
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
        [HttpGet]
        public ActionResult Editar()
        {
            Usuario user = SessionManager.UsuarioAutenticado();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuarioEditado, string passNueva1, string passNueva2)
        {
            List<string> validaciones = new List<string>();
            Usuario usuarioLogueado = SessionManager.UsuarioAutenticado();
            usuarioEditado.Contraseña= Codificar.getHashSha256(usuarioEditado.Contraseña);
            if (string.IsNullOrEmpty(usuarioEditado.Contraseña) ||
                !usuarioLogueado.Contraseña.Equals(usuarioEditado.Contraseña))
            {
                validaciones.Add("Contraseña incorrecta");
            }
            if (!string.IsNullOrEmpty(passNueva1) && !string.IsNullOrEmpty(passNueva2) )
            {
                if(!passNueva1.Equals(passNueva2))
                {
                    validaciones.Add("Contraseñas nuevas no son iguales");
                }
                else
                {
                    usuarioEditado.Contraseña = Codificar.getHashSha256(passNueva1);//cambiar a SHA256
                }
            }
            if (validaciones.Any())
            {
                return View(usuarioLogueado);// + viewbag con errores a mostrar
            }
            //Rut existe
            //Email existe
            //Telefono corto
            usuarioLogueado = usuarioEditado;
            usuarioLogueado.Modificar();
            SessionManager.ModificarUsuarioAutenticado(usuarioLogueado);
            return RedirectToAction("Perfil","Cuenta");
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
        [HttpPost]
        public ActionResult Registro(Usuario user, string nuevaPass, string nuevaPass2)
        {
            if (!nuevaPass.Equals(nuevaPass2))
            {
                return RedirectToAction("Index", "PublicHome");
            }
            user.Contraseña = Codificar.getHashSha256(nuevaPass);
            user.Agregar();
            return RedirectToAction("Index", "PublicHome");
        }
        public ActionResult SeleccionarEstacionamiento()
        {
            return View();
        }
    }
}
