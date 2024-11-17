using DAL01;
using ENT01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL01
{
    public class ListadoPersonasBl
    {
        #region Atributos
        /// <summary>
        /// Atributo para guardar el listado de personas
        /// </summary>
        private static List<ClsPersona> lista = new List<ClsPersona>();
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para obtener el listado de personas según las normas de la empresa
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Ninguna</post>
        /// <returns>Devuelve una lista de tipo ClsPersona</returns>
        public static List<ClsPersona> ObtenerListadoPersonasBl()
        {
            lista = ListadoPersonasDal.ObtenerListadoPersonasDal();

            return lista;
        }
        #endregion
    }
}
