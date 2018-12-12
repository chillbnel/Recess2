using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IFriendships
    {
        Task<IEnumerable<Friendships>> GetAllFriendships();

        Task<IEnumerable<Friendships>> GetFriendshipsForUser();

        Task CreateFriendRequest();

        Task AcceptFriendRequest();

        Task RemoveFriend();
    }
}
