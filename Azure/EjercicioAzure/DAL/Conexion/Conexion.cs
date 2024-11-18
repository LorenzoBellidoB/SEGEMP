using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    public class Conexion
    {
        
        public SqlConnection ObtenerConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {
                
                miConexion.ConnectionString = "server=lorenzo-bellido.database.windows.net;database=LorenzoDB;uid=usuario;pwd=LaCampana123;trustServercertificate = true;";

                miConexion.Open();
            }
            catch (Exception ex)
            {
                throw;
            }

            return miConexion;
            
        }

        public SqlConnection Desconectar()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {

                miConexion.ConnectionString = "server=lorenzo-bellido.database.windows.net;database=LorenzoDB;uid=usuario;pwd=LaCampana123;trustServercertificate = true;";

                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return miConexion;
        }
    }
}
