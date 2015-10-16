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
        public string Oferta { get; set; }
        public string Direccion { get; set; }
        public double CoordenadaLatitud { get; set; }
        public double CoordenadaLongitud { get; set; }
        public Tarjetero Tarjetero { get; set; }

        string IngresarVehiculo(Vehiculo vehiculo, Espacio espacio)
        {
            throw new NotImplementedException();
        }

        int LiberarEspacio(Espacio espacio)
        {
            throw new NotImplementedException();
        }
        List<Personal> Personal()
        {
            throw new NotImplementedException();
        }
        void AgregarPersonal(Personal personal)
        {
            throw new NotImplementedException();
        }

        void EliminarPersonal(Personal Personal)
        {
            throw new NotImplementedException();
        }

        List<Espacio> Reservados()
        {
            throw new NotImplementedException();
        }

        List<Espacio> Disponibles()
        {
            throw new NotImplementedException();
        }
        List<Espacio> Ocupados()
        {
            throw new NotImplementedException();
        }
        List<Espacio> Todos()
        {
            throw new NotImplementedException();
        }

        bool ReservarEspacio(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        void ConfirmarReserva(Espacio espacio)
        {
            throw new NotImplementedException();
        }

        public void AgregarValoracion(double valoracion, int idUsuario, int idEstacionamiento)
        {
            var dt = new DataTable();
            var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar" };
            command.Parameters.AddWithValue("inIdUsuario", idUsuario);
            command.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
            using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                command.Connection = conn;
                var sqlda = new MySqlDataAdapter(command);
                sqlda.Fill(dt);
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                //si se obtiene una fila como respuesta es por que hay una valoracion existente que asocia el conductor y el estacionamiento
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
                    using (var conn2 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {

                        conn2.Open();
                        var sqlTran = conn2.BeginTransaction();
                        try
                        {
                            commandM.Connection = conn2;
                            commandM.Transaction = sqlTran;
                            commandM.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            conn2.Close();
                        }
                    }
                    return;//como ya se modifico la fila termino la funcion aqui
                }
            }
            //si la valoracion es mayor a 0 o no existe significa que la valoracion que se necesita crear una nueva
            /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
            var commandC = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_crear" };
            commandC.Parameters.AddWithValue("inIdUsuario", idUsuario);
            commandC.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
            commandC.Parameters.AddWithValue("inValorConductor", 0);
            commandC.Parameters.AddWithValue("inValorEstacionamiento", (float)valoracion);
            using (var conn2 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                conn2.Open();
                var sqlTran = conn2.BeginTransaction();
                try
                {
                    commandC.Connection = conn2;
                    commandC.Transaction = sqlTran;
                    commandC.ExecuteNonQuery();
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    conn2.Close();
                }
            }
        }

        double PromedioValoraciones(int idEstacionamiento)
        {
            var dt = new DataTable();
            var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar_promedio" };
            command.Parameters.AddWithValue("inIdUsuario", -1);
            command.Parameters.AddWithValue("inIdEstacionamiento", idEstacionamiento);
            using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                command.Connection = conn;
                var sqlda = new MySqlDataAdapter(command);
                sqlda.Fill(dt);
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                float promedio = (float)dr["valoracion_valor_estacionamiento"];
                return (double)promedio;
            }
            return 0;
        }

        void AgregarEspacio(Espacio espacio)
        {
            throw new NotImplementedException();
        }

        void EliminarEspacio(Espacio espacio)
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

        void Modificar()
        {
            throw new NotImplementedException();
        }

        void Eliminar()
        {
            throw new NotImplementedException();
        }

        void ReubicarVehiculo(Espacio espacio1, Espacio espacio2)
        {
            throw new NotImplementedException();
        }
    }
}