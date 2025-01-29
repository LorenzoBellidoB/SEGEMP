namespace Models
{
    public class ClsMensajeUsuario
    {
        private string nombreUsuario;
        private string mensajeUsuario;
        private string group;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string MensajeUsuario { get => mensajeUsuario; set => mensajeUsuario = value; }
        public string Group { get => group; set => group = value; }

        public ClsMensajeUsuario() { }

        public ClsMensajeUsuario(string nombreUsuario, string mensajeUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
            this.group = group;
        }
        public ClsMensajeUsuario(string nombreUsuario, string mensajeUsuario, string group)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
            this.group = group;
        }
    }
}
