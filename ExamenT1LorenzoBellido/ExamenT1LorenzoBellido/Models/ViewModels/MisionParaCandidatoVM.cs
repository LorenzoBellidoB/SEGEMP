using BL;
using ENT;

namespace ExamenT1LorenzoBellido.Models.ViewModels
{
    public class MisionParaCandidatoVM
    {
        #region Atributos
        public List<ClsMision> listadoMisionesVm;
        
        private List<ClsCandidato> listadoCandidatoVm;
        #endregion
        #region Propiedades
        public List<ClsMision> ListadoMisionesVM { get { return listadoMisionesVm; } }

        public List<ClsCandidato> ListadoCandidatosVM { get {return listadoCandidatoVm; } }
        #endregion

        #region Constructores

        public MisionParaCandidatoVM() 
        {
            listadoMisionesVm = ClsListadosBl.obtenerListadoMisionesBl();
        }

        public MisionParaCandidatoVM(int idMision)
        {
            listadoMisionesVm = ClsListadosBl.obtenerListadoMisionesBl();
            listadoCandidatoVm = ClsListadosBl.obtenerListadoCandidatosBl(idMision);
        }

        #endregion
    }
}
