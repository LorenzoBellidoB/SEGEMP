using DAL;
using ENT;

namespace BL
{
    public class ClsListadosBL
    {

        public static List<ClsMafioso> obtenerTodosLosMafiososBL()
        {

            return ClsListadosDAL.obtenerTodosLosMafiososDAL();

        }
        

        public static List<ClsMision> obtenerMisionesDeIdMafiosoBL(int idMafioso)
        {
           
            return ClsListadosDAL.obtenerMisionesDeIdMafiosoDAL(idMafioso);

        }

        public static ClsMafioso obtenerMafiosoPorIdBL(int idMafioso)
        {

            return ClsListadosDAL.obtenerMafiosoPorIdDAL(idMafioso);

        }

        public static bool borrarMafiosoPorIdDAL(int idMafioso)
        {
            return ClsListadosDAL.borrarMafiosoPorIdDAL(idMafioso);
        }
    }
}
