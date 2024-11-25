using BL;
using ENT;

namespace CrudAsp.Models
{
    public class ClsPersonaConNombreDepartamento : ClsPersona
    {
        private string nombreDept; 

        public string NombreDept
            {
                get { return nombreDept; }
                set { nombreDept = value; }
            }

        public ClsPersonaConNombreDepartamento(ClsPersona persona, List<ClsDepartamento> departamentos)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;

            string nombreDepartamento = departamentos.FirstOrDefault(x => x.Id == persona.IdDepartamento).Nombre;
            if (nombreDepartamento != null)
            {
                this.nombreDept = nombreDepartamento;
            }
        }

        public ClsPersonaConNombreDepartamento(int idPersona)
        {
            ClsPersona persona = ClsServiciosBl.buscarPersonaBl(idPersona);

            if (persona != null)
            {
                this.Id = persona.Id;
                this.Nombre = persona.Nombre;
                this.Apellidos = persona.Apellidos;
                this.Telefono = persona.Telefono;
                this.Direccion = persona.Direccion;
                this.Foto = persona.Foto;
                this.FechaNacimiento = persona.FechaNacimiento;
                this.IdDepartamento = persona.IdDepartamento;

                ClsDepartamento dep = ClsServiciosBl.buscarDepartamentoBl(persona.IdDepartamento);

                if (dep != null)
                {
                    this.nombreDept = dep.Nombre;
                }
            }

        }

    }
}
