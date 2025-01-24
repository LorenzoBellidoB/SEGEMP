using DAL;
using ENT;

namespace BL
{
    public class ClsListadosBl
    {
        /// <summary>
        /// Función que devuelve el listado completo de las personas según las normas del negocio
        /// Pre: None
        /// Post: Puede ser null si el listado está vacio
        /// </summary>
        /// <returns>Devuelve un listado de tipo ClsPersona</returns>
        public static List<ClsPersona> GetPersonas()
        {
            return ClsListadoDal.GetPersonas();
        }
        /// <summary>
        /// Función que devuelve el listado completo de los departamentos según las normas del negocio
        /// Pre: None
        /// Post: Puede ser null si el listado está vacio
        /// </summary>
        /// <returns>Devuelve un listado de tipo ClsDepartamentos</returns>
        public static List<ClsDepartamento> GetDepartamentos()
        {
            return ClsListadoDal.GetDepartamentos();
        }

        /// <summary>
        /// Función que devuelve una persona según su id según las normas del negocio
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si no se encuentra a la persona
        /// </summary>
        /// <param name="id">Entero que hace referencia al numero de id de la persona</param>
        /// <returns>Devuelve un objeto de tipo persona</returns>
        public static ClsPersona GetPersona(int id)
        {
            return ClsListadoDal.GetPersona(id);
        }

        /// <summary>
        /// Función que devuelve un departamento según su id según las normas del negocio
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si no se encuentra al departamento
        /// </summary>
        /// <param name="id">Entero que hace referencia al numero de id del departamento</param>
        /// <returns>Devuelve un objeto de tipo departamento</returns>
        public static ClsDepartamento GetDepartamento(int id) 
        {
            return ClsListadoDal.GetDepartamento(id);
        }

        /// <summary>
        /// Funcion que devuelve un listado de personas según su departamento según las reglas del negocio
        /// Pre: Id del departamento válido
        /// Post: Puede devolver null si no existe el departamento o no hay personas en dicho departamento
        /// </summary>
        /// <param name="idDpt">Entero que hace referencia al id del departamento</param>
        /// <returns>Devuelve un listado de tipo ClsPersona con las personas del mismo departamento</returns>
        public static List<ClsPersona> GetPersonaDepartamento(int idDpt)
        {
            List<ClsPersona> listadoPersonas = ClsListadoDal.GetPersonaDepartamento(idDpt);
            List<ClsPersona> listadoPersonasDepartamento = new List<ClsPersona>();

            foreach (ClsPersona persona  in listadoPersonas)
            {
                if (idDpt == 4)
                {
                    if (ComprobarEdad(persona.FechaNacimiento))
                    {
                       listadoPersonasDepartamento.Add(persona);
                    }
                }
                else
                {
                    listadoPersonasDepartamento.Add(persona);
                }
                
            }
            return listadoPersonasDepartamento;
        }

        /// <summary>
        /// Funcion que comprueba la regla de negocio de la edad
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private static bool ComprobarEdad(DateTime fecha)
        {
            bool res = false;
                if((DateTime.Now.Year - fecha.Year) >= 35)
                {
                  res = true;
                }

            return res;
        }
    }
}
