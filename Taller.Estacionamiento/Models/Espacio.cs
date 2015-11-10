using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Espacio
    {
        [Required(ErrorMessage = "El campo Identificador es requerido")]
        [StringLength(256)] 
        public String Codigo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Reserva Reserva { get; set; }
        public EstadoEspacio Estado { get; set; }
        public DateTime IngresoVehiculo { get; set; }
        public DateTime SalidaVehiculo { get; set; }
    }
}