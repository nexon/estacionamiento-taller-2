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
            throw new NotImplementedException();
        }
        public List<RegistroPersonal> RegistrosPersonal()
        {
            List<RegistroPersonal> lista = new List<RegistroPersonal>();
            try
            {
                Logger.EntradaMetodo("Tarjetero.registroPersonal", this.ToString());
                var comando = new MySqlCommand() { CommandText = "registro_personal_todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.Estacionamiento.ID);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Personal personal = new Personal();
                    personal.Nombre = Convert.ToString(row["nombre"]);
                    personal.Rut = Convert.ToInt32(row["rut"]);

                    RegistroPersonal rp = new RegistroPersonal();
                    rp.Personal = personal;
                    
                    if(row["fecha_ingreso"].ToString() != ""){
                        DateTime ingreso = Convert.ToDateTime(row["fecha_ingreso"]);
                        rp.Ingreso = ingreso;
                    }
                    else{
                        rp.Ingreso = null;
                    }
                    
                    if (row["fecha_salida"].ToString() != "")
                    {
                        DateTime salida = Convert.ToDateTime(row["fecha_salida"]);
                        rp.Salida = salida;
                    }
                    else
                    {
                        rp.Salida = null;
                    }
                    
                    lista.Add(rp);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Tarjetero.registroPersonal", this.ToString());
            }
            return lista;
        }
    }
}