using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPlay.Models;
using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChat _chat;
        private readonly IPost _post;
        private readonly IFriendships _frendships;
        private UserManager<ApplicationUser> _userManager { get; set; }
        private SignInManager<ApplicationUser> _signInManager;
        public ApplicationUser CurrentUser { get; set; }

        public HomeController(IChat chat, IPost post, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IFriendships friendships)
        {
            _chat = chat;
            _post = post;
            _userManager = userManager;
            _signInManager = signInManager;
            _frendships = friendships;
            
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
                ViewBag.Friends = await _frendships.GetFriendshipsForUser(CurrentUser.UserName);
            }
            
            ViewBag.Posts = await _post.GetLastTenPosts();
            return View();
        }

        public async Task<IActionResult> ChatRoom()
        {
            ViewBag.GeneralChat = await _chat.GetMessages();
            return View();
        }
    }
}