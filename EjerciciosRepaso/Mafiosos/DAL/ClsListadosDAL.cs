using ENT;

namespace DAL
{
    public class ClsListadosDAL
    {
        // Lista de las misiones 
        private static List<ClsMision> listadoMisiones = new List<ClsMision>
        {
            new ClsMision(1, "Robo al banco central", 10000.0, 1),
            new ClsMision(2, "Protección del capo", 5000.0, 2),
            new ClsMision(3, "Extorsión de negocios locales", 3000.0, 3),
            new ClsMision(4, "Infiltración en banda rival", 8000.0, 4),
            new ClsMision(5, "Entrega de mercancía", 2000.0, 5),
            new ClsMision(6, "dadad", 10000.0, 1),
            new ClsMision(7, "gfgfg", 5000.0, 2),
            new ClsMision(8, "jhjh", 3000.0, 3),
            new ClsMision(9, "fdsf", 8000.0, 4),
            new ClsMision(10, "hghgh", 2000.0, 5),
        };
        // Lista de los Mafiosos
        private static List<ClsMafioso> listadoMafiosos = new List<ClsMafioso>
        {
            new ClsMafioso(1, "Vito", new DateTime(1920, 5, 12), "Corleone"),
            new ClsMafioso(2, "Michael", new DateTime(1945, 3, 23), "Corleone"),
            new ClsMafioso(3, "Tom", new DateTime(1940, 7, 19), "Hagen"),
            new ClsMafioso(4, "Sonny", new DateTime(1935, 10, 10), "Corleone"),
            new ClsMafioso(5, "Fredo", new DateTime(1940, 8, 10), "Corleone")
        };

        /// <summary>
        /// Funcion para mandar la lista llena de mafiosos
        /// <Pre><Pre>
        /// <Post>Te devulve la lista pero puede ser null</Post>
        /// </summary>
        /// <returns>Devuelve la lista llena</returns>
        public static List<ClsMafioso> obtenerTodosLosMafiososDAL()
        {

            List<ClsMafioso> lista = listadoMafiosos;

            return lista;

        }


        /// <summary>
        /// Funcion para obtener la lista de misiones que tiene cada Mafioso
        /// pre: Obtendra un idMafioso mayor que 0
        /// post: Lista devuelta puede ser vacia si no hay misiones
        /// </summary>
        /// <param name="idMafioso"></param>
        /// <returns>Devuelve una lista de misiones de un mafioso</returns>
        public static List<ClsMision> obtenerMisionesDeIdMafiosoDAL(int idMafioso)
        {

            List<ClsMision> listaMisionesDeMafioso = new List<ClsMision> ();

            foreach(ClsMision clsMision in listadoMisiones)
            {

                if (clsMision.idMafioso == idMafioso)
                {
                    listaMisionesDeMafioso.Add(clsMision);
                }

            }

            return listaMisionesDeMafioso;

        }
        /// <summary>
        /// Funcion para obtener el Mafioso por id
        /// pre: Obtendra un idMafioso mayor que 0
        /// post: Devuelve un Mafioso si no lo encuentra estara vacio
        /// </summary>
        /// <param name="idMafioso"></param>
        /// <returns>Devuelve un objeto ClsMafioso que corresponde con el id pasado por parametro</returns>
        public static ClsMafioso obtenerMafiosoPorIdDAL(int idMafioso)
        {

            ClsMafioso mafiosoEncontrado = new ClsMafioso ();

            foreach(ClsMafioso mafioso in listadoMafiosos)
            {
                if(mafioso.Id== idMafioso)
                {
                    mafiosoEncontrado=mafioso;
                }
            }

            return mafiosoEncontrado;

        }
        /// <summary>
        /// Funcion para borra el mafioso encontrado por su id
        /// pre: Obtendra un idMafioso mayor que 0
        /// post: Devuelve el bool y si no puede hacerlo te lo manda en false
        /// </summary>
        /// <param name="idMafioso"></param>
        /// <returns>Devuelve un bool que te dice si lo ha borrado o no</returns>
        public static bool borrarMafiosoPorIdDAL(int idMafioso)
        {
           
            bool borrar = false;
            ClsMafioso mafiosoABorrar = listadoMafiosos.First(m=> m.Id== idMafioso);
            

            if (mafiosoABorrar != null)
            {
                
                listadoMafiosos.Remove(mafiosoABorrar);
                foreach(ClsMision mision in listadoMisiones)
                {
                    if (mision.idMafioso == idMafioso)
                    {
                        listadoMisiones.Remove(mision);
                    }
                }
                borrar = true; 
            }


            
            return borrar;
        }
    }
}
