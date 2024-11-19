using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListado
    {
        /// <summary>
        /// Método que devuelve un listado de misiones
        /// </summary>
        /// <returns>Listado con todas las misiones</returns>
        public static List<ClsMision> ListadoCompletoMisionesDal()
        {
            List<ClsMision> listado = new List<ClsMision>();
            
            ClsMision m1 = new ClsMision();
            m1.IdMision = 1;
            m1.Titulo = "Rescate de Baby Yoda";
            m1.Descripcion = "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.";
            m1.Recompensa = 5000;
            ClsMision m2 = new ClsMision();
            m2.IdMision = 2;
            m2.Titulo = "Recuperar armadura Beskar";
            m2.Descripcion = "Tu armadura de Beskar ha sido robada. Debes encontrarla.";
            m2.Recompensa = 2000;
            ClsMision m3 = new ClsMision();
            m3.IdMision = 3;
            m3.Titulo = "Planeta Sorgon";
            m3.Descripcion = "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.";
            m3.Recompensa = 500;
            ClsMision m4 = new ClsMision();
            m4.IdMision = 4;
            m4.Titulo = "Renacuajos";
            m4.Descripcion = "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.";
            m4.Recompensa = 500;

            listado.Add(m1);
            listado.Add(m2);
            listado.Add(m3);   
            listado.Add(m4);

            return listado;
        }

        /// <summary>
        /// Método que devuelve la misión seleccionada en el listado
        /// </summary>
        /// <param name="id">Id de la mision seleccionada</param>
        /// <returns></returns>
        public static ClsMision MisionSelectedDal(int id)
        {
            ClsMision mision = new ClsMision();
            List<ClsMision> lista = ListadoCompletoMisionesDal();
            bool encontrado = false;

            int i = 0;

            while (i < lista.Count && !encontrado)
            {
                if (lista[i].IdMision == id)
                {
                    mision = lista[i];
                    encontrado = true;
                }
                i++;
            }
            
            return mision;
        }
    }
}
