using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Models
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public Conductor Conductor { get; set; }
        public void RegistrarConductor(Conductor conductor)
        {
            throw new NotImplementedException();
        }
        public void EliminarRegistroConductor(Conductor conductor)
        {
            throw new NotImplementedException();
        }

        public bool Validar()
        { 
            try
            {
                Logger.EntradaMetodo("Vehiculo.Valida", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Vehiculo_Seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inPatente", Patente);

                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Vehiculo.Valida", this.ToString());
            }
            return false;      
        }

        internal void Agregar()
        {
            try
            {
                Logger.EntradaMetodo("Vehiculo.Agregar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Vehiculo_Agregar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inPatente", this.Patente);
                if(this.Conductor == null)
                    comando.Parameters.AddWithValue("inIDCOnductor", -1);
                else
                    comando.Parameters.AddWithValue("inIDCOnductor", this.Conductor.Rut);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Vehiculo.Agregar", this.ToString());
            }
        }
    }
}