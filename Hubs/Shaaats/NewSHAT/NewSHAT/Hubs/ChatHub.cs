using Microsoft.AspNetCore.SignalR;
using Models;
namespace NewSHAT.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ClsMensajeUsuario mensaje)
        {
            await Clients.All.SendAsync("ReceiveMessage", mensaje);
        }
    }
}
