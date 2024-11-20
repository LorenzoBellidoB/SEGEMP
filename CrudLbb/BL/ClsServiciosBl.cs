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
        public static ClsPersona BuscarPersonaBl(int id)
        {
            ClsPersona persona = ClsServiciosBl.BuscarPersonaBl(id);

            return persona;
        }
    }
}
