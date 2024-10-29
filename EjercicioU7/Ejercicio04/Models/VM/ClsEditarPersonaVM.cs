using Ejercicio04.Models.DAL;
using Ejercicio04.Models.ENT;

namespace Ejercicio04.Models.VM
{
    public class ClsEditarPersonaVM : ClsPersona
    {
        public List<ClsDepartamento> Departamentos { get; }

        // Constructor
        public ClsEditarPersonaVM()
        {
            // Llenar el listado de departamentos al iniciar el ViewModel
            Departamentos = ClsListado.ObtenerDepartamentos(); 
        }
    }
}
