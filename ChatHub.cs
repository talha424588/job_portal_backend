using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace JobPortal
{
    public sealed class ChatHub : Hub
    {
        private readonly IDictionary<string, UserRoomConnection> _connection;
        public ChatHub(IDictionary<string, UserRoomConnection> connection )
        {
            _connection = connection;
        }
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("Received", $"{Context.ConnectionId} has joined");
        //}
        public async Task JoinRoom(UserRoomConnection userRoomConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userRoomConnection.room!);
            _connection[Context.ConnectionId] = userRoomConnection;

            await Clients.Group(userRoomConnection.room!)
                .SendAsync("ReceiveMessage", "Let's Program Bot", $"{userRoomConnection.user}");
            await SendConnectedUser(userRoomConnection.room!);
        }

        public async Task SendMessage(string message)
        {
            if(_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection userRoomConnection))
            {
                await Clients.Group(userRoomConnection.room!)
                    .SendAsync("receiveMessage", userRoomConnection.user, message,DateTime.Now);

            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if(!_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection roomConnection))
            {
                return base.OnDisconnectedAsync(exception);
            }
            Clients.Group(roomConnection.room!)
                .SendAsync("ReceiveMessage", "Let's Program bot", $"{roomConnection.user} has left the group");
            SendConnectedUser(roomConnection.room!);
            return base.OnDisconnectedAsync(exception);
        }

        public Task SendConnectedUser(string room)
        {
            var users = _connection.Values.Where(u=>u.room == room).Select(s =>s.user);
            return Clients.Group(room).SendAsync("ConnectedUsers",users);
        }
    }
}
