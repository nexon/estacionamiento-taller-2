using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Personal:Usuario
    {
        public Erol Rol { get; set; }

        public List<Estacionamiento> EstacionamientoAsociados()
        {
            throw new NotImplementedException();
        }

    }

}