using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class RegistroPersonal
    {
        public int ID { get; set; }
        public Estacionamiento Estacionamiento { get; set; }
        public Personal Personal { get; set; }
        public DateTime? Ingreso { get; set; }
        public DateTime? Salida { get; set; }
    }
}