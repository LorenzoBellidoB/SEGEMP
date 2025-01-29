using EjercicioU10.ViewModels.Utilidades;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatMauiVM.ViewModels
{
    class ChatVM : INotifyPropertyChanged
    {
        #region Atributos
        private ClsMensajeUsuario mensaje;

        private ObservableCollection<ClsMensajeUsuario> listaMensajes;

        private string nombre;

        private string mensajeText;

        private string grupo;

        private DelegateCommand enviarCommand;

        private readonly HubConnection _connection;

        #endregion

        #region Propiedades

        public ObservableCollection<ClsMensajeUsuario> ListaMensajes
        {
            get { return listaMensajes; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; enviarCommand.RaiseCanExecuteChanged(); }
        }

        public String MensajeText
        {
            get { return mensajeText; }
            set { mensajeText = value; enviarCommand.RaiseCanExecuteChanged(); }
        }

        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; enviarCommand.RaiseCanExecuteChanged(); }
        }

        public DelegateCommand EnviarCommand
        {
            get { return enviarCommand; }
        }
        #endregion

        #region Constructor
        public ChatVM() 
        {
            _connection = new HubConnectionBuilder().WithUrl("http://localhost:5111/chathub").Build();

            _connection.On<ClsMensajeUsuario>("ReceiveMessage", anyadirMensaje);
            esperarConecxion();
            listaMensajes = new ObservableCollection<ClsMensajeUsuario>();
            enviarCommand = new DelegateCommand(ExecutedEnviar, CanExecuteEnviar);
        }

        #endregion


        #region Command

        private async void ExecutedEnviar()
        {
            mensaje = new ClsMensajeUsuario();
            mensaje.NombreUsuario = Nombre;
            mensaje.MensajeUsuario = MensajeText;
            mensaje.Group = Grupo;
            
            if(grupo != null)
            {
                await _connection.InvokeCoreAsync("JoinGroup", args: 
                    new[] 
                    { 
                        mensaje 
                    });
                await _connection.SendAsync("SendMessageToGroup", mensaje);
            }
            else
            {
                await _connection.SendAsync("SendMessage", mensaje);
            }
            
            Nombre = string.Empty;
            MensajeText = string.Empty;
            NotifyPropertyChanged("Nombre");
            NotifyPropertyChanged("MensajeText");
            NotifyPropertyChanged("Grupo");

        }
        private bool CanExecuteEnviar()
        {
            bool res = false;
            if(!String.IsNullOrEmpty(nombre) && !String.IsNullOrEmpty(mensajeText) && grupo != null)
            {
                res = true;
            }
            return res;
        }
        #endregion

        #region Metodos
        private void anyadirMensaje(ClsMensajeUsuario usuario)
        {
            MainThread.BeginInvokeOnMainThread(async () => ListaMensajes.Add(usuario));
        }

        private async Task esperarConecxion()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            await _connection.StartAsync());
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
