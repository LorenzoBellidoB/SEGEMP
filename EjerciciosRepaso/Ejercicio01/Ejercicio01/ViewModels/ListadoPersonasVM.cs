using BL01;
using Ejercicio01.Models;
using ENT01;

namespace Ejercicio01.ViewModels
{
    public class ListadoPersonasVM
    {
        public List<ClsPersona> ListadoPersonas { get; set; }
        public List<PersonaConCheck> ListadoPersonasConCheck{ get; set; }
    }
}
