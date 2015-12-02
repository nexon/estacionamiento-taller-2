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
            RegexUtilities util = new RegexUtilities();
            List<string> mensajes = new List<string>();
            string contraseña = Codificar.getHashSha256(user.Contraseña);
            if (ModelState.IsValid)
            {
                if (user.IniciarSesion(user.Email, contraseña))
                {
                    Personal personal = new Personal();
                    personal.Seleccionar(user);
                    List<Models.Estacionamiento> estacionamientos = personal.EstacionamientoAsociados();
                    if (estacionamientos.Any())
                    {
                        SessionManager.ModificarUsuarioAutenticado(user);
                        SessionManager.ModificarEstacionamientoSeleccionado(estacionamientos[0]);
                        return RedirectToAction("Index", "Home");
                    }
                    //redirect to another view
                    else
                    {
                        mensajes.Add("Su cuenta de usuario no tiene estacionamientos asociados");
                    }
                }
                else
                {
                    mensajes.Add("Usuario o contraseña incorrectos.");                    
                }
            }
            if (!util.IsValidEmail(user.Email))
            {
                mensajes.Add("Email no tiene el formato correcto.");
            }
            TempData["mensajeIndex"] = mensajes;
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
        public ActionResult Editar(Usuario usuarioEditado, string contraseñaActual, string passNueva1, string passNueva2)
        {
            List<string> validaciones = new List<string>();
            Usuario usuarioLogueado = SessionManager.UsuarioAutenticado();
            usuarioEditado.Contraseña = contraseñaActual;
            usuarioEditado.Contraseña= Codificar.getHashSha256(usuarioEditado.Contraseña);
            usuarioEditado.Rut = usuarioLogueado.Rut;
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
            SessionManager.ModificarUsuarioAutenticado(null);
            return RedirectToAction("Index", "PublicHome");
        }
        
        public ActionResult SeleccionarEstacionamiento(int ID)
        {
            if (SessionManager.UsuarioAutenticado() != null)
            {
                Personal personal = new Personal();
                personal.Seleccionar(SessionManager.UsuarioAutenticado());
                List<Models.Estacionamiento> estacionamientos = personal.EstacionamientoAsociados();
                var estacionamiento = new Estacionamiento.Models.Estacionamiento();
                estacionamiento.Seleccionar(ID);
                bool existe = false;
                foreach(var esta in estacionamientos){
                    if(esta.ID == estacionamiento.ID)
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    SessionManager.ModificarEstacionamientoSeleccionado(estacionamiento);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Registro(Usuario user, string nuevaPass, string nuevaPass2)
        {
            Usuario test = new Usuario();
            RegexUtilities util = new RegexUtilities();
            List<string> mensajes = new List<string>();
            if (test.Seleccionar(user.Rut))
            {
                mensajes.Add("Rut " + user.Rut + " ya está en uso.");
            }
            if(test.Seleccionar(user.Email))
            {
                mensajes.Add("Email " + user.Email + " ya está en uso.");
            }
            if (!string.IsNullOrEmpty(user.Email) && !util.IsValidEmail(user.Email))
            {
                mensajes.Add("Email no tiene el formato correcto.");
            }
            if (!nuevaPass.Equals(nuevaPass2))
            {
                mensajes.Add("Las contraseñas no son iguales.");
            }
            if (user.Telefono != 0 && user.Telefono.ToString().Count() < 6)
            {
                mensajes.Add("Número de teléfono muy corto");
            }
            if (user.Rut.ToString().Count() < 6 || user.Rut < 0)//debe tener 6 dígitos y no ser negativo
            {
                mensajes.Add("Rut inválido");
            }
            if (user.Nombre.Count() < 3)
            {
                mensajes.Add("Nombre demasiado corto");
            }
            if (!mensajes.Any())
            {
                mensajes.Add("Cuenta creada con éxito.");
                TempData["successMensaje"] = mensajes;
                user.Contraseña = Codificar.getHashSha256(nuevaPass);
                user.Agregar();
                return RedirectToAction("Index", "PublicHome");
            }
            TempData["mensajeIndex"] = mensajes;
            return RedirectToAction("Index", "PublicHome");
        }

        [HttpPost]
        public ActionResult ExisteEmail(string email)
        {
            Usuario usuarioLogueado = SessionManager.UsuarioAutenticado();
            usuarioLogueado.GetType();

            if(usuarioLogueado.Email != email && new Usuario().Seleccionar(email) )
            {
                return Json(new { existe = true });
            }

            return Json(new { existe = false});
        }

        [HttpPost]
        public ActionResult VerificarContraseña(string contraseña)
        {
            if (contraseña == null)
            {
                return Json( new { valida = false });
            }
            string email = SessionManager.UsuarioAutenticado().Email;
            contraseña = Codificar.getHashSha256(contraseña);

            return Json(new { valida = new Usuario().IniciarSesion(email, contraseña) });

        }
    }
}
