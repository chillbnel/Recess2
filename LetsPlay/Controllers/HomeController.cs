using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsPlay.Models.Interfaces;

namespace LetsPlay.Controllers
{
    public class HomeController : Controller
    {
        private IPost _context;

        public HomeController(IPost context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GetLastTenPosts());
        }
    }
}