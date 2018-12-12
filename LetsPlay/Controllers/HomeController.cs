using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChat _chat;

        public HomeController(IChat chat)
        {
            _chat = chat;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _chat.GetMessages());
        }
    }
}