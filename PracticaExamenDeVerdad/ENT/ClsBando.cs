using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsBando
    {
        #region Atributos
        private int id;
        private string bando;
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Bando { get { return bando; } set { bando = value; } }
        #endregion

        #region Constructor
        public ClsBando(int id, string bando)
        {
            this.id = id;
            this.bando = bando;
        }
        public ClsBando() { }
        #endregion
    }
}
