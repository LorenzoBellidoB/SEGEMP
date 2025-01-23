using ENT;

namespace DAL
{
    public class ClsListadoDal
    {
        private static List<ClsPersonaje> listadoPersonajes = new List<ClsPersonaje>
        {
        new ClsPersonaje(1, "Ahri", new DateTime(1990, 3, 5), 1),
        new ClsPersonaje(2, "Yasuo", new DateTime(1988, 9, 15), 2),
        new ClsPersonaje(3, "Jinx", new DateTime(1995, 12, 10), 1),
        new ClsPersonaje(4, "Thresh", new DateTime(1980, 7, 20), 2),
        new ClsPersonaje(5, "Lux", new DateTime(1996, 1, 10), 1),
        new ClsPersonaje(6, "Zed", new DateTime(1989, 11, 2), 3),
        new ClsPersonaje(7, "Ezreal", new DateTime(1997, 4, 16), 1),
        new ClsPersonaje(8, "Riven", new DateTime(1992, 6, 21), 3),
        new ClsPersonaje(9, "Katarina", new DateTime(1991, 9, 4), 3),
        new ClsPersonaje(10, "Garen", new DateTime(1985, 5, 12), 1),
        new ClsPersonaje(11, "Akali", new DateTime(1993, 8, 9), 3),
        new ClsPersonaje(12, "Draven", new DateTime(1990, 10, 31), 2),
        new ClsPersonaje(13, "Kai'Sa", new DateTime(1999, 2, 18), 1),
        new ClsPersonaje(14, "Leona", new DateTime(1994, 7, 13), 3),
        new ClsPersonaje(15, "Darius", new DateTime(1986, 12, 25), 2),
        new ClsPersonaje(16, "Fiora", new DateTime(1992, 3, 3), 1),
        new ClsPersonaje(17, "Shen", new DateTime(1987, 10, 7), 3),
        new ClsPersonaje(18, "Sylas", new DateTime(1990, 11, 18), 2),
        new ClsPersonaje(19, "Jhin", new DateTime(1988, 1, 27), 2),
        new ClsPersonaje(20, "Taliyah", new DateTime(2000, 5, 8), 1)
        };

        private static List<ClsBando> listadoBandos = new List<ClsBando>
        {
        new ClsBando(1,"Piltover"),
        new ClsBando(2,"Zaun"),
        new ClsBando(3,"Policia")
        };

        public static List<ClsPersonaje> GetPersonajes()
        {
            return listadoPersonajes;
        }
        public static ClsPersonaje GetPersonaje(int id)
        {
            return listadoPersonajes.Find(x => x.Id == id);
        }

        public static List<ClsBando> GetBandos()
        {
            return listadoBandos;
        }


        public static ClsBando GetBando(int id)
        {
            return listadoBandos.Find(x => x.Id == id);
        }

        /// <summary>
        /// Añade un personaje al listado de personajes
        /// Pre: El personaje debe tener un id válido
        /// Post: Devueelve true si se ha añadido el personaje y false en caso contrario
        /// </summary>
        /// <param name="personaje">Objeto de tipo personaje</param>
        /// <returns>Devuelve un bool que indica si se ha añadido el personaje</returns>
        public static bool AddPersonaje(ClsPersonaje personaje)
        {
            bool res = false;
            try
            {
                personaje.Id = NextId();
                listadoPersonajes.Add(personaje);
                res = true;
            }catch (Exception ex) {
                res = false;
            }
            return res;
        }

        public static bool UpdatePersonaje(int id, ClsPersonaje personajeEditado)
        {
            bool res = false;
            try
            {
                ClsPersonaje personaje = GetPersonaje(id);
                int index = listadoPersonajes.IndexOf(personaje);
                personaje.Nombre = personajeEditado.Nombre;
                personaje.FechaNac = personajeEditado.FechaNac;
                personaje.IdBando = personajeEditado.IdBando;
                listadoPersonajes[index] = personaje;
                res = true;
            }
            catch (Exception ex) { 
                res = false;
            }
            return res;
        }

        public static bool DeletePersonaje(int id)
        {
            bool res = false;
            try
            {
                ClsPersonaje personaje = GetPersonaje(id);
                listadoPersonajes.Remove(personaje);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        private static int NextId()
        {
            int idMax;
            idMax = listadoPersonajes.Last().Id;
            return idMax + 1;
        }
    }
}
