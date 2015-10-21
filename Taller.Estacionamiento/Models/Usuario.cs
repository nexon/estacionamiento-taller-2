using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public int Rut{get; set;}
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int Telefono { get; set; }

        public virtual bool IniciarSesion(string email, string contraseña)
        {
            throw new NotImplementedException();
        }
        public virtual bool CerrarSesion(string email)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Agregar un usuario en la base de datos
        /// </summary>
        public virtual void Agregar()
        {

        }
        public virtual void Modificar()
        {
            throw new NotImplementedException();
        }
        public virtual void Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}