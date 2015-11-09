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
        [HttpGet]
        public ActionResult Libres(int ID)
        {
            var estacionamiento = new Models.Estacionamiento();
            estacionamiento.Seleccionar(ID);

            return View(estacionamiento);
        }
        [HttpPost]
        public ActionResult Libres(Models.Estacionamiento estacionamiento)
        {
            return View("Libres");
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