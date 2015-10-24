using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Taller.Estacionamiento.Utils;
namespace Taller.Estacionamiento.Models
{
    public class Personal:Usuario
    {
        public Erol Rol { get; set; }

        public List<Estacionamiento> EstacionamientoAsociados()
        {
            throw new NotImplementedException();
        }

        public override void Eliminar()
        {
            try
            {
                Logger.EntradaMetodo("Personal.Eliminar()", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Personal_Eliminar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inId_personal", this.Rut);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Personal.Eliminar", this.ToString());
            }

        }
    }

}
