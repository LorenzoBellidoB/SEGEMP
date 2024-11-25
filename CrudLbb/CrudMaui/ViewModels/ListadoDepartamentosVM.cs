using BL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class ListadoDepartamentosVM
    {
        private List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();


        public List<ClsDepartamento> ListadoDepartamentos
        {
            get
            {
                listadoDepartamentos = ClsListadosBl.ListadoCompletoDepartamentosBl();
                return listadoDepartamentos;
            }
        }
    }
}
