using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPlay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; set; }


        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
        //    return View(AppUser);
        //}
        [HttpGet("/users/{username}")]
        public async Task<IActionResult> Index(string username)
        {
            ApplicationUser AppUser = await _userManager.FindByNameAsync(username);

            return View(AppUser);
        }
    }
}