using DAL;
using ENT;

namespace BL
{
    public class ClsListadoBl
    {
        public static List<ClsPersonaje> GetPersonajes()
        {
            return ClsListadoDal.GetPersonajes();
        }

        public static List<ClsBando> GetBandos()
        {
            return ClsListadoDal.GetBandos();
        }

        public static ClsPersonaje GetPersonaje(int id)
        {
            return ClsListadoDal.GetPersonaje(id);
        }

        public static ClsBando GetBando(int id)
        {
            return ClsListadoDal.GetBando(id);
        }

        public static bool AddPersonaje(ClsPersonaje personaje)
        {
            return ClsListadoDal.AddPersonaje(personaje);
        }

        public static bool UpdatePersonaje(int id, ClsPersonaje personaje)
        {
            return ClsListadoDal.UpdatePersonaje(id ,personaje);
        }

        public static bool DeletePersonaje(int id)
        {
            return ClsListadoDal.DeletePersonaje(id);
        }

        private static bool EnHorario()
        {
            DateTime horaActual = DateTime.Now;
            bool hora = false;
            if (horaActual.Hour >= 8 && horaActual.Hour <= 21)
            {
                hora = true;
            }
            else
            {
                hora = false;
            }
            return hora;
        }
    }
}
