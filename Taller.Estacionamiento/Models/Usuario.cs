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
        public virtual string Nombre { get; set; }
        public virtual int Rut { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Contraseña { get; set; }
        public virtual int Telefono { get; set; }

        public virtual bool IniciarSesion(string email, string contraseña)
        {
            if (this.Seleccionar(email) && contraseña == this.Contraseña)
            {
                return true;
            }
            return false;
        }
        public virtual bool CerrarSesion(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Agregar un usuario en la base de datos
        /// </summary>
        public void Agregar()
        {
            try
            {
                Logger.EntradaMetodo("Usuario.Agregar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Usuario_Crear", CommandType = System.Data.CommandType.StoredProcedure };
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
                Logger.SalidaMetodo("Usuario.Agregar", this.ToString());
            }
        }
        
        public bool Seleccionar(string email)
        {
            try
            {
                Logger.EntradaMetodo("Usuario.Seleccionar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Usuario_Seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inEmail", email);
                var data = Data.Obtener(comando);
                DataTable dt = data.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.Rut = Convert.ToInt32(dr["rut"]);
                    this.Nombre = Convert.ToString(dr["nombre"]);
                    this.Email = Convert.ToString(dr["email"]);
                    this.Contraseña = Convert.ToString(dr["contrasenia"]);
                    this.Telefono = Convert.ToInt32(dr["telefono"]);
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Usuario.Seleccionar", this.ToString());
            }
            return true;
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

        public void Estacionamientos()
        {
            var estacionamientos = new List<Estacionamiento>();
            try
            {
                Logger.EntradaMetodo("Usuario.Estacionamientos", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inRut", this.Rut);
                var data = Data.Obtener(comando);
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    Estacionamiento estacionamiento = new Estacionamiento();

                    estacionamiento.Seleccionar(Convert.ToInt32(dr["ID_Estacionamiento"]));
                    estacionamientos.Add(estacionamiento);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Usuario.Estacionamientos", this.ToString());
            }
        }
    }
}