using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadosBl
    {
        /// <summary>
        /// Te devuelve el listado de personas según las normas de la empresa
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ListadoCompletoBl()
        {
            List<ClsPersona> personas = ClsListados.ListadoCompletoDal();

            return personas;
        }
    }
}
