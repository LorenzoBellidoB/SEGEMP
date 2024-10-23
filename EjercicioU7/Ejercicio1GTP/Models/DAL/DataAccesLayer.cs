using Ejercicio1GTP.Models.ENT;

namespace Ejercicio1GTP.Models.DAL
{
    public static class DataAccessLayer
    {
        private static List<clsDepartamento> departamentos = new List<clsDepartamento>
    {
        new clsDepartamento { IdDepartamento = 1, NombreDepartamento = "Recursos Humanos" },
        new clsDepartamento { IdDepartamento = 2, NombreDepartamento = "Desarrollo" },
        new clsDepartamento { IdDepartamento = 3, NombreDepartamento = "Marketing" }
    };

        private static List<PersonaViewModel> personas = new List<PersonaViewModel>
    {
        new PersonaViewModel { Id = 1, Nombre = "Juan", Apellidos = "Pérez", IdDepartamento = 1 },
        new PersonaViewModel { Id = 2, Nombre = "Ana", Apellidos = "García", IdDepartamento = 2 },
        new PersonaViewModel { Id = 3, Nombre = "Luis", Apellidos = "Martínez", IdDepartamento = 3 }
    };

        public static PersonaViewModel ObtenerPersonaAleatoria()
        {
            Random rnd = new Random();
            int index = rnd.Next(personas.Count);
            return personas[index];
        }

        public static List<clsDepartamento> ObtenerDepartamentos()
        {
            return departamentos;
        }
    }
}
