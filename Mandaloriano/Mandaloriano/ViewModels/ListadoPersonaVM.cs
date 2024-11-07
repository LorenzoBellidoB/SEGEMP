using BL;
using ENT;

namespace Mandaloriano.ViewModels
{
    public class ListadoPersonaVM : ClsMision
    {
        public List<ClsMision> Listado {  get; set; } 
        public ClsMision MisionSelected {  get; set; }

    }
}
