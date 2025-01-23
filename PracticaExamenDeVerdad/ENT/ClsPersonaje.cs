namespace ENT
{
    public class ClsPersonaje
    {
        #region Atributos
        private int id;
        private string nombre;
        private DateTime fechaNac;
        private int idBando;
        #endregion

        #region Propiedades
        public int Id { get{ return id; } set{ id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public DateTime FechaNac { get { return fechaNac; } set { fechaNac = value; } }
        public int IdBando { get { return idBando; } set { idBando = value; } }
        #endregion

        #region Constructores
        public ClsPersonaje() { }

        public ClsPersonaje(int id, string nombre, DateTime fechaNac, int idBando) 
        {
            this.id = id;
            this.nombre = nombre;
            this.fechaNac = fechaNac;
            this.idBando = idBando;
        }

        public ClsPersonaje(string nombre, DateTime fechaNac, int idBando)
        {
            this.nombre = nombre;
            this.fechaNac = fechaNac;
            this.idBando = idBando;
        }


        #endregion
    }
}
