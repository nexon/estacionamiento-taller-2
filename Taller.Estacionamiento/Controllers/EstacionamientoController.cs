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
        private static Models.Estacionamiento estacionamiento = new Models.Estacionamiento();


        //
        // GET: /Estacionamiento/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Informacion(int estacionamientoId)
        {
            var est = new Models.Estacionamiento();
            if (est.Seleccionar(estacionamientoId))
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
            return View("Ocupados");
        }
        public ActionResult Reservados()
        {
            return View("Reservados");
        }
        public ActionResult Libres()
        {
            var estacionamiento = new Estacionamiento.Models.Estacionamiento();
            List<Espacio> listaLibres = estacionamiento.Disponibles();

            return View(listaLibres);
        }
        public ActionResult Administrar(Taller.Estacionamiento.Models.Estacionamiento estacionamiento)
        {
            //Para la prueba de que ingresa en el estacionamiento.
            //estacionamiento.ID = 1;
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
            estacionamiento.ID = 1;            

            return View("Personal", estacionamiento.Personal() );
        }

        public PartialViewResult PersonalCrear()
        {
            Personal nuevoPersonal = new Personal();                        
            return PartialView(nuevoPersonal);
        }

        [HttpPost]
        public ActionResult PersonalCrear(Personal personal)
        {
            if (ModelState.IsValid)
            {
                Personal personalSeleccionado = new Personal();
                personalSeleccionado = estacionamiento.listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);
                
                // no existe un personal con el mismo Rut
                if(personalSeleccionado==null){
                    estacionamiento.listaPersonal.Add(personal);

                    //llamar a metodo de SP Personal_Agregar

                    return RedirectToAction("Personal", estacionamiento.listaPersonal); 
                }
                // no se crea un nuevo personal
                else{
                    //mostar mensaje que ya existe un personal con ese Rut

                }
                     
            }
            return RedirectToAction("Personal");  
                      
        }

        public ActionResult PersonalEditar()
        {
            Personal personal = new Personal();
            return PartialView(personal);
        }

        [HttpPost]
        public ActionResult PersonalEditar(Personal personal)
        {
            if (ModelState.IsValid)
            {
                Personal personalSeleccionado = new Personal();

                //obtener atributos      
                string nombre = personal.Nombre;
                string email = personal.Email;
                int telefono = personal.Telefono;

                //busqueda por el rut, porque es unico para cada usuario
                personalSeleccionado = estacionamiento.listaPersonal.FirstOrDefault(x => x.Rut == personal.Rut);

                //actualizar atributos
                personalSeleccionado.Nombre = nombre;
                personalSeleccionado.Email = email;
                personalSeleccionado.Telefono = telefono;

                //llamar a metodo de SP Personal_Editar

                return RedirectToAction("Personal", estacionamiento.listaPersonal);
            }
            return RedirectToAction("Personal");            
        }

        public ActionResult PersonalEliminar()
        {
            Personal personal = new Personal();
            return PartialView(personal);
        }

        [HttpPost]
        public ActionResult PersonalEliminar(Personal personal)
        {
            if (ModelState.IsValid)
            {
                Personal personalSeleccionado = estacionamiento.listaPersonal.Find(x => x.Rut == personal.Rut);
                estacionamiento.listaPersonal.Remove(personalSeleccionado);

                //llamar a metodo de SP Personal_Eliminar

                return RedirectToAction("Personal", estacionamiento.listaPersonal);
            }
            return RedirectToAction("Personal");            
        }

        public ActionResult Tarjetero()
        {
            return View("Tarjetero");
        }


    }
}
