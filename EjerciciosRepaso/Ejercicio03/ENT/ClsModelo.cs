using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsModelo
    {
        #region Atributos
        private int id;
        private string nombre;
        private int idMarca;
        #endregion

        #region Propiedades
        public int Id { get; }
        public string Nombre { get; set; }
        public int IdMarca { get{ return idMarca; } set { idMarca = value; } }
        #endregion

        #region Constructores
        public ClsModelo() { }

        public ClsModelo(int id)
        {
            this.id = id;
        }

        public ClsModelo(int id, string nombre, int idMarca)
        {
            this.id = id;
            this.nombre = nombre;
            this.idMarca = idMarca;
        }
        #endregion
    }
}
