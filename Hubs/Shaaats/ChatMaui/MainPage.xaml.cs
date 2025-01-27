using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace ChatMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection _connection;

        public ObservableCollection<ClsMensajeUsuario> Lista { get; set; } = new ObservableCollection<ClsMensajeUsuario>();
        public MainPage()
        {
            
            InitializeComponent();

            BindingContext = this;

            ChatList.ItemsSource = Lista;
            _connection = new HubConnectionBuilder().WithUrl("http://localhost:5111/chathub").Build();

            _connection.On<ClsMensajeUsuario>("ReceiveMessage", anyadirMensaje);

            Task.Run(() =>
            {
                Dispatcher.Dispatch(async () =>
                await _connection.StartAsync());
            });
        }

        private void anyadirMensaje(ClsMensajeUsuario usuario)
        {
            Dispatcher.Dispatch(async () => Lista.Add(usuario));
        }

        public async void OnSendClicked(object sender, EventArgs e)
        {

            ClsMensajeUsuario usuario = new ClsMensajeUsuario(User.Text, Message.Text);
            await _connection.InvokeCoreAsync("SendMessage", args: new[]
            {
                usuario
            });

            User.Text = string.Empty;
            Message.Text = string.Empty;
        }

    }

}
