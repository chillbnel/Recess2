using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPlay.Models;
using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChat _chat;

        public HomeController(IChat context)
        {
            _chat = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _chat.GetMessages());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([Bind("ID,User,Message")] GeneralChat chat)
        {
            if (ModelState.IsValid)
            {
                await _chat.CreateMessage(chat);
            }
        }
    }
}