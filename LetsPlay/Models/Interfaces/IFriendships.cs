using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IFriendships
    {
        Task<IEnumerable<Friendships>> GetAllFriendships();

        Task<IEnumerable<ApplicationUser>> GetFriendRequestsForUser(string username);

        Task<IEnumerable<ApplicationUser>> GetFriendshipsForUser(string username);

        Task CreateFriendRequest(string username1, string username2);

        Task AcceptFriendRequest(int id);

        Task RemoveFriend(string username1, string username2);
    }
}
