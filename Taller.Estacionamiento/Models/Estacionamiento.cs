using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Taller.Estacionamiento.Models
{
    public class Estacionamiento
    {
        public string Nombre { get; set; }
        public List<Espacio> Espacios { get; set; }
        public List<Personal> Personal { get; set; }
        public int TarifaMinuto { get; set; }
        public int TiempoMinimo { get; set; }
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

        void AgregarValoracion(double Valoracion)
        {
            throw new NotImplementedException();
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

        void Agregar()
        {
            throw new NotImplementedException(); 
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