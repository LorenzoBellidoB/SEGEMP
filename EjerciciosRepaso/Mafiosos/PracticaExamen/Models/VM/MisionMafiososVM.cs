using BL;
using ENT;

namespace PracticaExamen.Models.VM
{
    public class MisionMafiososVM
    {
        private List<ClsMision> listadoMisiones;

        private ClsMafioso mafioso;

        public List<ClsMision> ListadoMisionesVM
        {
            get { return listadoMisiones; }
        }

        public ClsMafioso MafiosoVM
        {
            get { return mafioso; }
        }

        public MisionMafiososVM(int id) 
        {
            this.listadoMisiones = ClsListadosBL.obtenerMisionesDeIdMafiosoBL(id);
            this.mafioso = ClsListadosBL.obtenerMafiosoPorIdBL(id);
        }
    }
}
