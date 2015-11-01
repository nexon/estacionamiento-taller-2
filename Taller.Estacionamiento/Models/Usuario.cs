using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Ingrese un Nombre valido")]
        public virtual string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese un Rut valido")]
        public virtual int Rut { get; set; }


        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Ingrese un Correo valido")]
        public virtual string Email { get; set; }

        public virtual string Contraseña { get; set; }

        [Required(ErrorMessage = "Ingrese un Telefono valido")]
        public virtual int Telefono { get; set; }

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
            try
            {
                Logger.EntradaMetodo("Usuario.Modificar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Usuario_Modificar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inRut", this.Rut);
                comando.Parameters.AddWithValue("inNombre", this.Nombre);
                comando.Parameters.AddWithValue("inContrasenia", this.Contraseña);
                comando.Parameters.AddWithValue("inEmail", this.Email);
                comando.Parameters.AddWithValue("inTelefono", this.Telefono);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Usuario.Modificar", this.ToString());
            }
        }
        public virtual void Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}