using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IPost
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<IEnumerable<Post>> GetLastTenPosts();

        Task<Post> GetPost(int? id);

        Task CreatePost(Post post);

        Task UpdatePost(Post post);

        Task DeletePost(int id);

        Task CreateASignUp(PlayerSignups paplayerSignUpForEvent);

        Task DeleteASignUp(string userName, int postID);

        IEnumerable<PlayerSignups> GetAllPlayersSignedUp(int postID);

        IEnumerable<Comments> GetAllCommentsForPost(int postID);

        Task<List<Post>> GetAllSignedupEventsForPlayer(string username);
    }
}
