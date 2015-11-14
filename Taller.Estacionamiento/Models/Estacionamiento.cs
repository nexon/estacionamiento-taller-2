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
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int TarifaMinuto { get; set; }
        public int TiempoMinimo { get; set; }
        public int Capacidad { get; set; }
        public DateTime Apertura { get; set; }
        public DateTime Cierre { get; set; }
        public string Direccion { get; set; }
        public double CoordenadaLatitud { get; set; }
        public double CoordenadaLongitud { get; set; }
        public Tarjetero Tarjetero { get; set; }


        /// <summary>
        /// constructor
        /// </summary>
        public Estacionamiento()
        {
            this.Tarjetero = new Tarjetero(this); //es necesario setear siempre el ID de Estacionamiento!!!! 
        }

        public bool Seleccionar(int estacionamientoId)
        {
            this.ID = -1;//se usa el id -1 que jamas se asignara para revisar si es que se pudieron obtener los datos
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Seleccionar", this.ToString());
                var comando = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "estacionamiento_seleccionar" };
                comando.Parameters.AddWithValue("inIdEstacionamiento", estacionamientoId);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.ID = estacionamientoId;
                    this.Nombre = dr["estacionamiento_Nombre"].ToString();
                    this.Direccion = dr["estacionamiento_Direccion"].ToString();
                    this.Email = dr["estacionamiento_Email"].ToString();
                    if (dr["estacionamiento_Telefono"].ToString() != "" && dr["estacionamiento_Telefono"] != null)
                    {
                        this.Telefono = Convert.ToInt32(dr["estacionamiento_Telefono"]);
                    }
                    else 
                    {
                        this.Telefono = -1;
                    }
                    this.Capacidad = Convert.ToInt32(dr["estacionamiento_Capacidad"]);
                    this.TiempoMinimo = Convert.ToInt32(dr["estacionamiento_TiempoMinimo"]);
                    this.TarifaMinuto = Convert.ToInt32(dr["estacionamiento_TarifaMinuto"]);
                    if (dr["estacionamiento_Apertura"].ToString() != "" && dr["estacionamiento_Apertura"] != null)
                    {
                        this.Apertura = Convert.ToDateTime(dr["estacionamiento_Apertura"]);
                    }
                    if (dr["estacionamiento_Cierre"].ToString() != "" && dr["estacionamiento_Cierre"] != null)
                    {
                        this.Cierre = Convert.ToDateTime(dr["estacionamiento_Cierre"]);
                    }
                    this.CoordenadaLatitud = 0;
                    this.CoordenadaLongitud = 0;
                    if (dr["estacionamiento_CoordenadaLatitud"].ToString() != "" && dr["estacionamiento_CoordenadaLatitud"] != null && dr["estacionamiento_CoordenadaLongitud"].ToString() != "" && dr["estacionamiento_CoordenadaLongitud"] != null)
                    {
                        this.CoordenadaLatitud = Convert.ToDouble(dr["estacionamiento_CoordenadaLatitud"]);
                        this.CoordenadaLongitud = Convert.ToDouble(dr["estacionamiento_CoordenadaLongitud"]);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Seleccionar", this.ToString());
            }
            if (this.ID > 0)
            {
                return true;
            }
            return false;
        }

        //public string IngresarVehiculo(Vehiculo vehiculo, Espacio espacio)
        public void EstacionarVehiculo(Espacio espacio)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.EstacionarVehiculo", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Estacionamiento_EstacionarVehiculo", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inFecha_ingreso", espacio.IngresoVehiculo);
                comando.Parameters.AddWithValue("inId_estacionamiento", this.ID);
                comando.Parameters.AddWithValue("inId_vehiculo", espacio.Vehiculo.Patente);
                comando.Parameters.AddWithValue("inCodigo", espacio.Codigo);
                Data.Ejecutar(comando);
        }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.EstacionarVehiculo", this.ToString());
            }
        }

        //public int LiberarEspacio(Espacio espacio)
        public void DespacharVehiculo(Espacio espacio)
        {
            try
            {
                int monto;
                int cant_minutos = (int)(espacio.SalidaVehiculo - espacio.IngresoVehiculo).TotalMinutes;
                if (cant_minutos <= this.TiempoMinimo)
                    monto = this.TarifaMinuto * this.TiempoMinimo;
                else
                    monto = cant_minutos * this.TarifaMinuto;
                Logger.EntradaMetodo("Estacionamiento.DespacharVehiculo", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Estacionamiento_DespacharVehiculo", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inFecha_salida", DateTime.Now);
                comando.Parameters.AddWithValue("inMonto", monto);
                comando.Parameters.AddWithValue("inId_estacionamiento", this.ID);
                comando.Parameters.AddWithValue("inCodigo", espacio.Codigo);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.DespacharVehiculo", this.ToString());
            }
        }

        /// <summary>
        /// retorna una lista de personales de un estacionamiento,
        /// con los datos que tienen como usuario
        /// </summary>
        /// <returns></returns>
        public List<Personal> Personal()
        {
            List<Personal> listaPersonal = new List<Personal>();
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Personal_Todos", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Personal_Estacionamiento_Todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                var data = Data.Obtener(comando);
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    Personal personal = new Personal();
                    personal.ID = Convert.ToInt32(dr["Personal_ID"]);
                    personal.Rut = Convert.ToInt32(dr["Usuario_rut"]);
                    personal.Nombre= Convert.ToString(dr["Usuario_Nombre"]);
                    personal.Contraseña = Convert.ToString(dr["Usuario_Contrasenia"]);
                    personal.Email = Convert.ToString(dr["Usuario_Email"]);
                    personal.Telefono = Convert.ToInt32(dr["Usuario_Telefono"]);
                    listaPersonal.Add(personal);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Personal_Todos", this.ToString());
            }
            return listaPersonal;
        }

        public void AgregarPersonal(Personal personal)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.AgregarPersonal(Personal personal)", this.ToString());

               /* var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "personal_estacionamiento_seleccionar" };
                command.Parameters.AddWithValue("inIdPersonal", personal.Rut);
                command.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                DataSet ds = Data.Obtener(command);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return; //ya existe uno así que no hacemos nada :P
                }*/

                var comando = new MySqlCommand() { CommandText = "personal_estacionamiento_agregar", CommandType = System.Data.CommandType.StoredProcedure };
                int rol = personal.RolToInt();
                comando.Parameters.AddWithValue("inIdPersonal", personal.ID);
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
                comando.Parameters.AddWithValue("inIdRol", rol);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.AgregarPersonal", this.ToString());
            }
        }

        public void DesvincularPersonal(Personal Personal)
        {

            try
            {
                Logger.EntradaMetodo("Estacionamiento.DesvincularPersonal()", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Desvincular_Personal", CommandType = System.Data.CommandType.StoredProcedure };

                comando.Parameters.AddWithValue("inIDEstacionamiento", this.ID);
                comando.Parameters.AddWithValue("inIDRut", Personal.Rut);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.DesvincularPersonal()", this.ToString());
            }

        }

        public List<Espacio> Reservados()
        {
            List<Espacio> lista = new List<Espacio>();
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Reservados()", this.ToString());
                var comando = new MySqlCommand() { CommandText = "estacionamiento_Reservados", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("IdEstacionamiento", this.ID);
                DataSet ds = Data.Obtener(comando);
                DataTable dt = ds.Tables[0];
                TimeSpan tiempoParaExpirar = new TimeSpan(1,0,0); // aqui se tiene que definir el tiempo de expiracion por default que se dejara , por ahora suma una hora a la hora de reserva
                foreach (DataRow row in dt.Rows)
                {
                    Espacio espacio = new Espacio
                    {
                        Codigo = Convert.ToString(row["espacio_codigo"]),
                        Vehiculo = new Vehiculo { Patente = Convert.ToString(row["vehiculo_patente"]), Conductor = new Conductor { Nombre = Convert.ToString(row["usuario_nombre"]) } },
                        Estado = EstadoEspacio.Reservado,
                        Reserva = new Reserva { Expiracion = Convert.ToDateTime(row["registro_fecha_reserva"]).Add(tiempoParaExpirar) }
                    };
                    lista.Add(espacio);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {

                Logger.SalidaMetodo("Estacionamiento.Reservados()", this.ToString());
            }
            return lista;
        }

        public List<Espacio> Disponibles()
        {
            var disponibles = new List<Espacio>();
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Disponibles", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Disponibles", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inID_Estacionamiento", this.ID);
                var data = Data.Obtener(comando);
                foreach (DataRow dr in data.Tables[0].Rows)
                {

                    Espacio espacio = new Espacio();
                    espacio.Codigo = Convert.ToString(dr["Espacio_Codigo"]);
                    disponibles.Add(espacio);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Disponibles", this.ToString());
            }
            return disponibles;
        }


        /// <summary>
        /// Crea este estacionamiento en la base de datos
        /// </summary>
        public List<Espacio> Ocupados()
        {
            var ocupados = new List<Espacio>();
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Ocupados", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Ocupados", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inID_Estacionamiento", this.ID);
                var data = Data.Obtener(comando);
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    Vehiculo vehiculo = new Vehiculo();
                    Reserva reserva = new Reserva();
                    Espacio espacio = new Espacio();
                    espacio.Codigo = Convert.ToString(dr["Espacio_Codigo"]);
                    vehiculo.Patente = Convert.ToString(dr["Vehiculo_Patente"]);
                    if (dr["Fecha_Reserva"] != DBNull.Value)
                        reserva.Expiracion = Convert.ToDateTime(dr["Fecha_Reserva"]);
                    if (dr["Fecha_Ingreso"] != DBNull.Value)
                        espacio.IngresoVehiculo = Convert.ToDateTime(dr["Fecha_Ingreso"]);
                    espacio.Estado = EstadoEspacio.Ocupado;

                    if (reserva.Expiracion != null)
                        reserva.Concretada = true;
                    espacio.Vehiculo = vehiculo;
                    espacio.Reserva = reserva;

                    ocupados.Add(espacio);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Ocupados", this.ToString());
            }
            return ocupados;
        }


        /// <summary>
        /// Crea este estacionamiento en la base de datos
        /// </summary>
        public List<Espacio> Todos()
        {
            var todos = new List<Espacio>();
            try
            {
                Logger.EntradaMetodo("Estacionamiento.Todos", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Estacionamiento_Todos", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inID_Estacionamiento", this.ID);
                var data = Data.Obtener(comando);
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    Vehiculo vehiculo = new Vehiculo();
                    Reserva reserva = new Reserva();
                    Espacio espacio = new Espacio();
                    espacio.Codigo = Convert.ToString(dr["Espacio_Codigo"]);
                    vehiculo.Patente = Convert.ToString(dr["Vehiculo_Patente"]);
                    if (dr["Fecha_Reserva"] != DBNull.Value)
                        reserva.Expiracion = Convert.ToDateTime(dr["Fecha_Reserva"]);
                    if (dr["Fecha_Ingreso"] != DBNull.Value)
                        espacio.IngresoVehiculo = Convert.ToDateTime(dr["Fecha_Ingreso"]);

                    if (reserva.Expiracion == null && espacio.IngresoVehiculo == null && espacio.SalidaVehiculo == null)
                        espacio.Estado = EstadoEspacio.Disponible;

                    if (reserva.Expiracion != null && espacio.IngresoVehiculo == null && espacio.SalidaVehiculo == null)
                        espacio.Estado = EstadoEspacio.Reservado;

                    if (reserva.Expiracion != null && espacio.IngresoVehiculo != null && espacio.SalidaVehiculo == null)
                        espacio.Estado = EstadoEspacio.Ocupado;

                    espacio.Vehiculo = vehiculo;
                    espacio.Reserva = reserva;

                    todos.Add(espacio);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.Todos", this.ToString());
            }
            return todos;
        }


        public void ModificarEspacio(Espacio espacio)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.ModificarEspacio", this.ToString());
                var comando = new MySqlCommand() { CommandText = "estacionamiento_modificarEspacio", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("incodigo", espacio.Codigo);
                comando.Parameters.AddWithValue("inIDEstacionamiento", this.ID);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.ModificarEspacio", this.ToString());
            }
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
            try
            {
                Logger.EntradaMetodo("Estacionamiento.AgregarEspacio", espacio.ToString());
                var comando = new MySqlCommand() { CommandText = "espacio_crear", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inCodigo", espacio.Codigo);
                comando.Parameters.AddWithValue("inId_estacionamiento", this.ID);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.AgregarEspacio", this.ToString());
            }
        }

        public bool SeleccionarEspacio(int ID, Espacio e)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.SeleccionarEspacio", this.ToString());

                var comando = new MySqlCommand() { CommandText = "Estacionamiento_SeleccionarEspacio", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inID", ID);
                comando.Parameters.AddWithValue("inCodigo", e.Codigo);

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
                Logger.SalidaMetodo("Estacionamiento.SeleccionarEspacio", this.ToString());
            }
            return false;
        }


        public void EliminarEspacio(Espacio espacio)
        {
            try
            {
                Logger.EntradaMetodo("Estacionamiento.EliminarEspacio(Espacio espacio)", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Espacio_Eliminar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inCodigo", espacio.Codigo);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Estacionamiento.EliminarEspacio", this.ToString());
            }
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
                comando.Parameters.AddWithValue("inIdEstacionamiento", this.ID);
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

        //funciones para evitar poner codigo explicito en vista
        public bool tieneTelefono()
        { 
            if(this.Telefono>0)
            {
                return true;
            }
            return false;
        }

        public bool tieneHorario()
        {
            if (this.Apertura.Year > 1 && this.Cierre.Year > 1)
            {
                return true;
            }
            return false;
        }

        public String horaApertura()
        {
            return this.Apertura.ToString("HH:mm");
        }

        public String horaCierre()
        {
            return this.Cierre.ToString("HH:mm");
        }

        public bool coordenadasDisponibles()
        {
            if (this.CoordenadaLatitud != 0 && this.CoordenadaLongitud != 0)
            {
                return true;
            }
            return false;
        }
    }
}
