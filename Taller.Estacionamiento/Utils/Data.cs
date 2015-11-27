using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Taller.Estacionamiento.Utils
{
    public class Data
    {
        public static DataSet Obtener(MySqlCommand comando)
        {
            var ds = new DataSet();
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoConn"].ConnectionString))
            {
                conn.Open();
                comando.Connection = conn;
                var sqlda = new MySqlDataAdapter(comando);
                sqlda.Fill(ds);
                conn.Close();
            }
            return ds;
        }


        public static void Ejecutar(MySqlCommand comando)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoConn"].ConnectionString))
            {
                conn.Open();
                var sqlTran = conn.BeginTransaction();
                try
                {
                    comando.Connection = conn;
                    comando.Transaction = sqlTran;
                    comando.ExecuteNonQuery();
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


    }
}