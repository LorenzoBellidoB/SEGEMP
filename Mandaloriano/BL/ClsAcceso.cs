using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsAcceso
    {
        /// <summary>
        /// Método que devuelve un listado de misiones en función a las normas implementadas
        /// </summary>
        /// <returns></returns>
        public static List<ClsMision> ListadoCompletoMisionesBl()
        {
            List<ClsMision> listado = ClsListado.ListadoCompletoMisionesDal();

            return listado;
        }

        public static ClsMision MisionSelectedBl(int id)
        {
            ClsMision m = ClsListado.MisionSelectedDal(id);

            return m;
        }
    }
}
