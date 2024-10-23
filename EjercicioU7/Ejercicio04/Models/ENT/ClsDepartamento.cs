namespace Ejercicio04.Models.ENT
{
    public class ClsDepartamento
    {
        private static int nextId = 1; // Variable estática para el siguiente ID

        public int idDepartamento { get; private set; } // Propiedad de solo lectura
        public string nombreDepartamento { get; set; }

        // Constructor que asigna el ID y el nombre
        public ClsDepartamento(string nombre)
        {
            idDepartamento = nextId++; // Asignar el ID y luego incrementarlo
            nombreDepartamento = nombre;
        }
    }
}
