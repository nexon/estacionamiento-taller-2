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
        public int ID { get; set; }

        public List<Estacionamiento> EstacionamientoAsociados()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Agregar un personal en la base de datos,
        /// retorna el id del personal insertado en la bd
        /// </summary>
        public new int Agregar()
        {
            int last_inserted_id = 0;
            try
            {
                Logger.EntradaMetodo("Personal.Agregar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Personal_Crear", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inId_usuario", this.Rut);

                var data = Data.Obtener(comando);
                last_inserted_id= Convert.ToInt32(data.Tables[0].Rows[0]["LAST_INSERT_ID()"]);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Personal.Agregar", this.ToString());
            }
            return last_inserted_id;
        }

        public void Modificar(int id_estacionamiento)
        {
            try
            {
                Logger.EntradaMetodo("Personal.Modificar", this.ToString());

                base.Modificar();

                var comando = new MySqlCommand() { CommandText = "Personal_estacionamiento_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inIdPersonal", this.ID);
                comando.Parameters.AddWithValue("inIdEstacionamiento", id_estacionamiento);
                comando.Parameters.AddWithValue("inIdRol", this.Rol);
                Data.Ejecutar(comando);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Personal.Modificar", this.ToString());
            }

            

        }

        /// <summary>
        /// convierte el atributo Rol en un numero,
        /// para insertar el rol como int en la bd       
        /// </summary>
        /// <returns></returns>
        public int RolToInt()
        {            
            switch (this.Rol.ToString())
            {
                case "Propietario":
                    return 1;                    
                case "Encargado":
                    return 2;                    
                case "Aparcador":
                    return 3;
                 case "Secretaria":
                    return 4;
                case "Guardia":
                    return 5;
                default:
                    break;
            }
            return 0;
        }
        

    }

}