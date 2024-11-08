using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class HourException: Exception
    {
        public HourException() 
        {

        }

        public HourException(string mensage): base(mensage)
        {
            
        }
    }
}
