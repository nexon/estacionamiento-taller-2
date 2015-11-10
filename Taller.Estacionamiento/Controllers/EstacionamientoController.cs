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
            var est = new Models.Estacionamiento();
            if (est.Seleccionar(id))
            {
                return View(est);
            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult EditarInformacion()
        {
            return View("EditarInformacion");
        }
        public ActionResult Ocupados()
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento();
            ///////////ESTACIONAMIENTO DE PRUEBA///////////
            estacionamiento.ID = 1;
            List < Espacio > listaOcupados = estacionamiento.Ocupados();
            return View("Ocupados", listaOcupados);
        }
        public ActionResult Reservados(int id)
        {

            var estacionamiento = new Estacionamiento.Models.Estacionamiento { ID = id};
            return View(estacionamiento);
        }
        public ActionResult Libres(int id)
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento { ID = id };
            return View(estacionamiento);
        }

        public ActionResult Administrar(int ID)
        {
            var est = new Models.Estacionamiento();
            if (est.Seleccionar(ID))
            {
                return View("Administrar", est);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarSlot(int ID)
        {
            ViewData["ID"] = ID;
            return View("AgregarSlot");
        }

        [HttpPost]
        public ActionResult AgregarSlot(Models.Espacio espacio, int ID)
        {
                var est = new Models.Estacionamiento();
                if (est.Seleccionar(ID))
                {
                    if (est.SeleccionarEspacio(ID, espacio) || espacio.Codigo == null)
                    {
                        return RedirectToAction("AgregarSlot", new { ID = ID });
                    }
                    else
                    {
                        est.AgregarEspacio(espacio);
                        return RedirectToAction("Administrar", new { ID = ID });

                    }
                }
                else
                {
                    return RedirectToAction("AgregarSlot", new { ID = ID });
                }
                
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

        public ActionResult Personal(int id)
        {
            var estacionamiento = new Models.Estacionamiento();
            if (estacionamiento.Seleccionar(id))
            {
                List<Personal> listaPersonal = estacionamiento.Personal();
                ViewData["idEstacionamiento"] = id;

                //mostrar en la vista que no exiten personales en el estacionamiento
                if(listaPersonal.Count==0){

                }                                
                return View(listaPersonal);
            }
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult PersonalCrear(int id)
        {
            Personal nuevoPersonal = new Personal();
            ViewData["idEstacionamiento"] = id;         
            return PartialView(nuevoPersonal);
        }

        [HttpPost]
        public ActionResult PersonalCrear(int id, Personal personal)
        {
            var estacionamiento = new Models.Estacionamiento();

            if (estacionamiento.Seleccionar(id))
            {                
                List<Personal> listaPersonal =estacionamiento.Personal();
                Personal personalSeleccionado = new Personal();
                personalSeleccionado = listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);

                // se crea un nuevo personal, porque no existe un personal con el mismo Rut
                if (personalSeleccionado == null)
                {
                    // crear Usuario en la BD
                    Usuario usuario = (Usuario)personal ;
                    usuario.Contraseña = "";//la contraseña por el momento es vacia, no puede ser null
                    usuario.Agregar();

                    //crear Personal en la BD
                    int id_personal_insertado = personal.Agregar();

                    // crear personal-estacionamiento en la BD                    
                    personal.ID = id_personal_insertado;                 
                    estacionamiento.AgregarPersonal(personal);
                }
                // no se crea un nuevo personal
                else
                {
                    //mostar mensaje que ya existe un personal con ese Rut
                }                

            }
            return RedirectToAction("Personal", new { id = id });                     
        }

        public ActionResult PersonalEditar(int id)
        {
            Personal personal = new Personal();
            ViewData["idEstacionamiento"] = id;   
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
                    //actualizar atributos
                    personalSeleccionado.Nombre = personal.Nombre;
                    personalSeleccionado.Email = personal.Email;
                    personalSeleccionado.Telefono = personal.Telefono;

                    // modificar solo los datos de Usuario del Personal en la bd
                    Usuario usuario = (Usuario)personal;
                    usuario.Contraseña = "";//la contraseña por el momento es vacia, no puede ser null
                    usuario.Modificar();
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
                List<Personal> listaPersonal = estacionamiento.Personal();
                Personal personalSeleccionado = new Personal();
                personalSeleccionado = listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);

                // eliminar Personal con mismo Rut
                if (personalSeleccionado != null)
                {
                    estacionamiento.DesvincularPersonal(personal);                    
                }
            }
            return RedirectToAction("Personal", new { id = id });                  
        }

        public ActionResult Tarjetero()
        {
            return View("Tarjetero");
        }


    }
}
