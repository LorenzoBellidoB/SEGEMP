using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsMision
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Pago { get; set; }
        public int idMafioso {  get; set; }

        #endregion

        #region Constructores
        
        public ClsMision() { }
        public ClsMision(int id, string nombre, double pago, int idMafioso)
        {
            Id = id;
            Nombre = nombre;
            Pago = pago;
            this.idMafioso = idMafioso;
        }


        #endregion
    }
}
