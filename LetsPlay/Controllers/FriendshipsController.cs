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


            return View();
        }
    }
}
