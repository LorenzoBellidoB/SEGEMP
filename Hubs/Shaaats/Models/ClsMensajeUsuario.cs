namespace Models
{
    public class ClsMensajeUsuario
    {
        private string nombreUsuario;
        private string mensajeUsuario;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string MensajeUsuario { get => mensajeUsuario; set => mensajeUsuario = value; }

        public ClsMensajeUsuario(string nombreUsuario, string mensajeUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
        }
    }
}
