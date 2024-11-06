using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListado
    {
        /// <summary>
        /// Método que devuelve un listado de misiones
        /// </summary>
        /// <returns></returns>
        public static List<ClsMision> ListadoCompletoMisionesDal()
        {
            List<ClsMision> listado = new List<ClsMision>();

            return listado;
        }

        /// <summary>
        /// Método que devuelve la misión seleccionada en el listado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsMision MisionSelectedDal(int id)
        {
            ClsMision m = new ClsMision();

            return m;
        }
    }
}
