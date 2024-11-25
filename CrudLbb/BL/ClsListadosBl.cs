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
        public static List<ClsPersona> ListadoCompletoPersonasBl()
        {
            List<ClsPersona> personas = ClsListados.ListadoCompletoPersonasDal();

            return personas;
        }

        public static List<ClsDepartamento> ListadoCompletoDepartamentosBl()
        {
            List<ClsDepartamento> departamentos = ClsListados.ListadoCompletoDepartamentosDal();

            return departamentos;
        }
    }
}
