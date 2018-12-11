using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Signalr.Hubs
{
    public class Chathub : Hub
    {
        public Task Send(string name, string message)
        {
            return Clients.All.SendAsync(name, message);
        }
    }
}
