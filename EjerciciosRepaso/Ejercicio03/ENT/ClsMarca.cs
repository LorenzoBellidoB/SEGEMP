using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsMarca
    {
        #region Atributos
        private int id;
        private string nombre;
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get{ return nombre; } set { nombre = value; } }
        #endregion

        #region Constructores
        public ClsMarca() { }

        public ClsMarca(int id)
        {
            this.id = id;
        }

        public ClsMarca(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion
    }
}
