using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPlay.Models;
using LetsPlay.Models.Interfaces;
using LetsPlay.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; set; }

        private readonly IFriendships _friendships;

        public UserController(UserManager<ApplicationUser> userManager, IFriendships friendship)
        {
            _userManager = userManager;
            _friendships = friendship;
        }

        [HttpGet("/users/{username}")]
        public async Task<IActionResult> Index(string username)
        {
            ApplicationUser AppUser = await _userManager.FindByNameAsync(username);

            var userFriends = await _friendships.GetFriendshipsForUser(username);
            var userSentRequests = await _friendships.GetSentFriendRequestsForUser(username);
            var userReceivedRequests = await _friendships.GetSentFriendRequestsForUser(username);

            FriendshipsViewModel fvm = new FriendshipsViewModel()
            {
                User = AppUser,
                Friends = userFriends,
                ReceivedRequests = userReceivedRequests,
                SentRequests = userSentRequests
            };

            return View(fvm);
        }
    }
}