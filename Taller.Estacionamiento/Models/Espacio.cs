using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Espacio
    {
        public String Codigo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Reserva Reserva { get; set; }
        public EstadoEspacio Estado { get; set; }
        public DateTime IngresoVehiculo { get; set; }
        public DateTime SalidaVehiculo { get; set; }
    }
}