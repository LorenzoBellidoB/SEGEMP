using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoDal
    {
        /// <summary>
        /// Devuelve un listado de personas
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ListadoCompletoDal()
        {
            List<ClsPersona> personas = new List<ClsPersona>();

            SqlConnection miConexion= new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
                miConexion = Conexion.ClsConexion.ObtenerConexion();

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();

                        oPersona.Id = (int)miLector["ID"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellidos = (string)miLector["Apellidos"];


                        oPersona.Direccion = (string)miLector["Direccion"];

                        oPersona.Telefono = (string)miLector["Telefono"];

                        oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["foto"] != System.DBNull.Value)

                        { oPersona.Foto = (string)miLector["Foto"]; }

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"]; }

                        personas.Add(oPersona);
                    }               
                }
                miLector.Close();
                

            }catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }
                return personas;
        }
    }
}
