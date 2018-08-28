using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRTest2
{
    public class TimeHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Connected to SignalR Server");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Notify(string message)
        {
            await Clients.All.SendAsync(message);
        }
    }
}
