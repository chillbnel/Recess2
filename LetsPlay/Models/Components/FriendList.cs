using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Components
{
    public class FriendList : ViewComponent
    {
        private IFriendships _friendships;

        public FriendList(IFriendships friendships)
        {
            _friendships = friendships;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var friends = await _friendships.GetFriendshipsForUser(username);

            return View(friends);
        }
    }
}
