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
        /// 
        /// si retorna cero, es porque existe un Personal asociado al mismo Usuario
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
                last_inserted_id = Convert.ToInt32(data.Tables[0].Rows[0]["ultimo_id_insertado"]);
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

        public bool Seleccionar(int id_personal)
        {
            try
            {
                Logger.EntradaMetodo("Personal.Seleccionar", this.ToString());
            
                var comando = new MySqlCommand() { CommandText = "Personal_Seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inId_personal", id_personal);
                var data = Data.Obtener(comando);
                DataTable dt = data.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0]; 
                    this.ID = Convert.ToInt32(dr["id_personal"]);
                    this.Rut = Convert.ToInt32(dr["rut"]);
                    this.Nombre = Convert.ToString(dr["nombre"]);
                    this.Email = Convert.ToString(dr["email"]);
                    this.Contraseña = Convert.ToString(dr["contrasenia"]);
                    this.Telefono = Convert.ToInt32(dr["telefono"]);
                }
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Personal.Seleccionar", this.ToString());
            }
            return false;
        }


        /// <summary>
        /// Se retorna el id del Personal,
        /// asociado a un Usuario especifico.
        /// </summary>
        /// <returns></returns>
        public int Buscar()
        {
            int last_inserted_id = 0;
            try
            {
                Logger.EntradaMetodo("Personal.Buscar", this.ToString());
                var comando = new MySqlCommand() { CommandText = "Personal_Buscar", CommandType = System.Data.CommandType.StoredProcedure };
                comando.Parameters.AddWithValue("inId_usuario", this.Rut);

                var data = Data.Obtener(comando);
                last_inserted_id = Convert.ToInt32(data.Tables[0].Rows[0]["Personal_Id"]);
            }
            catch (Exception ex)
            {
                Logger.Excepcion(ex);
            }
            finally
            {
                Logger.SalidaMetodo("Personal.Buscar", this.ToString());
            }
            return last_inserted_id;
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
                    return 0;//porque el indice del enum empieza de cero
                case "Encargado":
                    return 1;
                case "Aparcador":
                    return 2;
                case "Secretaria":
                    return 3;
                case "Guardia":
                    return 4;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// retorna una lista de string con todos los roles
        /// que puede tener un personal
        /// </summary>
        /// <returns> </returns>
        public List<string> ErolEnumToList()
        {
            var erolNameList = Enum.GetNames(typeof(Erol)).ToList();
            return erolNameList;
        }

    }

}