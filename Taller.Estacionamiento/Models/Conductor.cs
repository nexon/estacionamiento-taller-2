using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Models
{
    public class Conductor:Usuario
    {
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
                if (valoracionConductor == 0)//como la valoracion es 0 significa que no esta hecha por tanto se modifica
                {
                    /*se crea el comando, luego se usa una segunda coneccion para enviar los datos*/
                    var commandM = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_modificar" };
                    commandM.Parameters.AddWithValue("inIdValoracion", idValoracion);
                    commandM.Parameters.AddWithValue("inValorConductor", (float)valoracion);
                    commandM.Parameters.AddWithValue("inValorEstacionamiento", valoracionEstacionamiento);
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
            commandC.Parameters.AddWithValue("inValorConductor", (float)valoracion);
            commandC.Parameters.AddWithValue("inValorEstacionamiento", 0);
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

        double PromedioValoraciones(int idUsuario)
        {
            var dt = new DataTable();
            var command = new MySqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = "valoracion_seleccionar_promedio" };
            command.Parameters.AddWithValue("inIdUsuario", idUsuario);
            command.Parameters.AddWithValue("inIdEstacionamiento", -1);
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
                float promedio = (float)dr["valoracion_valor_conductor"];
                return (double)promedio;
            }
            return 0;
        }

        public List<Estacionamiento> EstacionamientoCercanos(double latitud, double longitud)
        {
            throw new NotImplementedException();
        }
    }
}