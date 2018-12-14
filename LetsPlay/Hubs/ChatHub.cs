using LetsPlay.Models;
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
        private readonly IChat _chat;

        public ChatHub(IChat context)
        {
            _chat = context;
        }

        // Send message to chatRoom
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            
            //Stores message and user to db
            await _chat.CreateMessage(new GeneralChat() { User = user, Message = message });
        }

        // Send message to postRoom
        public async Task SendComment(int postID, string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            //Stores comments and user with PostID to db
            var newComment = new Comments() { Username = user, PostNumber = postID, Message = message };
            await _chat.CreateComment(newComment);

        }
    }
}
