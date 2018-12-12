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
            ViewBag.GeneralChat = await _chat.GetMessages();
            return View();
        }
    }
}