using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Components
{
    public class Notifications : ViewComponent
    {
        private IFriendships _friendships;

        public Notifications(IFriendships friendships)
        {
            _friendships = friendships;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var pendingFriends = await _friendships.GetReceivedFriendRequestsForUser(username);

            return View(pendingFriends);
        }
    }
}
