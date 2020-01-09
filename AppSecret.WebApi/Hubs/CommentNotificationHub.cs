using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSecret.WebApi.Hubs
{
    public class CommentNotificationHub : Hub
    {
        public async Task Notify(string user)
        {
            await Clients.All.SendAsync("newcomment", user);
        }
    }
}
