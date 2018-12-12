using LetsPlay.Data;
using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Services
{
    public class FriendshipsService : IFriendships
    {
        private LetsPlayDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public FriendshipsService(LetsPlayDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task CreateFriendRequest(string username1, string username2)
        {
            Friendships friendRequest = new Friendships()
            {
                User1 = username1,
                User2 = username2,
                Accepted = false
            };

            _context.Friendships.Add(friendRequest);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptFriendRequest(int id)
        {
            var result = await _context.Friendships.FindAsync(id);
            result.Accepted = true;

            _context.Friendships.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Friendships>> GetAllFriendships()
        {
            return await _context.Friendships.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetFriendshipsForUser(string username)
        {
            var column1 = await _context.Friendships.Where(x => x.User1 == username && x.Accepted == true).ToListAsync();

            var column2 = await _context.Friendships.Where(x => x.User2 == username && x.Accepted == true).ToListAsync();

            var friends1 = column1.Select(x => x.User2);
            var friends2 = column1.Select(x => x.User1);

            var allFriends = friends1.Concat(friends2);

            List<ApplicationUser> friendsToUsers = new List<ApplicationUser>();

            foreach (string user in allFriends)
            {
                ApplicationUser appUser = await _userManager.FindByNameAsync(username);
                friendsToUsers.Add(appUser);
            }

            return friendsToUsers;

        }

        public Task RemoveFriend(string username1, string username2)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetFriendRequestsForUser(string username)
        {
            var column1 = await _context.Friendships.Where(x => x.User1 == username && x.Accepted == false).ToListAsync();

            var column2 = await _context.Friendships.Where(x => x.User2 == username && x.Accepted == false).ToListAsync();

            var friends1 = column1.Select(x => x.User2);
            var friends2 = column1.Select(x => x.User1);

            var allFriends = friends1.Concat(friends2);

            List<ApplicationUser> friendsToUsers = new List<ApplicationUser>();

            foreach (string user in allFriends)
            {
                ApplicationUser appUser = await _userManager.FindByNameAsync(username);
                friendsToUsers.Add(appUser);
            }

            return friendsToUsers;
        }
    }
}
