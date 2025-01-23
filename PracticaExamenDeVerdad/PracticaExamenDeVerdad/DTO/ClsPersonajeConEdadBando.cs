using BL;
using DAL;
using ENT;

namespace PracticaExamenDeVerdad.DTO
{
    public class ClsPersonajeConEdadBando:ClsPersonaje
    {
        #region Atributos
        private string nombreBando;
        private int edad;
        #endregion

        #region Propiedades
        public string NombreBando { get { return nombreBando; } set { nombreBando = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        #endregion

        #region Constructores
        public ClsPersonajeConEdadBando() { }
        public ClsPersonajeConEdadBando(ClsPersonaje personaje) 
        { 
            this.Id = personaje.Id;
            this.Nombre = personaje.Nombre;
            this.FechaNac = personaje.FechaNac;
            this.IdBando = personaje.IdBando;
            getEdad(); 
            getNombreBando(personaje.IdBando);
        }
        #endregion

        #region Metodos
        private void getEdad()
        {
            this.edad = DateTime.Now.Year - this.FechaNac.Year;
        }

        private void getNombreBando(int idBando)
        {
            ClsBando bando  = ClsListadoBl.GetBando(idBando);
            this.NombreBando = bando.Bando;
        }
        #endregion
    }
}
