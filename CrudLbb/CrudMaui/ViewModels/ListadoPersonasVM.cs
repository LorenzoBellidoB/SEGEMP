using BL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class ListadoPersonasVM
    {
        private List<ClsPersona> listadoPersonas = new List<ClsPersona>();


        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                listadoPersonas = ClsListadosBl.ListadoCompletoPersonasBl();
                return listadoPersonas;
            }
        }
    }
}
