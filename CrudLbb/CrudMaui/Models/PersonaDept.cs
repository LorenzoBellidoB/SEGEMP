using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.Models
{
    public class PersonaDept : ClsPersona
    {
        #region Atributos
        private string nombreDept;

        #endregion

        #region Propiedades
        public string NombreDept
        {
            get { return nombreDept; }
            set { nombreDept = value; }
        }

        #endregion

        #region Constructores
        public PersonaDept(ClsPersona persona, List<ClsDepartamento> departamentos)
        {
            Id = persona.Id;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            Telefono = persona.Telefono;
            Direccion = persona.Direccion;
            Foto = persona.Foto;
            FechaNacimiento = persona.FechaNacimiento;
            IdDepartamento = persona.IdDepartamento;

            string nombreDepartamento = departamentos.FirstOrDefault(x => x.Id == persona.IdDepartamento).Nombre;
            if (nombreDepartamento != null)
            {
                this.nombreDept = nombreDepartamento;
            }
        }

        #endregion
    }
}
