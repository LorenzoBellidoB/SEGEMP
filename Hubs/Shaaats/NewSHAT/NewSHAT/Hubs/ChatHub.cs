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
        // Enviar mensaje a un grupo específico
        public async Task SendMessageToGroup(ClsMensajeUsuario mensaje)
        {
            await Clients.Group(mensaje.Group).SendAsync("ReceiveMessage", mensaje.NombreUsuario, mensaje.MensajeUsuario);
        }

        // Unirse a un grupo (sala de chat)
        public async Task JoinGroup(ClsMensajeUsuario mensaje)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, mensaje.Group);
        }

        // Salir de un grupo
        public async Task LeaveGroup(ClsMensajeUsuario mensaje)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, mensaje.Group);
        }
    }
}
