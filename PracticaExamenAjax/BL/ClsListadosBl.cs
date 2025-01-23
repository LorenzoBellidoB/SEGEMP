using DAL;
using ENT;

namespace BL
{
    public class ClsListadosBl
    {
        public static List<ClsPersona> ListadoPersonasBL()
        {
            List<ClsPersona> personas = new List<ClsPersona>();
            if (enHorario())
            {
                personas = ClsListadosDal.ListarPersonas();
            }
            else
            {
                personas = null;
            }
            return personas;
        }

        public static List<ClsDepartamento> ListadoDepartamentosBL()
        {
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>();
            if (enHorario())
            {
                departamentos = ClsListadosDal.ListarDepartamentos();
            }
            else
            {
                departamentos = null;
            }
            return departamentos;
        }

        public static ClsPersona BuscarPersonaBL(int id)
        {
            ClsPersona persona = new ClsPersona();
            if (enHorario())
            {
                persona = ClsListadosDal.BuscarPersona(id);
            }
            else
            {
                persona = null;
            }
            return persona;
        }

        public static ClsDepartamento BuscarDepartamentoBL(int id)
        {
            ClsDepartamento departamento = new ClsDepartamento();
            if (enHorario())
            {
                departamento = ClsListadosDal.BuscarDepartamento(id);
            }
            else
            {
                departamento = null;
            }
            return departamento;
        }

        public static bool DeletePersonaBL(int id)
        {
            bool eliminado = false;
            if (enHorario())
            {
                eliminado = ClsListadosDal.DeletePersona(id);
            }
            return eliminado;
        }

        public static bool UpdatePersonaBL(int id, ClsPersona persona)
        {
            bool actualizado = false;
            if (enHorario())
            {
                actualizado = ClsListadosDal.UpdatePersona(id, persona);
            }
            return actualizado;
        }

        public static bool AddPersonaBL(ClsPersona persona)
        {
            bool insertado = false;
            if (enHorario())
            {
                insertado = ClsListadosDal.AddPersona(persona);
            }
            return insertado;
        }

        private static bool enHorario()
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
