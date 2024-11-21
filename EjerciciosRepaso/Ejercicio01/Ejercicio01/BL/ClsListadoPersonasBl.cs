using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadoPersonasBl
    {
        /// <summary>
        /// Método que obtiene el listado de personas según las normas de clase
        /// Pre: Ninguno
        /// Post: Puede devolver null si el listado esta vacio o no cumple las normas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<ClsPersona> obtenerPersonasBl()
        {
            List<ClsPersona> listadoPersonas = ClsListadoPersonasDal.obtenerPersonasDal();

            return listadoPersonas;
        }
    }
}
