using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Controllers
{
    [Authorize]
    public class FriendshipsController : Controller
    {
        private readonly IFriendships _friendships;

        public FriendshipsController(IFriendships friendships)
        {
            _friendships = friendships;
        }

        public async Task<IActionResult> SendRequest(string from, string to)
        {
            await _friendships.CreateFriendRequest(from, to);

            return Redirect($"/users/{to}");
        }

        public async Task<IActionResult> AcceptRequest(string from, string to)
        {
            await _friendships.AcceptFriendRequest(from, to);

            return Redirect($"/users/{to}");
        }

        public async Task<IActionResult> RemoveFriend(string user1, string user2)
        {
            await _friendships.RemoveFriend(user1, user2);

            return Redirect($"/users/{user2}");
        }
    }
}
