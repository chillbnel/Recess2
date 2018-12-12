using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IFriendships
    {
        Task<IEnumerable<Friendships>> GetAllFriendships();

        Task<IEnumerable<ApplicationUser>> GetSentFriendRequestsForUser(string username);

        Task<IEnumerable<ApplicationUser>> GetReceivedFriendRequestsForUser(string username);

        Task<IEnumerable<ApplicationUser>> GetFriendshipsForUser(string username);

        Task CreateFriendRequest(string username1, string username2);

        Task AcceptFriendRequest(string username1, string username2);

        Task RemoveFriend(string username1, string username2);
    }
}
