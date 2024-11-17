using ENT01;

namespace Ejercicio01.Models
{
    public class PersonaConCheck: ClsPersona
    {
        #region Atributos
        private bool esMayor = false;
        #endregion

        #region Constructores
        public PersonaConCheck() { }

        public PersonaConCheck(ClsPersona p,bool esMayor) 
        {
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.FechaNacimiento = p.FechaNacimiento;
            this.esMayor = esMayor;
        }
        #endregion

        #region Propiedades
        public bool EsMayor { get { return EsMayordeEdad(); } }
        #endregion

        #region Metodos
        private static bool EsMayordeEdad()
        {
            bool res = false;
            PersonaConCheck persona = new PersonaConCheck();
            if(DateTime.Now.Year - persona.FechaNacimiento.Year > 18)
            {
                res = true;
            }
            return res;
        
        }
        #endregion
    }
}