using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;
using MySql.Data.MySqlClient;
using System.Data;

namespace Taller.Estacionamiento.Models
{
    public class Tarjetero
    {
        public Estacionamiento Estacionamiento { get; set; }
        public Tarjetero(Estacionamiento Estacionamiento)
        {
            this.Estacionamiento = Estacionamiento;
        }
        public bool RegistarIngreso(Personal personal)
        {
            throw new NotImplementedException();
        }
        public bool RegistrarSalida(Personal personal)
        {
            throw new NotImplementedException();
        }
        public List<Personal> PersonalTrabajando()
        {
            List<Personal> lista = new List<Personal>();
            try
            {
                Logger.EntradaMetodo("Tarjetero.personalTrabajando", this.ToString());
                var comando = new MySqlCommand() { CommandText = "registro_personal_todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.Estacionamiento.ID);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                // Nose como agregar las fechas a la lista de Personal
                foreach (DataRow row in dt.Rows)
                {
                    Personal pe = new Personal();
                    pe.Nombre = Convert.ToString(row["nombre"]);
                    pe.Rut = Convert.ToInt32(row["rut"]);
                    lista.Add(pe);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Tarjetero.personalTrabajando", this.ToString());
            }
            return lista;
        }
        public List<RegistroPersonal> RegistrosPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }
    }
}