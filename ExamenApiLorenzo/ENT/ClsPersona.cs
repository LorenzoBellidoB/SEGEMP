﻿namespace ENT
{
    public class ClsPersona
    {
        #region Atributos
        private int id = 0;
        private string nombre = "";
        private string apellidos = "";
        private string telefono = "";
        private string direccion = "";
        private string foto = "";
        private DateTime fechaNacimiento;
        private int idDepartamento;
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Foto { get { return foto; } set { foto = value; } }
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento = value; } }
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value; } }
        #endregion

        #region Constructores
        public ClsPersona() { }

        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }

        public ClsPersona(string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }

        public ClsPersona(int id)
        {
            this.id = id;
        }
        #endregion
    }
}
