using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;

namespace Taller.Estacionamiento.Models
{
    public class Conductor:Usuario
    {
        public void AgregarValoracion(double valoracion, int idEstacionamiento)
        {
            try
            {
                Logger.EntradaMetodo("Conductor.AgregarValoracion", this.ToString());
                var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar" };
                command.Parameters.AddWithValue("inIdUsuario", this.Rut);
                command.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
                DataSet ds = Data.Obtener(command);
                DataTable dt = ds.Tables[0];
                bool ejecucion = false;
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    int idValoracion = Convert.ToInt32(dr["valoracion_id_valoracion"]);
                    float valoracionConductor = (float)dr["valoracion_valor_conductor"];
                    float valoracionEstacionamiento = (float)dr["valoracion_valor_estacionamiento"];
                    if (valoracionConductor == 0)//como la valoracion es 0 significa que no esta hecha por tanto se modifica
                    {
                        /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
                        var commandM = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_modificar" };
                        commandM.Parameters.AddWithValue("inIdValoracion", idValoracion);
                        commandM.Parameters.AddWithValue("inValorConductor", (float)valoracion);
                        commandM.Parameters.AddWithValue("inValorEstacionamiento", valoracionEstacionamiento);
                        Data.Ejecutar(commandM);
                        ejecucion = true;
                    }
                }
                if (!ejecucion)
                {
                    //si la valoracion es mayor a 0 o no existe significa que la valoracion que se necesita crear una nueva
                    /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
                    var commandC = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_crear" };
                    commandC.Parameters.AddWithValue("inIdUsuario", this.Rut);
                    commandC.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
                    commandC.Parameters.AddWithValue("inValorConductor", (float)valoracion);
                    commandC.Parameters.AddWithValue("inValorEstacionamiento", 0);
                    Data.Ejecutar(commandC);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Conductor.AgregarValoracion", this.ToString());
            }
        }

        public double PromedioValoraciones()
        {
            double promedio = 0;
            try
            {
                Logger.EntradaMetodo("Conductor.PromedioValoraciones", this.ToString());
                var comando = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar_promedio" };
                comando.Parameters.AddWithValue("inIdUsuario", this.Rut);
                comando.Parameters.AddWithValue("inIdEstacionamiento", -1);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    promedio = Convert.ToDouble(dr["valoracion_valor_estacionamiento"]); ;
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Conductor.PromedioValoraciones", this.ToString());
            }
            return promedio;
        }

        public List<Estacionamiento> EstacionamientoCercanos(double latitud, double longitud)
        {
            throw new NotImplementedException();
        }
    }
}