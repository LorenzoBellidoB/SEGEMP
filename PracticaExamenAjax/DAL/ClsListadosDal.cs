using ENT;

namespace DAL
{
    public class ClsListadosDal
    {
        private static List<ClsPersona> listaPersonas = new List<ClsPersona>
        {
            new ClsPersona(1,"Hector","La Campana",2),
            new ClsPersona(2,"Raul","Los Pajaritos",3),
            new ClsPersona(3,"Eduardo","La Campana",4),
            new ClsPersona(4,"Lorenzo","Sevilla",1),
        };
        private static List<ClsDepartamento> listaDepartamentos = new List<ClsDepartamento>
        {
            new ClsDepartamento(1,"Recursos Humanos"),
            new ClsDepartamento(2,"Ventas"),
            new ClsDepartamento(3,"Comercial"),
            new ClsDepartamento(4,"Finanzas"),
        };

        public static List<ClsPersona> ListarPersonas()
        {
            return listaPersonas;
        }

        public static List<ClsDepartamento> ListarDepartamentos()
        {
            return listaDepartamentos;
        }
        public static ClsPersona BuscarPersona(int id)
        {
            return listaPersonas.Find(x => x.Id == id);
        }

        public static ClsDepartamento BuscarDepartamento(int id)
        {
            return listaDepartamentos.Find(x => x.IdDepartamento == id);
        }

        public static bool DeletePersona(int id)
        {
            ClsPersona persona = BuscarPersona(id);
            return listaPersonas.Remove(persona);
        }

        public static bool UpdatePersona(int id, ClsPersona personaEditada)
        {
            bool res = true;
            try
            {
            ClsPersona persona = BuscarPersona(id);
            int index = listaPersonas.IndexOf(persona);
            persona.Nombre = personaEditada.Nombre;
            persona.Direccion = personaEditada.Direccion;
            persona.IdDepartamento = personaEditada.IdDepartamento;
            listaPersonas[index] = persona;
            }catch(Exception ex)
            {
                res = false;
            }
            return res;            
        }

        public static bool AddPersona(ClsPersona persona)
        {
            bool res = true;
            try
            {
            persona.Id = nextId();
            listaPersonas.Add(persona);
            }catch(Exception ex)
            {
                res = false;
            }
            return res;
        }

        private static int nextId()
        {
            int idMax;
            idMax = listaPersonas.Last().Id;
            return idMax + 1;
        }
    }
}
