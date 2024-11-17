using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT01
{
    public class ClsPersona
    {
        #region Atributos
        private int idPersona;
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        #endregion

        #region Propiedades
        public int IdPersona { get { return idPersona; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento = value; } }
        #endregion

        #region Constructores
        public ClsPersona()
        {

        }

        public ClsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNacimiento)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
        }
        #endregion
    }
}
