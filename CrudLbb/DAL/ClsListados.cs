using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListados
    {
        /// <summary>
        /// Devuelve un listado de personas de la base de datos de azure
        /// </summary>
        /// <returns>listado de personas</returns>
        public static List<ClsPersona> ListadoCompletoDal()
        {
            List<ClsPersona> personas = new List<ClsPersona>();

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
               

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion.ObtenerConexion(); ;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();

                        oPersona.Id = (int)miLector["ID"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellidos = (string)miLector["Apellidos"];

                        if (miLector["Direccion"] != System.DBNull.Value)

                        { oPersona.Foto = (string)miLector["Direccion"]; }

                        if (miLector["Telefono"] != System.DBNull.Value)

                        { oPersona.Foto = (string)miLector["Telefono"]; }

                        if (miLector["IDDepartamento"] != System.DBNull.Value)

                        { oPersona.Foto = (string)miLector["IDDepartamento"]; }

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["foto"] != System.DBNull.Value)

                        { oPersona.Foto = (string)miLector["Foto"]; }

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"]; }

                        personas.Add(oPersona);
                    }
                }
                miLector.Close();


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Desconectar();
            }
            return personas;
        }
    }
}
