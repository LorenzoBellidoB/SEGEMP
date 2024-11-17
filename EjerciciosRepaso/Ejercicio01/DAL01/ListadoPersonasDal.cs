using ENT01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL01
{
    public class ListadoPersonasDal
    {
        #region Atributos
        /// <summary>
        /// Atributo para guardar el listado de personas
        /// </summary>
        private static List<ClsPersona> lista = new List<ClsPersona>();
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para obtener el listado de personas completo
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Ninguna</post>
        /// <returns>Devuelve una lista de tipo ClsPersona</returns>
        public static List<ClsPersona> ObtenerListadoPersonasDal()
        {
            lista.Add(new ClsPersona(1, "Lorenzo", "Bellido", DateTime.Parse("13/02/2005")));
            lista.Add(new ClsPersona(2, "Marco", "Holguin", DateTime.Parse("29/12/2005")));
            lista.Add(new ClsPersona(3, "Jose", "Mendez", DateTime.Parse("18/05/2014")));
            lista.Add(new ClsPersona(4, "Miguel", "Ponce", DateTime.Parse("13/11/1998")));
            lista.Add(new ClsPersona(5, "Maria", "Mendez", DateTime.Parse("20/05/2000")));

            return lista;
        }
        #endregion
    }
}
