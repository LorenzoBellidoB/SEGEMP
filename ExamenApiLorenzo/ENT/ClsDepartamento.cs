using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamento
    {
        #region Atributos
        private int id = 0;
        private string nombre = "";
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        #endregion

        #region Constructores
        public ClsDepartamento() { }

        public ClsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public ClsDepartamento(int id)
        {
            this.id = id;
        }
        #endregion
    }
}
