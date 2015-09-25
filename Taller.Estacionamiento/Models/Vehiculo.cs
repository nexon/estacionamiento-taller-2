using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Vehiculo
    {
        public String Patente { get; set; }
        public Conductor Conductor { get; set; }
        public void RegistrarConductor(Conductor conductor)
        {
            throw new NotImplementedException();
        }
        public void EliminarRegistroConductor(Conductor conductor)
        {
            throw new NotImplementedException();
        }
    }
}