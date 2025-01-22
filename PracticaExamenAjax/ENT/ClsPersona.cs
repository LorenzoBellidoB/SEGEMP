namespace ENT
{
    public class ClsPersona
    {
        #region Atributos
        private int id;
        private string nombre;
        private string direccion;
        private int idDepartamento;
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value; } }
        #endregion

        #region Constructores
        public ClsPersona() { }
        public ClsPersona(string nombre, string direccion, int idDepartamento)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.idDepartamento = idDepartamento;
        }
        public ClsPersona(int id, string nombre, string direccion, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.idDepartamento = idDepartamento;
        }

        #endregion
    }
}
