using BL;
using ENT;

namespace ExamenApiLorenzo.DTO
{
    public class PersonaConNombreDptEdad: ClsPersona
    {
        #region Atributos
        private string nombreDpt = "";
        private int edad = 0;
        #endregion

        #region Propiedades
        public string NombreDpt { get { return nombreDpt; } set { nombreDpt = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        #endregion

        #region Constructores
        public PersonaConNombreDptEdad() { }

        public PersonaConNombreDptEdad(ClsPersona persona) 
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;
            GetEdad();
            GetNombreDpt();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para obtener la edad
        /// </summary>
        private void GetEdad()
        {
            this.edad = DateTime.Now.Year - this.FechaNacimiento.Year;
        }
        /// <summary>
        /// Metodo para obtener el nombre del departamento
        /// </summary>
        private void GetNombreDpt()
        {
            ClsDepartamento dpt = ClsListadosBl.GetDepartamento(this.IdDepartamento);
            this.NombreDpt = dpt.Nombre;
        }
        #endregion
    }
}
