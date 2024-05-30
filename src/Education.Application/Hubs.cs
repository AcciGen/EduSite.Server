using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application
{
    public class Hubs:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(message);
        }
    }
}
