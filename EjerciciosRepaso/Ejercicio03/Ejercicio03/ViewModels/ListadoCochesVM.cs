using ENT;

namespace Ejercicio03.ViewModels
{
    public class ListadoCochesVM
    {
        public List<ClsMarca> ListadoMarcas { get; set; }

        public List<ClsModelo> ListadoModelos { get; set; }

        public ClsMarca MarcaSeleccionada { get; set; }
    }
}
