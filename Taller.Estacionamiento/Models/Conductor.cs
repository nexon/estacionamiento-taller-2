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
        public void AgregarValoracion(double valoracion)
        {
            throw new NotImplementedException();
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