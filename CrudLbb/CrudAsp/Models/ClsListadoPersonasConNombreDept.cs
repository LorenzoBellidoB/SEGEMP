using BL;
using ENT;

namespace CrudAsp.Models
{
    public class ClsListadoPersonasConNombreDept
    {
        #region Atributos
        private List<ClsPersona> listadoPersonas;
        private List<ClsPersonaConNombreDepartamento> listadoPersonasNombreDept = new List<ClsPersonaConNombreDepartamento>();
        #endregion

        public List<ClsPersonaConNombreDepartamento> ListadoPersonasNombreDept
        {
            get
            {
                return listadoPersonasNombreDept;
            }
        }

        public ClsListadoPersonasConNombreDept()
        {
            listadoPersonas = ClsListadosBl.ListadoCompletoPersonasBl();
            List<ClsDepartamento> departamentos = ClsListadosBl.ListadoCompletoDepartamentosBl();

            listadoPersonasNombreDept = new List<ClsPersonaConNombreDepartamento>();

            foreach (ClsPersona persona in listadoPersonas)
            {
                ClsPersonaConNombreDepartamento personaConNombreDepartamento= new ClsPersonaConNombreDepartamento(persona, departamentos);
                listadoPersonasNombreDept.Add(personaConNombreDepartamento);
            }
        }
    }
}
