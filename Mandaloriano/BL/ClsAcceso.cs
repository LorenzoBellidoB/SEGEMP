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
        /// <returns>Listado con todas las misiones</returns>
        public static List<ClsMision> ListadoCompletoMisionesBl()
        {
            List<ClsMision> listado;
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 8)
            {
                listado = null;
                
            }
            else
            {
                listado = ClsListado.ListadoCompletoMisionesDal();
            }

            return listado;
        }
        /// <summary>
        /// Devuelve la mision seleccionada
        /// </summary>
        /// <param name="id">Id de la misión seleccionada</param>
        /// <returns></returns>
        public static ClsMision MisionSelectedBl(int id)
        {
            ClsMision mision = ClsListado.MisionSelectedDal(id);

            return mision;
        }
    }
}
