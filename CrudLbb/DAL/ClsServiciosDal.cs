using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsServiciosDal
    {
        /// <summary>
        /// Devuelve una persona de la base de datos de azure
        /// <pre>Pre: Ninguna</pre>
        /// <post>Post: Puede devolver null cuando no exista la persona</post>
        /// </summary>
        /// <param name="id">Id por el que se busca a la persona</param>
        /// <returns>Devuelve una persona</returns>
        public static ClsPersona buscarPersonaDal(int id)
        {

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona = new ClsPersona();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();

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
                miConexion.Desconectar();
            }
            return oPersona;
        }

        /// <summary>
        /// Borra una persona de la base de datos
        /// <pre>Pre: Ninguna</pre>
        /// <post>Post: Puede devolver 0 si la persona no existe</post>
        /// </summary>
        /// <param name="id">Id por el que se busca a la persona</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int deletePersonaDal(int id)
        {
            int row = 0;


            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miComando.CommandText = "DELETE FROM personas WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();


                row = miComando.ExecuteNonQuery();

               

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Desconectar();
            }
            return row;
        }

        /// <summary>
        /// Inserta una persona en la base de datos
        /// <pre>Pre: Ninguna</pre>
        /// <post>Post: Puede devolver 0 si la hay alguhn fallo en la inserción</post>
        /// </summary>
        /// <param name="oPersona">Persona nueva para insertar en la base de datos</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int insertarPersonaDal(ClsPersona oPersona)
        {
            int row = 0;

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();



            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.Nombre;

            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.Apellidos;

            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.Telefono;

            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.Direccion;

            miComando.Parameters.Add("@fechanacimiento", System.Data.SqlDbType.VarChar).Value = oPersona.FechaNacimiento;

            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;


            try
            {
                miComando.Connection = miConexion.ObtenerConexion();
                miComando.CommandText = "INSERT INTO personas (nombre, apellidos, telefono, direccion, fechanacimiento, iddepartamento) VALUES (@nombre, @apellidos, @telefono, @direccion, @fechanacimiento, @iddepartamento)";

                row = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Desconectar();
            }

            return row;
        }

        /// <summary>
        /// Actualiza una persona en la base de datos
        /// <pre>Pre: Ninguna</pre>
        /// <post>Post: Puede devolver 0 si la hay alguhn fallo en la actualización</post>
        /// </summary>
        /// <param name="oPersona">Persona a actualizar</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int updatePersonaDal(ClsPersona oPersona)
        {
            int row = 0;

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.Nombre;

            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.Apellidos;

            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.Telefono;

            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.Direccion;

            miComando.Parameters.Add("@fechanacimiento", System.Data.SqlDbType.DateTime).Value = oPersona.FechaNacimiento;

            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;


            try
            {
                miComando.CommandText = "UPDATE personas SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Direccion = @direccion, FechaNacimiento = @fechanacimiento, IDDepartamento = @iddepartamento WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();

                row = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Desconectar();
            }

            return row;
        }

        public static ClsDepartamento buscarDepartamentoDal(int id)
        {

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsDepartamento oDept = new ClsDepartamento();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miComando.CommandText = "SELECT * FROM departamentos WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDept = new ClsDepartamento();

                        oDept.Id = (int)miLector["ID"];

                        oDept.Nombre = (string)miLector["Nombre"];

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
            return oDept;
        }
    }
}
