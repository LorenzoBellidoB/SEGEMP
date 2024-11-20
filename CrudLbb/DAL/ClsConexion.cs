using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsConexion
    {
        public SqlConnection ObtenerConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = "server=lorenzo-bellido.database.windows.net;database=LorenzoDB;uid=usuario;pwd=LaCampana123;trustServercertificate = true;";

            miConexion.Open();

            return miConexion;
        }

        public SqlConnection Desconectar()
        {
            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = "server=lorenzo-bellido.database.windows.net;database=LorenzoDB;uid=usuario;pwd=LaCampana123;trustServercertificate = true;";

            miConexion.Close();

            return miConexion;
        }
    }
}
