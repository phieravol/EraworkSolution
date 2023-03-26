using Microsoft.AspNetCore.SignalR;
using Erawork.Pages.Messages;
namespace Erawork.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()=>Context.ConnectionId;
        public override Task OnConnectedAsync()
        {
            ConnectedUser.myConnectedUsers.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUser.myConnectedUsers.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.Client(user).SendAsync("ReceiveMessage", user, message);
        }
    }
}
