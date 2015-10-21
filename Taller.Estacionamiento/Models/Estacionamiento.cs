using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;


namespace Taller.Estacionamiento.Models
{
    public class Estacionamiento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int TarifaMinuto { get; set; }
        public int TiempoMinimo { get; set; }
        public int Capacidad { get; set; }
        public DateTime Apertura { get; set; }
        public DateTime Cierre { get; set; }
        public string Direccion { get; set; }
        public double CoordenadaLatitud { get; set; }
        public double CoordenadaLongitud { get; set; }
        public Tarjetero Tarjetero { get; set; }

        public string IngresarVehiculo(Vehiculo vehiculo, Espacio espacio)
        {
            throw new NotImplementedException();
        }

        public int LiberarEspacio(Espacio espacio)
        {
            throw new NotImplementedException();
        }
        public List<Personal> Personal()
        {
            throw new NotImplementedException();
        }
        public void AgregarPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }

        public void EliminarPersonal(Personal Personal)
        {

            try
            {
                Logger.EntradaMetodo("Estacionamiento.EliminarPersonal()", this.ToString());

                //var comando = new MySqlCommand() { CommandText = "Proyecto_DesasociarParticipante", CommandType = System.Data.CommandType.StoredProcedure };
                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Eliminar_Personal", CommandType = System.Data.CommandType.StoredProcedure };

                comando.Parameters.AddWithValue("inID_Estacionamiento", this.ID);
                comando.Parameters.AddWithValue("inID_Personal", Personal.Rut);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.EliminarPersonal()", this.ToString());
            }

        }

        public List<Espacio> Reservados()
        {
            throw new NotImplementedException();
        }

        public List<Espacio> Disponibles()
        {
            throw new NotImplementedException();
        }
        public List<Espacio> Ocupados()
        {
            throw new NotImplementedException();
        }
        public List<Espacio> Todos()
        {
            throw new NotImplementedException();
        }

        public bool ReservarEspacio(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        public void ConfirmarReserva(Espacio espacio)
        {
            throw new NotImplementedException();
        }

        public void AgregarValoracion(double valoracion, int idUsuario)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.AgregarValoracion", this.ToString());
                var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar" };
                command.Parameters.AddWithValue("inIdUsuario", idUsuario);
                command.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                DataSet ds = Data.Obtener(command);
                DataTable dt = ds.Tables[0];
                bool ejecucion = false;
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    int idValoracion = Convert.ToInt32(dr["valoracion_id_valoracion"]);
                    float valoracionConductor = (float)dr["valoracion_valor_conductor"];
                    float valoracionEstacionamiento = (float)dr["valoracion_valor_estacionamiento"];
                    if (valoracionEstacionamiento == 0)//como la valoracion es 0 significa que no esta hecha por tanto se modifica
                    {
                        /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
                        var commandM = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_modificar" };
                        commandM.Parameters.AddWithValue("inIdValoracion", idValoracion);
                        commandM.Parameters.AddWithValue("inValorConductor", valoracionConductor);
                        commandM.Parameters.AddWithValue("inValorEstacionamiento", (float)valoracion);
                        Data.Ejecutar(commandM);
                        ejecucion = true;
                    }
                }
                if (!ejecucion)
                {
                    //si la valoracion es mayor a 0 o no existe significa que la valoracion que se necesita crear una nueva
                    /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
                    var commandC = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_crear" };
                    commandC.Parameters.AddWithValue("inIdUsuario", idUsuario);
                    commandC.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                    commandC.Parameters.AddWithValue("inValorConductor", 0);
                    commandC.Parameters.AddWithValue("inValorEstacionamiento", (float)valoracion);
                    Data.Ejecutar(commandC);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.AgregarValoracion", this.ToString());
            }
        }

        public double PromedioValoraciones()
        {
            double promedio = 0;
            try
            {
                Logger.EntradaMetodo("Estacionamiento.PromedioValoraciones", this.ToString());
                var comando = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar_promedio" };
                comando.Parameters.AddWithValue("inIdUsuario", -1);
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
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
                Logger.SalidaMetodo("Estacionamiento.PromedioValoraciones", this.ToString());
            }
            return promedio;
        }

        public void AgregarEspacio(Espacio espacio)
        {
            throw new NotImplementedException();
        }

        public void EliminarEspacio(Espacio espacio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Crea este estacionamiento en la base de datos
        /// </summary>
        public void Agregar()
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Agregar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "estacionamiento_crear", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inNombre", this.Nombre);
                comando.Parameters.AddWithValue("inDireccion", this.Direccion);
                comando.Parameters.AddWithValue("inCapacidad", this.Capacidad);
                comando.Parameters.AddWithValue("inTiempoMinimo", this.TiempoMinimo);
                comando.Parameters.AddWithValue("inTarifaMinuto", this.TarifaMinuto);
                comando.Parameters.AddWithValue("inCantMinutos", 0);
                comando.Parameters.AddWithValue("inApertura", this.Apertura);
                comando.Parameters.AddWithValue("inCierre", this.Cierre);
                comando.Parameters.AddWithValue("inCoordenadaLatitud", this.CoordenadaLatitud);
                comando.Parameters.AddWithValue("inCoordenadaLongitud", this.CoordenadaLongitud);
                Data.Ejecutar(comando);
            }
            catch(Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Agregar", this.ToString());
            }
        }

        public void Modificar()
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Modificar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "estacionamiento_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                comando.Parameters.AddWithValue("inNombre", this.Nombre);
                comando.Parameters.AddWithValue("inDireccion", this.Direccion);
                comando.Parameters.AddWithValue("inCapacidad", this.Capacidad);
                comando.Parameters.AddWithValue("inTiempoMinimo", this.TiempoMinimo);
                comando.Parameters.AddWithValue("inTarifaMinuto", this.TarifaMinuto);
                comando.Parameters.AddWithValue("inCantMinutos", 0);
                comando.Parameters.AddWithValue("inApertura", this.Apertura);
                comando.Parameters.AddWithValue("inCierre", this.Cierre);
                comando.Parameters.AddWithValue("inCoordenadaLatitud", this.CoordenadaLatitud);
                comando.Parameters.AddWithValue("inCoordenadaLongitud", this.CoordenadaLongitud);
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

        public void Eliminar()
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Eliminar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "estacionamiento_eliminar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("idEstacionamiento", this.ID);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Eliminar", this.ToString());
            }
        }

        void ReubicarVehiculo(Espacio espacio1, Espacio espacio2)
        {
            throw new NotImplementedException();
        }
    }
}
