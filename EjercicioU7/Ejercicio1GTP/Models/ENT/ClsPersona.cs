namespace Ejercicio1GTP.Models.ENT
{

    public class PersonaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdDepartamento { get; set; }
        public List<clsDepartamento> Departamentos { get; set; } // Para el dropdown
    }

}
