namespace AppSecret.WebApi.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PostNotificationHub : Hub
    {
        public async Task Notify(string user)
        {
            await Clients.All.SendAsync("newpost", user);
        }
    }
}
