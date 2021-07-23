using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace api.Hubs
{
    public class CaixaHub : Hub
    {
        static readonly Dictionary<string, string> Users = new Dictionary<string, string>();
        public async Task Register(string username)
        {
            if (Users.ContainsKey(username))
            {
                Users.Add(username, this.Context.ConnectionId);
            }

            await Clients.All.SendAsync(WebSocketActions.USER_JOINED, username);
        }

        public async Task Leave(string username)
        {
            Users.Remove(username);
            await Clients.All.SendAsync(WebSocketActions.USER_LEFT, username);
        }

        public async Task Send(string username, string message)
        {
            await Clients.All.SendAsync(WebSocketActions.MESSAGE_RECEIVED, username, message);
        }

        public async Task hubAtivarDesativar(int caixa_id, bool status)
        {
            await Clients.All.SendAsync(WebSocketActions.MESSAGE_RECEIVED, caixa_id, status);
        }
    }

    public struct WebSocketActions
    {
        public static readonly string MESSAGE_RECEIVED = "messageReceived";
        public static readonly string USER_LEFT = "userLeft";
        public static readonly string USER_JOINED = "userJoined";
    }
}