using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsServiciosBl
    {
        /// <summary>
        /// Método que devuelve una persona según las normas de la empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsPersona buscarPersonaBl(int id)
        {
            ClsPersona persona = ClsServiciosDal.buscarPersonaDal(id);

            return persona;
        }

        /// <summary>
        /// Método que borra una persona de la base de datos según las normas de la empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int deletePersonaBl(int id)
        {
            int row = 0;

            row = ClsServiciosDal.deletePersonaDal(id);

            return row;
        }

        /// <summary>
        /// Método que inserta una persona de la base de datos según las normas de la empresa
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int insertarPersonaBl(ClsPersona persona)
        {
            int row = 0;
        
            row = ClsServiciosDal.insertarPersonaDal(persona);

            return row;
        }

        /// <summary>
        /// Método que actualiza una persona de la base de datos según las normas de la empresa
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int updatePersonaBl(ClsPersona persona)
        {
            int row = 0;

            row = ClsServiciosDal.updatePersonaDal(persona);

            return row;
        
        }
    }
}
