using BL;
using Ejercicio01.Models;
using ENT;

namespace Ejercicio01.ViewModels
{
    public class ListadoPersonaVM
    {
        public static List<ClsPersona> ListadoPersonas { get { return ClsListadoPersonasBl.obtenerPersonasBl(); }  }

        public static List<ClsPersonaConCheck> ListadoPersonasConCheck {
            get
            {
                List<ClsPersona> personas = ListadoPersonas;
                List<ClsPersonaConCheck> listadoPersonasConCheck = new List<ClsPersonaConCheck>();
                foreach (ClsPersona persona in personas)
                {
                    ClsPersonaConCheck personaConCheck = new ClsPersonaConCheck(persona.Id, persona.Nombre, persona.Apellido, persona.FechaNacimiento);
                    listadoPersonasConCheck.Add(personaConCheck);
                }
                return listadoPersonasConCheck; 
            }
        }
    }
}
