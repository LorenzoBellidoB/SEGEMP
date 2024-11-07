using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    /// <summary>
    /// Clase que recoge las propiedades de una mision
    /// </summary>
    public class ClsMision
    {
        #region Propiedades
        public int IdMision { get; set; }
        public string Titulo { get; set; }
        public string Descripcion {  get; set; }
        public double Recompensa {  get; set; }
        #endregion
    }
}
