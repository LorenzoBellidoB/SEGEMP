using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03ENT
{
    /// <summary>
    /// Clase que representa una persona con sus propiedades
    /// </summary>
    public class ClsPersona
    {
        #region Atributos
        private string idPersona = "";
        private string nombre = "";
        private string apellidos = "";
        private string edad = "";
        #endregion
        #region Constructor
        

        #endregion
        #region Propiedades
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Edad {  get; set; }
        #endregion
    }
}
