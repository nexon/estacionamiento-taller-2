using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Utils
{
    public class SessionManager
    {
        /// <summary>
        /// Retorna el usuario que esta autentificado
        /// </summary>
        /// <returns>El usuario autentificado, null en caso contrario</returns>
        public static Models.Usuario UsuarioAutenticado()
        {
            var usuario = new Models.Usuario();
            if (HttpContext.Current.Session["USUARIO_AUTENTIFICADO"] != null)
            {
                usuario = (Models.Usuario)HttpContext.Current.Session["USUARIO_AUTENTIFICADO"];
            }
            else
            {
                usuario = null;
            }
            return usuario;
        }

        /// <summary>
        /// Establece el usuario autenticado en una variable de sesion
        /// </summary>
        /// <param name="usuario">El usuario que se quiere permanecer autentificado</param>
        public static void ModificarUsuarioAutenticado(Models.Usuario usuario)
        {
            if(usuario != null)
            {
                HttpContext.Current.Session.Add("USUARIO_AUTENTIFICADO", usuario);
            }
            else
            {
                HttpContext.Current.Session.Remove("USUARIO_AUTENTIFICADO");
            }
        }


        /// <summary>
        /// Retorna el estacionamiento que esta siendo usado por el usuario
        /// </summary>
        /// <returns>El estacionamiento en uso, null en caso contrario</returns>
        public static Models.Estacionamiento EstacionamientoSeleccionado()
        {
            var estacionamiento = new Models.Estacionamiento();
            if (HttpContext.Current.Session["ESTACIONAMIENTO_ID"] == null)
            {
                HttpContext.Current.Session.Add("ESTACIONAMIENTO_ID", 1);
            }
            
            if (HttpContext.Current.Session["ESTACIONAMIENTO_ID"] != null)
            {
                if(!estacionamiento.Seleccionar(Convert.ToInt32(HttpContext.Current.Session["ESTACIONAMIENTO_ID"])))
                {
                    estacionamiento = null;
                }
            }
            else
            {
                estacionamiento = null;
            }
            
            return estacionamiento;
        }

        /// <summary>
        /// Establece el estacionamiento en uso en una variable de sesion
        /// </summary>
        /// <param name="estacionamiento">El estacionamiento que se quiere permanecer en uso</param>
        public static void ModificarEstacionamientoSeleccionado(Models.Estacionamiento estacionamiento)
        {
            if (estacionamiento != null)
            {
                HttpContext.Current.Session.Add("ESTACIONAMIENTO_ID", estacionamiento.ID);
            }
            else
            {
                HttpContext.Current.Session.Remove("ESTACIONAMIENTO_ID");
            }
            
        }

        public static List<Models.Estacionamiento> Estacionamientos()
        {
            var estacionamientos = new List<Models.Estacionamiento>();
            var usu = UsuarioAutenticado();
            if (usu != null)
            {
                Models.Personal personal = new Models.Personal();
                personal.Rut = usu.Rut;
                personal.ID = personal.Buscar();
                estacionamientos = personal.Estacionamientos();
            }

            return estacionamientos;
        }
    }
}