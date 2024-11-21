using ENT;

namespace Ejercicio01.Models
{
    public class ClsPersonaConCheck: ClsPersona
    {
        private bool esMayor;

        public bool EsMayor
        {
            get { return esMayor; }
        }

        public ClsPersonaConCheck(int id, string nombre, string apellido, DateTime fechanacimiento):base(id, nombre, apellido, fechanacimiento) 
        {
            this.esMayor = mayorDeEdad();
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechanacimiento;
        }

        private bool mayorDeEdad()
        {
            bool mayor = false;

            if (DateTime.Now.Year - FechaNacimiento.Year >= 18)
            {
                mayor = true;
            }

            return mayor;
        }
    }
}
