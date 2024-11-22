namespace ENT
{
    public class ClsMafioso
    {

        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string Apellido { get; set; }

        #endregion

        #region Constructores
        public ClsMafioso() { }
        public ClsMafioso(int id, string nombre, DateTime fechaNac, string apellido)
        {
            Id = id;
            Nombre = nombre;
            FechaNac = fechaNac;
            Apellido = apellido;
        }

        #endregion

    }
}
