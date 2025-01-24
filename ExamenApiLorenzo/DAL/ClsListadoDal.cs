using ENT;

namespace DAL
{
    public class ClsListadoDal
    {
        private static List<ClsPersona> listadoPersonas = new List<ClsPersona>
        {
            new ClsPersona (1,"Lorenzo","Bellido","234546671", "Sevilla", "", DateTime.Parse("13/02/2005"),1),
            new ClsPersona (2,"Marco","Holguin","234546672", "Sevilla", "", DateTime.Parse("01/01/2005"),1),
            new ClsPersona (3,"Raul","Romera","234546673", "Sevilla", "", DateTime.Parse("01/01/2004"),2),
            new ClsPersona (4,"Pablo","Carbonero","234546674", "Sevilla", "", DateTime.Parse("01/01/2003"),2),
            new ClsPersona (5,"Hector","Arias","234546675", "La Campana", "", DateTime.Parse("01/01/2005"),3),
            new ClsPersona (6,"Edu","Arnesto","234546676", "Sevilla", "", DateTime.Parse("01/01/2005"),4),
            new ClsPersona (7,"Amaro","Suarez","234546677", "Sevilla", "", DateTime.Parse("01/01/1990"),4),
            new ClsPersona (8,"Ruben","Ruiz","234546678", "Sevilla", "", DateTime.Parse("01/01/1979"),4),
            new ClsPersona (9,"Carlos","Garcia","234546679", "Madrid", "", DateTime.Parse("01/01/2000"),3),
            new ClsPersona (10,"Antonio","Vizarraga","234546680", "Sevilla", "", DateTime.Parse("01/01/1982"),2),
        };

        private static List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>
        {
            new ClsDepartamento(1,"Ventas"),
            new ClsDepartamento(2,"Marketing"),
            new ClsDepartamento(3,"Desarrollo"),
            new ClsDepartamento(4,"Recursos Humanos"),
        };

        /// <summary>
        /// Función que devuelve el listado completo de las personas
        /// Pre: None
        /// Post: Puede ser null si el listado está vacio
        /// </summary>
        /// <returns>Devuelve un listado de tipo ClsPersona</returns>
        public static List<ClsPersona> GetPersonas()
        {
            return listadoPersonas;
        }
        /// <summary>
        /// Función que devuelve el listado completo de los departamentos
        /// Pre: None
        /// Post: Puede ser null si el listado está vacio
        /// </summary>
        /// <returns>Devuelve un listado de tipo ClsDepartamentos</returns>
        public static List<ClsDepartamento> GetDepartamentos()
        {
            return listadoDepartamentos;
        } 

        /// <summary>
        /// Función que devuelve una persona según su id
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si no se encuentra a la persona
        /// </summary>
        /// <param name="id">Entero que hace referencia al numero de id de la persona</param>
        /// <returns>Devuelve un objeto de tipo persona</returns>
        public static ClsPersona GetPersona(int id)
        {
            ClsPersona persona = listadoPersonas.Find(x => x.Id == id);
            return persona;
        }
        /// <summary>
        /// Función que devuelve un departamento según su id
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si no se encuentra al departamento
        /// </summary>
        /// <param name="id">Entero que hace referencia al numero de id del departamento</param>
        /// <returns>Devuelve un objeto de tipo departamento</returns>
        public static ClsDepartamento GetDepartamento(int id)
        {
            ClsDepartamento departamento = listadoDepartamentos.Find(x =>x.Id == id);
            return departamento;
        }

        /// <summary>
        /// Funcion que devuelve un listado de personas según su departamento
        /// Pre: Id del departamento válido
        /// Post: Puede devolver null si no existe el departamento o no hay personas en dicho departamento
        /// </summary>
        /// <param name="idDpt">Entero que hace referencia al id del departamento</param>
        /// <returns>Devuelve un listado de tipo ClsPersona con las personas del mismo departamento</returns>
        public static List<ClsPersona> GetPersonaDepartamento(int idDpt)
        {
            List<ClsPersona> listadoPersonaDpt = new List<ClsPersona>();
            foreach (ClsPersona persona in listadoPersonas)
            {
                if(persona.IdDepartamento == idDpt)
                {
                    listadoPersonaDpt.Add(persona);
                }
            }
            return listadoPersonaDpt;
        }
    }
}
