using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller.Estacionamiento.Models;

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
        public ActionResult Informacion(int id)
        {
            string mensaje = TempData["mensajeNombreEditarInformacion"] as string;
            if (String.IsNullOrEmpty(mensaje))
            {
                mensaje = "";
            }
            var est = new Models.Estacionamiento();
            if (est.Seleccionar(id))
            {
                ViewData["mensajeNombreEditarInformacion"] = mensaje;
                return View(est);
            }
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult EstacionamientoEditar(int id)
        {
            Models.Estacionamiento estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(id);
            return PartialView(estacionamiento);
        }

        [HttpPost]
        public ActionResult EstacionamientoEditar(Models.Estacionamiento estacionamiento, String apertura, String cierre)
        {
            bool mostrarMensajeRequeridos = false;
            string mensaje = "Los siguientes campos son requeridos:";
            if(estacionamiento.Nombre == null){
                mostrarMensajeRequeridos = true;
                mensaje += " nombre,";
            }
            if (estacionamiento.Direccion == null)
            {
                mostrarMensajeRequeridos = true;
                mensaje += " dirección,";
            }
            if (estacionamiento.Email == null)
            {
                mostrarMensajeRequeridos = true;
                mensaje += " email,";
            }
            if(mostrarMensajeRequeridos){
                mensaje = mensaje.Substring(0, mensaje.Length-1);
                TempData["mensajeEditarInformacion"] = mensaje;
                return RedirectToAction("Informacion", new { ID = estacionamiento.ID });
            }
            string auxiliar = apertura + ":00";
            estacionamiento.Apertura = DateTime.Parse(auxiliar);
            auxiliar = cierre + ":00";
            estacionamiento.Cierre = DateTime.Parse(auxiliar);
            estacionamiento.Modificar(); 
            return RedirectToAction("Informacion", new { ID = estacionamiento.ID });
        }
        public ActionResult Ocupados(int ID)
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento { ID = ID };
            return View(estacionamiento);
        }
        public ActionResult Reservados(int ID)
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento { ID = ID };
            return View(estacionamiento);
        }
        public ActionResult Libres(int id)
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento();
            estacionamiento.Seleccionar(id);
            return View(estacionamiento);
        }

        public ActionResult Administrar(int id)
        {
            var estacionamiento = new Models.Estacionamiento();
            if (estacionamiento.Seleccionar(id))
            {
                List<Espacio> listaEspacios = estacionamiento.Todos();
                ViewData["idEstacionamiento"] = id;

                if (listaEspacios.Count == 0)
                {

                }
                return View(listaEspacios);
            }
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult AgregarSlot(int id)
        {
            Espacio nuevoespacio = new Espacio();
            ViewData["idEstacionamiento"] = id;
            return PartialView(nuevoespacio);
        }

        [HttpPost]
        public ActionResult AgregarSlot(int id, Espacio espacio)
        {

            var estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(id);
            estacionamiento.AgregarEspacio(espacio);
            return RedirectToAction("Administrar", new { id = id });
        }

        public ActionResult EditarSlot(int id)
        {
            Espacio espacio = new Espacio();
            ViewData["idEstacionamiento"] = id;
            return PartialView(espacio);
        }

        [HttpPost]
        public ActionResult EditarSlot(Models.Espacio espacio, int id)
        {
            var estacionamiento = new Models.Estacionamiento();

            if (estacionamiento.Seleccionar(id))
            {
                List<Espacio> listaespacio = estacionamiento.Todos();
                Espacio espacioSeleccionado = new Espacio();
                espacioSeleccionado = listaespacio.FirstOrDefault(x => x.Codigo == espacio.Codigo);


                if (espacioSeleccionado != null)
                {
                    //actualizar atributos
                    espacioSeleccionado.Estado = espacio.Estado;
                    if (espacio.Estado.Equals(EstadoEspacio.Ocupado))
                    {
                        estacionamiento.EstacionarVehiculo(espacio);
                    }
                    if (espacio.Estado.Equals(EstadoEspacio.Reservado))
                    {
                        estacionamiento.EstacionarVehiculo(espacio);
                    }
                    if (espacio.Estado.Equals(EstadoEspacio.Disponible))
                    {
                        estacionamiento.DespacharVehiculo(espacio);
                    }
                    if (espacio.Estado.Equals(EstadoEspacio.NoDisponible))
                    {
                        estacionamiento.EstacionarVehiculo(espacio);
                    }

                }
            }
            return RedirectToAction("Administrar", new { id = id });

        }
        public ActionResult EliminarSlot(int id)
        {
            Espacio espacio = new Espacio();
            ViewData["idEstacionamiento"] = id;
            return PartialView(espacio);
        }

        [HttpPost]
        public ActionResult EliminarSlot(Models.Espacio espacio, int id)
        {
            var estacionamiento = new Models.Estacionamiento();

            if (estacionamiento.Seleccionar(id))
            {
                List<Espacio> listaespacio = estacionamiento.Todos();
                Espacio espacios = new Espacio();
                espacios = listaespacio.FirstOrDefault(x => x.Codigo == espacio.Codigo);

                if (espacios != null)
                {
                    estacionamiento.EliminarEspacio(espacio);
                }
            }
            return RedirectToAction("Administrar", new { id = id });
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
        

        public ActionResult Personal(int id)
        {
            string mensaje = TempData["mensajeCrearPersonal"] as string;
            if (String.IsNullOrEmpty(mensaje))
            {
                mensaje = "";
            }

            var estacionamiento = new Models.Estacionamiento();
            if (estacionamiento.Seleccionar(id))
            {
                List<Personal> listaPersonalEstacionamiento = estacionamiento.Personal();
                ViewData["idEstacionamiento"] = id;
                ViewData["mensajeCrearPersonal"] = mensaje;
                return View(listaPersonalEstacionamiento);
            }
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult PersonalCrear(int id)
        {
            Personal nuevoPersonal = new Personal();

            //se crea una lista con todos los roles posibles para un personal
            List<SelectListItem> lista = new List<SelectListItem>();
            var listaRoles = nuevoPersonal.ErolEnumToList();
            int cont = 0;
            foreach (string erol in listaRoles)
            {
                lista.Add(new SelectListItem { Text = erol, Value = cont.ToString() });
                cont++;
            }

            ViewData["idEstacionamiento"] = id;
            ViewData["roles"] = lista;
            return PartialView(nuevoPersonal);
        }

        [HttpPost]
        public ActionResult PersonalCrear(int id, Personal personal)
        {
            var estacionamiento = new Models.Estacionamiento();
            string mensaje = "";
            if (estacionamiento.Seleccionar(id))
            {
                Usuario usuarioSeleccionado = new Usuario();
                usuarioSeleccionado.Email = personal.Email;
                bool usuario_existe = usuarioSeleccionado.Seleccionar(usuarioSeleccionado.Email);

                // se puede crear un nuevo Personal, porque existe un Usuario con el correo ingresado.
                if (usuario_existe)
                {
                    //crear Personal en la BD
                    personal.Rut = usuarioSeleccionado.Rut;
                    int personal_last_id_insertado = personal.Agregar();

                    //ya existe un Personal asociado a un Usuario con ese correo,
                    //entonces, solo se crea Personal_Estacionamiento
                    if (personal_last_id_insertado == 0)
                    {

                        //buscar id del Personal ya existente(con ese correo)
                        int personal_id = personal.Buscar();

                        // crear Personal_Estacionamiento en la BD                    
                        personal.ID = personal_id;
                        estacionamiento.AgregarPersonal(personal);

                    }
                    //no existe un Personal asociado a un Usuario con ese correo,                    
                    else
                    {
                        // crear Personal_Estacionamiento en la BD                    
                        personal.ID = personal_last_id_insertado;
                        estacionamiento.AgregarPersonal(personal);
                    }
                }
                // no se crea un nuevo Personal, porque no existe un Usuario con ese correo
                else
                {
                    //mostar mensaje que no existe un Usuario con ese correo
                    mensaje = "No se puede asociar el nuevo Personal al email ingresado";
                }

            }
            TempData["mensajeCrearPersonal"] = mensaje;
            return RedirectToAction("Personal", new { id = id });
        }

        public ActionResult PersonalEditar(int id)
        {
            Personal personal = new Personal();

            //se crea una lista con todos los roles posibles para un personal
            List<SelectListItem> lista = new List<SelectListItem>();
            var listaRoles = personal.ErolEnumToList();
            int cont = 0;
            foreach (string erol in listaRoles)
            {
                lista.Add(new SelectListItem { Text = erol, Value = cont.ToString() });
                cont++;
            }

            ViewData["idEstacionamiento"] = id;
            ViewData["roles"] = lista;
            return PartialView(personal);
        }

        [HttpPost]
        public ActionResult PersonalEditar(int id, Personal personal)
        {
            var estacionamiento = new Models.Estacionamiento();

            if (estacionamiento.Seleccionar(id))
            {
                List<Personal> listaPersonal = estacionamiento.Personal();
                Personal personalSeleccionado = new Personal();
                personalSeleccionado = listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);

                // modificar personal con mismo Rut
                if (personalSeleccionado != null)
                {                   
                    //buscar id del Personal 
                    int personal_id = personalSeleccionado.Buscar();
                    personalSeleccionado.ID = personal_id;
                    personalSeleccionado.Rol = personal.Rol;

                    // modifica el Rol de Personal_Estacionamiento                    
                    estacionamiento.ModificarPersonal(personalSeleccionado);
                }
            }
            return RedirectToAction("Personal", new { id = id });
        }

        public ActionResult PersonalEliminar(int id)
        {
            Personal personal = new Personal();
            ViewData["idEstacionamiento"] = id;
            return PartialView(personal);
        }

        [HttpPost]
        public ActionResult PersonalEliminar(int id, Personal personal)
        {
            var estacionamiento = new Models.Estacionamiento();

            if (estacionamiento.Seleccionar(id))
            {
                //se obtienen todos los personales que tiene el estacionamiento
                List<Personal> listaPersonal = estacionamiento.Personal();
                Personal personalSeleccionado = new Personal();
                personalSeleccionado = listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);

                // se desvincula el Personal(con ese Rut) del estacionamiento,
                // no se elimina el Personal, solo se desvincula del estacionamiento.
                if (personalSeleccionado != null)
                {
                    estacionamiento.DesvincularPersonal(personal);
                }
            }
            return RedirectToAction("Personal", new { id = id });
        }


        [HttpGet]
        public ActionResult Tarjetero(int id)
        {
            Models.Estacionamiento e = new Models.Estacionamiento();
            e.Seleccionar(id);
            List<Personal> free_personal = e.Personal();
            List<Personal> busy_personal = e.Tarjetero.PersonalTrabajando();
            free_personal.RemoveAll(c => busy_personal.Any(c2 => c2.ID == c.ID));
            Models.Tarjetero tarjetero = new Models.Tarjetero(e);
            IEnumerable<SelectListItem> items = new SelectList(free_personal, "ID", "Nombre");
            ViewData["PersonaSelectList"] = items;
            return View("Tarjetero", tarjetero);
        }

        [HttpPost]
        public ActionResult IngresoPersonal(RegistroPersonal rp)
        {
            rp.Estacionamiento.Tarjetero.RegistarIngreso(rp);
            return RedirectToAction("Tarjetero", rp.Estacionamiento);
        }

        [HttpPost]
        public ActionResult EstacionarVehiculo(Espacio espacio, int ID)
        {
            var estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(ID);
            espacio.IngresoVehiculo = DateTime.Now;
            estacionamiento.EstacionarVehiculo(espacio);

            return RedirectToAction("Libres", new { ID = estacionamiento.ID });
        }

        [HttpPost]
        public ActionResult DespacharVehiculo(Espacio espacio, int ID)
        {
            var estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(ID);

            espacio.SalidaVehiculo = DateTime.Now;

            int monto;
            int cant_minutos = (int)(espacio.SalidaVehiculo - espacio.IngresoVehiculo).TotalMinutes;
            if (cant_minutos <= estacionamiento.TiempoMinimo)
                monto = estacionamiento.TarifaMinuto * estacionamiento.TiempoMinimo;
            else
                monto = cant_minutos * estacionamiento.TarifaMinuto;

            estacionamiento.DespacharVehiculo(espacio);
            return RedirectToAction("Ocupados", new { ID = estacionamiento.ID });
        }


        [HttpPost]
        public ActionResult EliminarReserva(Models.Espacio espacio, int ID)
        {
            Models.Estacionamiento estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(ID);
            estacionamiento.EliminarReserva(espacio);

            return RedirectToAction("Reservados", new { id = estacionamiento.ID });
        }
    }
}
