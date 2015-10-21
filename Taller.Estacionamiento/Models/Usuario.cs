using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;

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
        public virtual void Agregar()
        {
            throw new NotImplementedException();
        }
        public virtual void Modificar()
        {
            try
            {
                Logger.EntradaMetodo("Usuario.Modificar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "usuario_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inRut", this.Rut);
                comando.Parameters.AddWithValue("inNombre", this.Nombre);
                comando.Parameters.AddWithValue("inContrasenia", this.Contraseña);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Modificar", this.ToString());
            }
        }
        public virtual void Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}