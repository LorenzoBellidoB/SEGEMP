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
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Puede devolver null cuando no exista la persona</post>
        /// <param name="id">Id por el que se busca a la persona</param>
        /// <returns>Devuelve una persona</returns>
        public static ClsPersona BuscarPersonaDal(int id)
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
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Puede devolver 0 si la persona no existe</post>
        /// <param name="id">Id por el que se busca a la persona</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int DeletePersonaDal(int id)
        {
            int row = 0;


            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miComando.CommandText = "DELETE FROM personas WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();

                miLector = miComando.ExecuteReader();

                row = miComando.ExecuteNonQuery();

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
            return row;
        }

        /// <summary>
        /// Inserta una persona en la base de datos
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Puede devolver 0 si la hay alguhn fallo en la inserción</post>
        /// <param name="oPersona">Persona nueva para insertar en la base de datos</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int InsertarPersonaDal(ClsPersona oPersona)
        {
            int row = 0;

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;


            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.Int).Value = oPersona.Nombre;

            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.Int).Value = oPersona.Apellidos;

            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = oPersona.Telefono;

            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.Int).Value = oPersona.Direccion;

            miComando.Parameters.Add("@fechanacimiento", System.Data.SqlDbType.Int).Value = oPersona.FechaNacimiento;

            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;


            try
            {
                miComando.CommandText = "INSERT FROM personas VALUES (@nombre,@apellidos,@telefono,@direccion,@fechanacimiento,@iddepartamento)";

                miComando.Connection = miConexion.ObtenerConexion();

                miLector = miComando.ExecuteReader();

                row = miComando.ExecuteNonQuery();

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

            return row;
        }

        /// <summary>
        /// Actualiza una persona en la base de datos
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Puede devolver 0 si la hay alguhn fallo en la actualización</post>
        /// <param name="oPersona">Persona a actualizar</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int UpdatePersonaDal(ClsPersona oPersona)
        {
            int row = 0;

            ClsConexion miConexion = new ClsConexion();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = oPersona.Id;

            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.Int).Value = oPersona.Nombre;

            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.Int).Value = oPersona.Apellidos;

            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = oPersona.Telefono;

            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.Int).Value = oPersona.Direccion;

            miComando.Parameters.Add("@fechanacimiento", System.Data.SqlDbType.Int).Value = oPersona.FechaNacimiento;

            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;


            try
            {
                miComando.CommandText = "UPDATE FROM personas  SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Direccion = @direccion, FechaNacimiento = @fechanacimiento, IDDepartamento = @iddepartamento WHERE ID = @id";

                miComando.Connection = miConexion.ObtenerConexion();

                miLector = miComando.ExecuteReader();

                row = miComando.ExecuteNonQuery();

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

            return row;
        }
    }
}
