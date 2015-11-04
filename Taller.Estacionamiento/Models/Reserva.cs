using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Reserva
    {
        public DateTime Expiracion { get; set; }
        public bool Concretada { get; set; }
    }
}