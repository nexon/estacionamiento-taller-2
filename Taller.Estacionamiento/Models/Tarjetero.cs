using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Taller.Estacionamiento.Utils;
using System.Data;

namespace Taller.Estacionamiento.Models
{
    public class Tarjetero
    {
        public bool registarIngreso(Personal personal)
        {
            throw new NotImplementedException();
        }
        public bool registrarSalida(Personal personal)
        {
            throw new NotImplementedException();
        }
        public bool eliminarRegistroPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }
        public List<Personal> personalTrabajando(int idEstacionamiento)
        {
            List<Personal> lista = new List<Personal>();
            try
            {
                Logger.EntradaMetodo("Tarjetero.personalTrabajando", this.ToString());
                var comando = new MySqlCommand() { CommandText = "registro_personal_todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                // Nose como agregar las fechas a la lista de Personal
                foreach(DataRow row in dt.Rows)
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
        public List<DateTime> entradasPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }
        public List<DateTime> salidasPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }
    }
}