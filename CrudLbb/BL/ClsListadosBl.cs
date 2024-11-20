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
        public List<ClsPersona> ListadoCompletoBl()
        {
            List<ClsPersona> personas = ClsListados.ListadoCompletoDal();

            return personas;
        }
    }
}
