using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Components
{
    public class Chat : ViewComponent
    {
        private readonly IChat _chat;

        public Chat(IChat chat)
        {
            _chat = chat;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var history = await _chat.GetMessages();
            return View(history);
        }
    }
}
