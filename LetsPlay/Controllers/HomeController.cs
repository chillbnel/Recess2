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
        private readonly IPost _post;

        public HomeController(IChat chat, IPost post)
        {
            _chat = chat;
            _post = post;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.GeneralChat = await _chat.GetMessages();
            ViewBag.Posts = await _post.GetLastTenPosts();
            return View();
        }
    }
}