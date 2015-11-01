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

        static int cont_personal = 0;//despues se elimina, es solo para probar la vista personal


        //
        // GET: /Estacionamiento/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Informacion()
        {
            return View("Informacion");
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
            return View("Libres");
        }
        public ActionResult Administrar()
        {
            return View("Administrar");
        }
        public ActionResult AgregarSlot()
        {
            return View("AgregarSlot");
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
            //solo para probar la vista, se cargan datos al comienzo
            if (cont_personal == 0)
            {
                Personal p1 = new Personal(); p1.Nombre = "Pedro"; p1.Rut = 11; p1.Email = "p@sda.com"; p1.Telefono = 123;
                Personal p2 = new Personal(); p2.Nombre = "Bartolome"; p2.Rut = 221; p2.Email = "b@sda.com"; p2.Telefono = 222;
                Personal p3 = new Personal(); p3.Nombre = "cecilia"; p3.Rut = 311; p3.Email = "c@sda.com"; p3.Telefono = 333;
                estacionamiento.listaPersonal.Add(p1);
                estacionamiento.listaPersonal.Add(p2);
                estacionamiento.listaPersonal.Add(p3);

                cont_personal++;
            }


            //llamar a SP Personal_Todos

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

                    //llamar a SP Personal_Agregar

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

                //llamar a SP Personal_Editar

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

                //llamar a SP Personal_Eliminar

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
