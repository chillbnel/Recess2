using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Hubs
{
    public class ChatHub : Hub
    {
        private IChat _chat;

        public ChatHub(IChat chat)
        {
            _chat = chat;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
