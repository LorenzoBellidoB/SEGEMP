using Ejercicio04.Models.ENT;

namespace Ejercicio04.Models.DAL
{
    public class ClsListado
    {
        private static List<ClsDepartamento> departamentos = new List<ClsDepartamento>
    {
        new ClsDepartamento("Recursos Humanos"),
        new ClsDepartamento("IT"),
        new ClsDepartamento("Marketing")
    };

        private static List<ClsPersona> personas = new List<ClsPersona>
    {
        new ClsPersona { nombre = "Marco", apellidos = "Holguín", idDepartamento = 1 },
        new ClsPersona { nombre = "Hector", apellidos = "Arias", idDepartamento = 2 },
        new ClsPersona { nombre = "Pablo", apellidos = "Carbonero", idDepartamento = 1 },
        new ClsPersona { nombre = "Eduardo", apellidos = "Arnesto", idDepartamento = 2 },
        new ClsPersona { nombre = "Raúl", apellidos = "Romera", idDepartamento = 1 }
    };

        public static ClsPersona ObtenerPersonaAleatoria()
        {
            Random rnd = new Random();
            int index = rnd.Next(personas.Count);
            return personas[index];
        }

        public static List<ClsDepartamento> ObtenerDepartamentos()
        {
            return departamentos;
        }
    }

}

