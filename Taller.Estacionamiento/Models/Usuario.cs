using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Models
{
    public class Usuario
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
            try
            {
                Logger.EntradaMetodo("Usuario.Agregar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Usuario_Crear", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inRut", this.Rut);
                comando.Parameters.AddWithValue("inNombre", this.Nombre);
                comando.Parameters.AddWithValue("inContrasenia", this.Contraseña );
                comando.Parameters.AddWithValue("inEmail", this.Email );
                comando.Parameters.AddWithValue("inTelefono", this.Telefono );                
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Usuario.Agregar", this.ToString());
            }
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