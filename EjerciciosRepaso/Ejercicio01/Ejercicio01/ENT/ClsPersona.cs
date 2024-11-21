using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsPersona
    {
        #region Atributos
        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        #endregion

        #region Constructores
        public ClsPersona()
        {
            this.id = 0;
            this.nombre = "";
            this.apellido = "";
            this.fechaNacimiento = DateTime.Now;
        }
        public ClsPersona(int id, string nombre, string apellido, DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
        }
        #endregion
    }
}
