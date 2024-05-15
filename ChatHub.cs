using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
namespace JobPortal
{
    public sealed class ChatHub : Hub
    {
        private readonly IDictionary<string, UserRoomConnection> _connection;
        private readonly string _both_user;
        public ChatHub(IDictionary<string, UserRoomConnection> connection )
        {
            _both_user = "mychat user";
            _connection = connection;
        }
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("Received", $"{Context.ConnectionId} has joined");
        //}
        public async Task JoinRoom(UserRoomConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.room);
            _connection[Context.ConnectionId] = userConnection;

            //await Clients.Group(userConnection.room)
            //    .SendAsync("ReceiveMessage", _both_user, $"{userConnection.user} has joined {userConnection.room}");
            await SendConnectedUser(userConnection.room);
        }

        public async Task SendMessage(string message)
        {
            if(_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection userRoomConnection))
            {
                await Clients.Group(userRoomConnection.room)
                    .SendAsync("receiveMessage", userRoomConnection.user, message);
            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if(_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection roomConnection))
            {
                _connection.Remove(Context.ConnectionId);
                Clients.Group(roomConnection.room!)
                .SendAsync("ReceiveMessage", _both_user, $"{roomConnection.user} has left the group");
                SendConnectedUser(roomConnection.room);

            }
            return base.OnDisconnectedAsync(exception);
        }

        public Task SendConnectedUser(string room)
        {
            var users = _connection.Values.Where(u => u.room == room).Select(s => s.user);
            return Clients.Group(room).SendAsync("usersInRoom", users);
        }
    }
}
