using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Clase de acceso a la base de datos 
    /// </summary>
    public class ListadoDal
    {
        /// <summary>
        /// Devuelve un listado de personas de la base de datos de azure
        /// </summary>
        /// <returns>listado de personas</returns>
        public static List<ClsPersona> ListadoCompletoDal()
        {
            List<ClsPersona> personas = new List<ClsPersona>();

            SqlConnection miConexion = new SqlConnection();

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


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }
            return personas;
        }

        public static ClsPersona DetallesPersonaDal(int id)
        {
            List<ClsPersona> personas = ListadoCompletoDal();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona = new ClsPersona();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = Conexion.ClsConexion.ObtenerConexion();

                miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";

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
                miConexion.Close();
            }
            return oPersona;
        }

        public static int DeletePersonaDal(int id)
        {
            int row = 0;

            List<ClsPersona> personas = ListadoCompletoDal();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = Conexion.ClsConexion.ObtenerConexion();

                miComando.CommandText = "DELETE FROM personas WHERE ID = @id";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                foreach (ClsPersona persona in personas)
                {
                    if (persona.Id == id)
                    {
                        personas.Remove(persona);
                        row++;
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
                miConexion.Close();
            }
            return row;
        }
    }
}
