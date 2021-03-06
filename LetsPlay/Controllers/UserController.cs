﻿using System;
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
        private readonly IPost _posts;

        public UserController(UserManager<ApplicationUser> userManager, IFriendships friendship, IPost posts)
        {
            _userManager = userManager;
            _friendships = friendship;
            _posts = posts;
        }

        [HttpGet("/users/{username}")]
        public async Task<IActionResult> Index(string username)
        {
            ApplicationUser AppUser = await _userManager.FindByNameAsync(username);

            var user = HttpContext.User;
            var currentUser = _userManager.GetUserName(user);

            var viewUserFriends = await _friendships.GetFriendshipsForUser(username);

            var userFriends = await _friendships.GetFriendshipsForUser(currentUser);
            var userSentRequests = await _friendships.GetSentFriendRequestsForUser(currentUser);
            var userReceivedRequests = await _friendships.GetReceivedFriendRequestsForUser(currentUser);
            var userEventSignups = await _posts.GetAllSignedupEventsForPlayer(username);

            FriendshipsViewModel fvm = new FriendshipsViewModel()
            {
                User = AppUser,
                Friends = userFriends,
                ReceivedRequests = userReceivedRequests,
                SentRequests = userSentRequests,
                ViewUserFriends = viewUserFriends,
                UserSignedupEvents = userEventSignups
            };

            return View(fvm);
        }
    }
}