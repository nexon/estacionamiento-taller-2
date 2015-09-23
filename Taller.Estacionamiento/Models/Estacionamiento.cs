using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Estacionamiento
    {
        public string Nombre { get; set; }
        public List<Espacio> Espacios { get; set; }
        public List<Personal> Personal { get; set; }
        public int TarifaMinuto { get; set; }
        public int TiempoMinimo { get; set; }
        public DateTime Apertura { get; set; }
        public DateTime Cierre { get; set; }
        public string Oferta { get; set; }
        public string Direccion { get; set; }
        public double CoordenadaLatitud { get; set; }
        public double CoordenadaLongitud { get; set; }
        public Tarjetero Tarjetero { get; set; }

        string IngresarVehiculo(Vehiculo Vehiculo)
        {
            throw new NotImplementedException();
        }

        int LiberarEspacio(Espacio Espacio)
        {
            throw new NotImplementedException(); 
        }

        void AgregarPersonal(Personal Personal)
        {
            throw new NotImplementedException(); 
        }

        void EliminarPersonal(Personal Personal)
        {
            throw new NotImplementedException();
        }

        List<Espacio> EspaciosReservados()
        {
            throw new NotImplementedException();
        }

        int CapacidadDisponible()
        {
            throw new NotImplementedException();
        }

        bool ReservarEspacio(Vehiculo Vehiculo)
        {
            throw new NotImplementedException();
        }

        abstract List<Estacionamiento> EstacionamientosCercanos(double Langitud, double Longitud)
        {
            throw new NotImplementedException();
        }

        void AgregarValoracion(double Valoracion)
        {
            throw new NotImplementedException();
        }

        void PromedioValoraciones()
        {
            throw new NotImplementedException();
        }

        abstract List<Estacionamiento> EstacionamientoPersonal(Personal Personal)
        {
            throw new NotImplementedException(); 
        }

        void AgregarEspacio(Espacio Espacio)
        {
            throw new NotImplementedException(); 
        }

        void EliminarEspacio(Espacio Espacio)
        {
            throw new NotImplementedException();
        }

        void Agregar()
        {
            throw new NotImplementedException(); 
        }

        void Modificar()
        {
            throw new NotImplementedException(); 
        }

        void Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}